using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using CM.Core.Dto;
using CM.Core.Service;
using RVC.Web.Models;
using System.Diagnostics;
using System.Globalization;
using System.Resources;

namespace RVC.Web.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBelgelerServices _belgeservice;
        private readonly IGaleriServices _galeriServices;
        private readonly IFirmaServices _firmaServices;
        private readonly ISliderServices _sliderServices;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IRakamServices _rakamServices;
        private readonly IVisionService _visionService;
        private readonly IUrünServices _urünServices;



        public HomeController(ILogger<HomeController> logger,IUrünServices urünServices,IVisionService visionService, IRakamServices rakamServices, ISliderServices sliderServices, IWebHostEnvironment webHostEnvironment, IBelgelerServices belgelerService, IGaleriServices galeriServices, IFirmaServices firmaServices)
        {
            _urünServices = urünServices;
            _visionService = visionService;
            _rakamServices = rakamServices;
            _belgeservice = belgelerService;
            _galeriServices = galeriServices;
            _firmaServices = firmaServices;
            _webHostEnvironment = webHostEnvironment;
            _sliderServices = sliderServices;
            _logger = logger;
        }


        [HttpGet("SetLanguage")]
        public IActionResult SetLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
             CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
             new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddHours(2) });
          
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Index()
        {
            try
            {
                // SEO Meta Tags
                ViewBag.SeoModel = new CM.Web.Models.SeoModel
                {
                    Title = "Cephe Modelleme | 3D 2D Mimari Modelleme, Render ve Görselleştirme",
                    Description = "Cephe Modelleme: 3D ve 2D mimari modelleme, render alma, dış cephe tasarımı ve görselleştirme hizmetleri. Profesyonel mimari animasyon, proje sunumu ve dijital reklam çözümleri.",
                    Keywords = "cephe modelleme, 3d modelleme, 2d modelleme, render, mimari görselleştirme, dış cephe tasarımı, mimari animasyon, proje sunumu, dijital reklam, architectural visualization, facade modeling, architectural rendering",
                    CanonicalUrl = "https://www.cephemodelleme.com/",
                    OgTitle = "Cephe Modelleme | 3D 2D Mimari Modelleme, Render ve Görselleştirme",
                    OgDescription = "Cephe Modelleme: 3D ve 2D mimari modelleme, render alma, dış cephe tasarımı ve görselleştirme hizmetleri.",
                    OgImage = "https://www.cephemodelleme.com/assets/images/logo.png",
                    TwitterTitle = "Cephe Modelleme | 3D 2D Mimari Modelleme, Render ve Görselleştirme",
                    TwitterDescription = "Cephe Modelleme: 3D ve 2D mimari modelleme, render alma, dış cephe tasarımı ve görselleştirme hizmetleri.",
                    TwitterImage = "https://www.cephemodelleme.com/assets/images/logo.png",
                    StructuredData = @"{
                        ""@context"": ""https://schema.org"",
                        ""@type"": ""WebSite"",
                        ""name"": ""Cephe Modelleme"",
                        ""url"": ""https://www.cephemodelleme.com/"",
                        ""description"": ""3D ve 2D mimari modelleme, render alma, dış cephe tasarımı ve görselleştirme hizmetleri."",
                        ""potentialAction"": {
                            ""@type"": ""SearchAction"",
                            ""target"": ""https://www.cephemodelleme.com/search?q={search_term_string}"",
                            ""query-input"": ""required name=search_term_string""
                        }
                    }"
                };
                #region Firma
                var firmaModel = _firmaServices.GetAllAsync().Result.FirstOrDefault();
                FirmaDto firma = null;
                if (firmaModel != null)
                {
                    firma = new FirmaDto()
                    {
                        Adres = firmaModel.Adres,
                        Email = firmaModel.Email,
                        FacebookLink = firmaModel.FacebookLink,
                        FirmaAdi = firmaModel.FirmaAdi,
                        InstagramLink = firmaModel.InstagramLink,
                        PhoneNumber = firmaModel.PhoneNumber,
                        Slogan = firmaModel.Slogan,
                        SloganEn = firmaModel.SloganEn,
                        WhatsappNumber = firmaModel.WhatsappNumber,
                    };
                }

                #endregion

                #region Slider
                var slider = new List<SliderDto>();
                var sliders = _sliderServices.GetAllAsync().Result;
                if (sliders != null)
                {
                    foreach (var item in sliders)
                    {
                        slider.Add(new SliderDto()
                        {
                            ImagePath = item.ImagePath,
                            ImageName = item.ImageName,
                            SliderAltBaslik = item.SliderAltBaslik,
                            SliderAltBaslikEn = item.SliderAltBaslikEn,
                            SliderBaslik = item.SliderBaslik,
                            SliderBaslikEn=item.SliderBaslikEn
                        });
                    }
                }

                #endregion

                #region Rakamlar
                var rakamlar = _rakamServices.GetAllRakamlarAsync().Result.FirstOrDefault() != null ? _rakamServices.GetAllRakamlarAsync().Result.FirstOrDefault() : null;
                #endregion

                #region RakamlarYani

                var rakamlarYani = _rakamServices.GetAllRakamYaniAsync().Result.FirstOrDefault();
                RakamYaniDto rakamlarYaniDto = null;
                if (rakamlarYani != null)
                {
                    rakamlarYaniDto = new RakamYaniDto()
                    {
                        Baslik = rakamlarYani.Baslik,
                        AltBaslik = rakamlarYani.AltBaslik,
                        AltBaslikEn=rakamlarYani.AltBaslikEn,
                        Icerik = rakamlarYani.Icerik,
                        IcerikEn=rakamlarYani.IcerikEn,
                        ImagePath = rakamlarYani.ImagePath,
                        ImageName = rakamlarYani.ImageName,
                    };
                }

                #endregion

                var model = new HomePageDto()
                {
                    FirmaModel = firma,
                    SliderModel = slider,
                    RakamlarModel = rakamlar,
                    RakamYaniModel = rakamlarYaniDto,
                    VisionModel = _visionService.GetAllAsync().Result.FirstOrDefault(),
                    KategoriModels = _urünServices.UrünKategoriGetAllAsync().Result.ToList(),
                    GaleriModels=_galeriServices.GetAllAsync().Result.ToList(),
                };

                return View("Index", model);
            }
            catch (Exception)
            {

                throw;
            }


        }

        public FirmaDto Firma()
        {
            #region Firma
            var firmaModel = _firmaServices.GetAllAsync().Result.FirstOrDefault();
            FirmaDto firma = null;
            if (firmaModel != null)
            {
                firma = new FirmaDto()
                {
                    Adres = firmaModel.Adres,
                    Email = firmaModel.Email,
                    FacebookLink = firmaModel.FacebookLink,
                    FirmaAdi = firmaModel.FirmaAdi,
                    InstagramLink = firmaModel.InstagramLink,
                    PhoneNumber = firmaModel.PhoneNumber,
                    Slogan = firmaModel.Slogan,
                    WhatsappNumber = firmaModel.WhatsappNumber,
                };
            }

            #endregion

            return firma;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}