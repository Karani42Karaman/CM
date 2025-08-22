using CM.Core.Dto;
using CM.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace CM.Web.Controllers
{
    public class PriceController : Controller
    {
        private readonly IPriceService _priceService;
        public PriceController(IPriceService priceService)
        {
            _priceService = priceService;
        }

        public IActionResult Index()
        {
            // SEO Meta Tags
            ViewBag.SeoModel = new CM.Web.Models.SeoModel
            {
                Title = "Fiyatlandırma | Cephe Modelleme - Uygun Fiyatlı 3D Modelleme",
                Description = "Cephe Modelleme fiyatlandırma sayfası. 3D modelleme, render ve mimari görselleştirme hizmetlerimizin uygun fiyatları hakkında bilgi alın.",
                Keywords = "fiyatlandırma, 3d modelleme fiyatları, render fiyatları, mimari görselleştirme fiyatları, cephe tasarımı fiyatları",
                CanonicalUrl = "https://www.cephemodelleme.com/Price",
                OgTitle = "Fiyatlandırma | Cephe Modelleme - Uygun Fiyatlı 3D Modelleme",
                OgDescription = "Cephe Modelleme fiyatlandırma sayfası. 3D modelleme, render ve mimari görselleştirme hizmetlerimizin uygun fiyatları hakkında bilgi alın.",
                OgImage = "https://www.cephemodelleme.com/assets/images/logo.png",
                TwitterTitle = "Fiyatlandırma | Cephe Modelleme - Uygun Fiyatlı 3D Modelleme",
                TwitterDescription = "Cephe Modelleme fiyatlandırma sayfası. 3D modelleme, render ve mimari görselleştirme hizmetlerimizin uygun fiyatları hakkında bilgi alın.",
                TwitterImage = "https://www.cephemodelleme.com/assets/images/logo.png",
                StructuredData = @"{
                    ""@context"": ""https://schema.org"",
                    ""@type"": ""PriceSpecification"",
                    ""name"": ""Cephe Modelleme Fiyatlandırma"",
                    ""description"": ""3D modelleme, render ve mimari görselleştirme hizmetleri fiyatları"",
                    ""url"": ""https://www.cephemodelleme.com/Price""
                }"
            };

            var model = _priceService.GetAllAsync().Result.Select(x => new PriceDtoModel
            {
                PackagePrice = x.PackagePrice,
                PackageName = x.PackageName,
                CreateDate = x.CreateDate,
                PackageContent = x.PackageContent?.Split(',').ToList(),
                PackageContentEn = x.PackageContentEn?.Split(',').ToList(),
                PackageNameEn = x.PackageNameEn,
            }
            ).ToList();

            return View(model);
        }
    }
}
