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

            // Cache control headers for static assets
            if (context.Request.Path.StartsWithSegments("/assets"))
            {
                // CSS, JS, Images - 1 year cache
                context.Response.Headers.Add("Cache-Control", "public, max-age=31536000, immutable");
                context.Response.Headers.Add("Expires", DateTime.UtcNow.AddYears(1).ToString("R"));
            }
            else if (context.Request.Path.StartsWithSegments("/css") || 
                     context.Request.Path.StartsWithSegments("/js") ||
                     context.Request.Path.StartsWithSegments("/images"))
            {
                context.Response.Headers.Add("Cache-Control", "public, max-age=31536000, immutable");
                context.Response.Headers.Add("Expires", DateTime.UtcNow.AddYears(1).ToString("R"));
            }
            else if (context.Request.Path.StartsWithSegments("/sitemap.xml"))
            {
                context.Response.Headers.Add("Cache-Control", "public, max-age=86400");
            }
            else if (context.Request.Path.StartsWithSegments("/robots.txt"))
            {
                context.Response.Headers.Add("Cache-Control", "public, max-age=86400");
            }
            else
            {
                // HTML pages - no cache for dynamic content
                context.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
                context.Response.Headers.Add("Pragma", "no-cache");
                context.Response.Headers.Add("Expires", "0");
            }

            await _next(context);
        }
    }
}
