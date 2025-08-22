using Microsoft.AspNetCore.Mvc;
using CM.Core;
using CM.Core.Model;

namespace RVC.Web.Controllers
{
    public class GaleriController : Controller
    {

        private IUnitOfWork _unitOfWork;
        public GaleriController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            // SEO Meta Tags
            ViewBag.SeoModel = new CM.Web.Models.SeoModel
            {
                Title = "Galeri | Cephe Modelleme - Projelerimiz ve Çalışmalarımız",
                Description = "Cephe Modelleme galeri sayfasında 3D modelleme, render ve mimari görselleştirme projelerimizi inceleyin. Profesyonel mimari çalışmalarımızı keşfedin.",
                Keywords = "galeri, projeler, 3d modelleme projeleri, render galeri, mimari görselleştirme örnekleri, cephe tasarımı galeri",
                CanonicalUrl = "https://www.cephemodelleme.com/Galeri",
                OgTitle = "Galeri | Cephe Modelleme - Projelerimiz ve Çalışmalarımız",
                OgDescription = "Cephe Modelleme galeri sayfasında 3D modelleme, render ve mimari görselleştirme projelerimizi inceleyin.",
                OgImage = "https://www.cephemodelleme.com/assets/images/logo.png",
                TwitterTitle = "Galeri | Cephe Modelleme - Projelerimiz ve Çalışmalarımız",
                TwitterDescription = "Cephe Modelleme galeri sayfasında 3D modelleme, render ve mimari görselleştirme projelerimizi inceleyin.",
                TwitterImage = "https://www.cephemodelleme.com/assets/images/logo.png",
                StructuredData = @"{
                    ""@context"": ""https://schema.org"",
                    ""@type"": ""ImageGallery"",
                    ""name"": ""Cephe Modelleme Galeri"",
                    ""description"": ""3D modelleme, render ve mimari görselleştirme projeleri"",
                    ""url"": ""https://www.cephemodelleme.com/Galeri""
                }"
            };

            var model = _unitOfWork.IRepositoriy<GaleriModel>().GetAllAsync().Result;
            return View(model);
        }
    }
}
