using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CM.Web.Controllers
{
    public class SitemapIndexController : Controller
    {
        [HttpGet]
        [Route("sitemap-index.xml")]
        public IActionResult Index()
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            
            var sitemapIndex = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("sitemapindex",
                    new XAttribute("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9"),
                    
                    // Ana sitemap
                    new XElement("sitemap",
                        new XElement("loc", $"{baseUrl}/sitemap.xml"),
                        new XElement("lastmod", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"))
                    ),
                    
                    // Resim sitemap (gelecekte eklenebilir)
                    new XElement("sitemap",
                        new XElement("loc", $"{baseUrl}/sitemap-images.xml"),
                        new XElement("lastmod", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"))
                    ),
                    
                    // Haber sitemap (gelecekte eklenebilir)
                    new XElement("sitemap",
                        new XElement("loc", $"{baseUrl}/sitemap-news.xml"),
                        new XElement("lastmod", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"))
                    )
                )
            );
            
            return Content(sitemapIndex.ToString(), "application/xml");
        }
    }
}
