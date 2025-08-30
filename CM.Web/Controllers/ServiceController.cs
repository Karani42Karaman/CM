using Microsoft.AspNetCore.Mvc;
using CM.Core.Dto;
using CM.Core.Model;
using CM.Core.Service;

namespace RVC.Web.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IUrünServices _urünServices;
        public ServiceController(IUrünServices urünServices)
        {
            _urünServices = urünServices;
        }
        public IActionResult ProductCategorys()
        {
            // SEO Meta Tags
            ViewBag.SeoModel = new CM.Web.Models.SeoModel
            {
                Title = "Hizmetlerimiz | Cephe Modelleme - 3D 2D Mimari Modelleme",
                Description = "Cephe Modelleme hizmetlerimiz: 3D modelleme, 2D modelleme, render alma, mimari görselleştirme, dış cephe tasarımı ve animasyon hizmetleri.",
                Keywords = "hizmetler, 3d modelleme hizmetleri, 2d modelleme, render hizmetleri, mimari görselleştirme, cephe tasarımı",
                CanonicalUrl = "https://www.cephemodelleme.com/Service",
                OgTitle = "Hizmetlerimiz | Cephe Modelleme - 3D 2D Mimari Modelleme",
                OgDescription = "Cephe Modelleme hizmetlerimiz: 3D modelleme, 2D modelleme, render alma, mimari görselleştirme, dış cephe tasarımı ve animasyon hizmetleri.",
                OgImage = "https://www.cephemodelleme.com/assets/images/logo.png",
                TwitterTitle = "Hizmetlerimiz | Cephe Modelleme - 3D 2D Mimari Modelleme",
                TwitterDescription = "Cephe Modelleme hizmetlerimiz: 3D modelleme, 2D modelleme, render alma, mimari görselleştirme, dış cephe tasarımı ve animasyon hizmetleri.",
                TwitterImage = "https://www.cephemodelleme.com/assets/images/logo.png",
                StructuredData = @"{
                    ""@context"": ""https://schema.org"",
                    ""@type"": ""Service"",
                    ""name"": ""Mimari Modelleme ve Görselleştirme Hizmetleri"",
                    ""description"": ""3D ve 2D mimari modelleme, render alma, dış cephe tasarımı ve görselleştirme hizmetleri"",
                    ""provider"": {
                        ""@type"": ""Organization"",
                        ""name"": ""Cephe Modelleme""
                    },
                    ""serviceType"": ""Mimari Modelleme ve Görselleştirme""
                }"
            };

            var models = _urünServices.UrünKategoriGetAllAsync().Result;
            return View(models);
        }


        public IActionResult GetProducts(Guid Id)
        {
            var products = new List<UrünDto>();

            var models = _urünServices.UrünGetKategoriId(Id);
 
            

            return View(models);
        }
        public List<UrünlerModel> UrünGetWord(string word)
        {
            var list = _urünServices.UrünGetWord(word);
            return list;
        }
        [Route("service/productdetail/{data}")]
        public IActionResult ProductDetail(string data)
        {
            var dto = new ProductDetailDto();
            var urün = _urünServices.UrünKategoriGetIncludeUrün(data)?.UrünlerModel?.FirstOrDefault();
            var kategoris = _urünServices.UrünKategoriGetAllAsync().Result;
            dto.UrünlerModel = urün;
            dto.UrünKategoris = kategoris?.ToList();
            return View(dto);
        }
    }
}
