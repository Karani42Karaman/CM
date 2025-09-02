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
        public async Task<IActionResult> Index()
        {
            try
            {
                var baseUrl = $"{Request.Scheme}://{Request.Host}";

                var urunKategorileri = await _urünServices.UrünKategoriGetAllAsync();
                var galeriItems = await _galeriServices.GetAllAsync();

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

                        // Statik sayfalar
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
                        new XElement(ns + "url",
                            new XElement(ns + "loc", $"{baseUrl}/Service/productcategorys"),
                            new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd")),
                            new XElement(ns + "changefreq", "weekly"),
                            new XElement(ns + "priority", "0.9")
                        ),
                        new XElement(ns + "url",
                            new XElement(ns + "loc", $"{baseUrl}/Iletişim"),
                            new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd")),
                            new XElement(ns + "changefreq", "monthly"),
                            new XElement(ns + "priority", "0.7")
                        ),
                        new XElement(ns + "url",
                            new XElement(ns + "loc", $"{baseUrl}/Price"),
                            new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd")),
                            new XElement(ns + "changefreq", "weekly"),
                            new XElement(ns + "priority", "0.8")
                        )
                    )
                );

                // Dinamik ürün kategorileri ekle
                if (urunKategorileri != null && urunKategorileri.Any())
                {
                    foreach (var kategori in urunKategorileri)
                    {
                        // Türkçe URL'ler
                        if (!string.IsNullOrEmpty(kategori.Baslık))
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

                        // İngilizce URL'ler
                        if (!string.IsNullOrEmpty(kategori.BaslıkEn))
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
                }

                // Dinamik galeri sayfaları ekle
                if (galeriItems != null && galeriItems.Any())
                {
                    foreach (var galeri in galeriItems)
                    {
                        sitemap.Root.Add(
                            new XElement(ns + "url",
                                new XElement(ns + "loc", $"{baseUrl}/Galeri/Detail/{galeri.GaleriId}"),
                                new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd")),
                                new XElement(ns + "changefreq", "monthly"),
                                new XElement(ns + "priority", "0.5")
                            )
                        );
                    }
                }

                // XML'i declaration ile birlikte döndür
                var xmlContent = sitemap.Declaration + Environment.NewLine + sitemap.ToString();
                return Content(xmlContent, "application/xml");
            }
            catch (Exception ex)
            {
                // Hata durumunda basit sitemap döndür
                XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
                var basicSitemap = new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement(ns + "urlset",
                        new XElement(ns + "url",
                            new XElement(ns + "loc", $"{Request.Scheme}://{Request.Host}"),
                            new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd")),
                            new XElement(ns + "changefreq", "daily"),
                            new XElement(ns + "priority", "1.0")
                        )
                    )
                );

                var xmlContent = basicSitemap.Declaration + Environment.NewLine + basicSitemap.ToString();
                return Content(xmlContent, "application/xml");
            }
        }
    }
}