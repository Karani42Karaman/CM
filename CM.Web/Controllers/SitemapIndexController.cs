using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CM.Web.Controllers
{
    public class SitemapIndexController : Controller
    {
        [HttpGet, HttpHead]
        [Route("sitemap-index.xml")]
        public IActionResult Index()
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}";

            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";

            var sitemapIndex = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(ns + "sitemapindex",

                    new XElement(ns + "sitemap",
                        new XElement(ns + "loc", $"{baseUrl}/sitemap.xml"),
                        new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd"))
                    ),

                    new XElement(ns + "sitemap",
                        new XElement(ns + "loc", $"{baseUrl}/sitemap-images.xml"),
                        new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd"))
                    ),

                    new XElement(ns + "sitemap",
                        new XElement(ns + "loc", $"{baseUrl}/sitemap-news.xml"),
                        new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd"))
                    )
                )
            );

            return Content(sitemapIndex.Declaration + sitemapIndex.ToString(), "application/xml; charset=utf-8");
        }
    }
}
