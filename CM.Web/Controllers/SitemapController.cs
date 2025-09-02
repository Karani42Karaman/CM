using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using CM.Core.Service;
using CM.Core;
using CM.Web.Infrastructure.Extensions;

namespace CM.Web.Controllers
{
    public class SitemapController : Controller
    {
        private readonly IUrünServices _urünServices;
        private readonly IGaleriServices _galeriServices;
        private readonly IUnitOfWork _unitOfWork;

        public SitemapController(IUrünServices urünServices, IGaleriServices galeriServices, IUnitOfWork unitOfWork)
        {
            _urünServices = urünServices;
            _galeriServices = galeriServices;
            _unitOfWork = unitOfWork;
        }

        [HttpGet, HttpHead]
        [Route("sitemap.xml")]
        public IActionResult Index()
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            var urunKategorileri = _urünServices.UrünKategoriGetAllAsync().Result;
            var galeriItems = _galeriServices.GetAllAsync().Result;

            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";

            var sitemap = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(ns + "urlset",

                    // Ana sayfa
                    new XElement(ns + "url",
                        new XElement(ns + "loc", baseUrl),
                        new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd")),
                        new XElement(ns + "changefreq", "daily"),
                        new XElement(ns + "priority", "1.0")
                    ),

                    // Hakkımızda
                    new XElement(ns + "url",
                        new XElement(ns + "loc", $"{baseUrl}/Corporate/Vision"),
                        new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd")),
                        new XElement(ns + "changefreq", "monthly"),
                        new XElement(ns + "priority", "0.8")
                    ),
                       new XElement(ns + "url",
                        new XElement(ns + "loc", $"{baseUrl}/Corporate/Mission"),
                        new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd")),
                        new XElement(ns + "changefreq", "monthly"),
                        new XElement(ns + "priority", "0.8")
                    ),

                    // Diğer statik sayfaların hepsini aynı mantıkla ekle...
                    new XElement(ns + "url",
                        new XElement(ns + "loc", $"{baseUrl}/Service/productcategorys"),
                        new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd")),
                        new XElement(ns + "changefreq", "weekly"),
                        new XElement(ns + "priority", "0.9")
                    )
                )
            );

            // Dinamik ürün kategorileri ekle
            if (urunKategorileri != null)
            {
                foreach (var kategori in urunKategorileri)
                {
                    sitemap.Root.Add(
                        new XElement(ns + "url",
                            new XElement(ns + "loc", $"{baseUrl}/Service/productdetail/{kategori.Baslık.ToSlug()}"),
                            new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd")),
                            new XElement(ns + "changefreq", "weekly"),
                            new XElement(ns + "priority", "0.6")
                        )
                    );
                }


                foreach (var kategori in urunKategorileri)
                {
                    sitemap.Root.Add(
                        new XElement(ns + "url",
                            new XElement(ns + "loc", $"{baseUrl}/Service/productdetail/{kategori.BaslıkEn.ToSlug()}"),
                            new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd")),
                            new XElement(ns + "changefreq", "weekly"),
                            new XElement(ns + "priority", "0.6")
                        )
                    );
                }
            }

            // Dinamik galeri sayfaları ekle
            if (galeriItems != null)
            {
                foreach (var galeri in galeriItems)
                {
                    sitemap.Root.Add(
                        new XElement(ns + "url",
                            new XElement(ns + "loc", $"{baseUrl}/Service/productdetail/{galeri.GaleriId}"),
                            new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd")),
                            new XElement(ns + "changefreq", "monthly"),
                            new XElement(ns + "priority", "0.5")
                        )
                    );
                }
            }

            return Content(sitemap.ToString(), "application/xml");
        }

    }
}
