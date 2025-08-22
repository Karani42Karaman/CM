using Microsoft.AspNetCore.Http;
using System.Text;

namespace CM.Web.Infrastructure.Middleware
{
    public class SeoMiddleware
    {
        private readonly RequestDelegate _next;

        public SeoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // SEO için gerekli header'ları ekle
            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
            context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
            context.Response.Headers.Add("Referrer-Policy", "strict-origin-when-cross-origin");
            context.Response.Headers.Add("Permissions-Policy", "geolocation=(), microphone=(), camera=()");

            // Cache control headers
            if (context.Request.Path.StartsWithSegments("/assets") || 
                context.Request.Path.StartsWithSegments("/css") || 
                context.Request.Path.StartsWithSegments("/js") ||
                context.Request.Path.StartsWithSegments("/images"))
            {
                context.Response.Headers.Add("Cache-Control", "public, max-age=31536000");
            }
            else if (context.Request.Path.StartsWithSegments("/sitemap.xml"))
            {
                context.Response.Headers.Add("Cache-Control", "public, max-age=86400");
            }

            await _next(context);
        }
    }
}
