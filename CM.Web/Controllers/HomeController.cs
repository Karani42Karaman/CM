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
                            ImageContentType = item.ImageContentType,
                            ImageData = item.ImageData,
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
                        ImageContentType = rakamlarYani.ImageContentType,
                        ImageData = rakamlarYani.ImageData,
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