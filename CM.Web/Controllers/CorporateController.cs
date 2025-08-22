using Microsoft.AspNetCore.Mvc;
using CM.Core.Service;

namespace RVC.Web.Controllers
{
    public class CorporateController : Controller
    {
        private readonly IVisionService _visionService;
        private readonly IMissionService _missionService;
 
        public CorporateController(IVisionService visionService, IMissionService missionService)
        {
            _visionService = visionService;
            _missionService = missionService;
        }

        public IActionResult AboutUs()
        {
            // SEO Meta Tags
            ViewBag.SeoModel = new CM.Web.Models.SeoModel
            {
                Title = "Hakkımızda | Cephe Modelleme - Profesyonel Mimari Modelleme",
                Description = "Cephe Modelleme hakkında bilgi edinin. 3D 2D mimari modelleme, render ve görselleştirme alanında uzman ekibimizle tanışın.",
                Keywords = "hakkımızda, cephe modelleme hakkında, 3d modelleme şirketi, mimari görselleştirme firması",
                CanonicalUrl = "https://www.cephemodelleme.com/Corporate/AboutUs",
                OgTitle = "Hakkımızda | Cephe Modelleme - Profesyonel Mimari Modelleme",
                OgDescription = "Cephe Modelleme hakkında bilgi edinin. 3D 2D mimari modelleme, render ve görselleştirme alanında uzman ekibimizle tanışın.",
                OgImage = "https://www.cephemodelleme.com/assets/images/logo.png",
                TwitterTitle = "Hakkımızda | Cephe Modelleme - Profesyonel Mimari Modelleme",
                TwitterDescription = "Cephe Modelleme hakkında bilgi edinin. 3D 2D mimari modelleme, render ve görselleştirme alanında uzman ekibimizle tanışın.",
                TwitterImage = "https://www.cephemodelleme.com/assets/images/logo.png",
                StructuredData = @"{
                    ""@context"": ""https://schema.org"",
                    ""@type"": ""AboutPage"",
                    ""name"": ""Hakkımızda"",
                    ""description"": ""Cephe Modelleme hakkında bilgi"",
                    ""url"": ""https://www.cephemodelleme.com/Corporate/AboutUs""
                }"
            };

            return View();
        }



        public IActionResult Vision()
        {
            var model = _visionService.GetAllAsync().Result.FirstOrDefault();
            return View(model);
        }



        public IActionResult Mission()
        {
            var model = _missionService.GetAllAsync().Result.FirstOrDefault();

            return View(model);
        }
    }
}
