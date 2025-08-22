using Microsoft.AspNetCore.Mvc;
using CM.Core;
using CM.Core.Model;

namespace RVC.Web.Controllers
{
    public class BelgelerController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public BelgelerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            // SEO Meta Tags
            ViewBag.SeoModel = new CM.Web.Models.SeoModel
            {
                Title = "Belgeler | Cephe Modelleme - Sertifikalar ve Belgelerimiz",
                Description = "Cephe Modelleme belgeler ve sertifikalar sayfası. Kalite belgelerimiz, sertifikalarımız ve referanslarımızı inceleyin.",
                Keywords = "belgeler, sertifikalar, kalite belgeleri, cephe modelleme belgeleri, mimari görselleştirme sertifikaları",
                CanonicalUrl = "https://www.cephemodelleme.com/Belgeler",
                OgTitle = "Belgeler | Cephe Modelleme - Sertifikalar ve Belgelerimiz",
                OgDescription = "Cephe Modelleme belgeler ve sertifikalar sayfası. Kalite belgelerimiz, sertifikalarımız ve referanslarımızı inceleyin.",
                OgImage = "https://www.cephemodelleme.com/assets/images/logo.png",
                TwitterTitle = "Belgeler | Cephe Modelleme - Sertifikalar ve Belgelerimiz",
                TwitterDescription = "Cephe Modelleme belgeler ve sertifikalar sayfası. Kalite belgelerimiz, sertifikalarımız ve referanslarımızı inceleyin.",
                TwitterImage = "https://www.cephemodelleme.com/assets/images/logo.png",
                StructuredData = @"{
                    ""@context"": ""https://schema.org"",
                    ""@type"": ""WebPage"",
                    ""name"": ""Belgeler ve Sertifikalar"",
                    ""description"": ""Cephe Modelleme belgeler ve sertifikalar"",
                    ""url"": ""https://www.cephemodelleme.com/Belgeler""
                }"
            };

            var model = _unitOfWork.IRepositoriy<BelgelerModel>().GetAllAsync().Result;
            return View(model);
        }
    }
}
