using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CM.Core.Dto;
using CM.Core.Model;
using CM.Core.Service;
using RVC.Web.Areas.Admin.Helper;
using System.Xml;
using System.Xml.Linq;
using System.Text;

namespace RVC.Web.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class DashboardController : Controller
    {
        private readonly IBelgelerServices _belgeservice;
        private readonly IGaleriServices _galeriServices;
        private readonly IFirmaServices _firmaServices;
        private readonly ISliderServices _sliderServices;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IRakamServices _rakamServices;
        private readonly IVisionService _visionService;
        private readonly IMissionService _missionService;
        private readonly IUrünServices _urünServices;
        private readonly IPriceService _priceServices;

        public DashboardController(IUrünServices urünServices, IMissionService missionService, IVisionService visionService, IRakamServices rakamServices, ISliderServices sliderServices, IWebHostEnvironment webHostEnvironment, IBelgelerServices belgelerService, IGaleriServices galeriServices, IFirmaServices firmaServices,IPriceService priceService)
        {
            _urünServices = urünServices;
            _visionService = visionService;
            _missionService = missionService;
            _rakamServices = rakamServices;
            _belgeservice = belgelerService;
            _galeriServices = galeriServices;
            _firmaServices = firmaServices;
            _webHostEnvironment = webHostEnvironment;
            _sliderServices = sliderServices;
            _priceServices = priceService;
        }

        #region Belgeler
        public IActionResult Index()
        {

            var firma = _firmaServices.GetAllAsync().Result.ToList();
            return View("~/Areas/Admin/Views/Dashboard/FirmaIndex.cshtml", firma);

        }

        public IActionResult BelgeIndex()
        {

            var belgeler = _belgeservice.GetAllAsync().Result.ToList();

            return View("~/Areas/Admin/Views/Dashboard/Index.cshtml", belgeler);

        }

        [HttpGet]
        public IActionResult CreateBelgeler()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBelgeler(IFormFile imageFile, BelgelerModel belgelerModel)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var stream = imageFile.OpenReadStream())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);


                        belgelerModel.UpdateDate = DateTime.Now;
                        belgelerModel.CreateDate = DateTime.Now;
                        belgelerModel.ImageData = memoryStream.ToArray();
                        belgelerModel.ImageContentType = imageFile.ContentType;
                        belgelerModel.ImageName = imageFile.FileName;
                        belgelerModel.Link = "sadas";

                        _belgeservice.Create(belgelerModel);
                    }
                }
            }
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public IActionResult UpdateBelgeler(Guid Id)
        {
            var model = _belgeservice.GetAsync(Id).Result;
            return View("~/Areas/Admin/Views/Dashboard/UpdateBelgeler.cshtml", model);
        }

        [HttpPost]
        public IActionResult UpdateBelgeler(IFormFile imageFile, BelgelerModel belgelerModel)
        {
            var model = _belgeservice.GetAsync(belgelerModel.BelgelerId).Result;
            model.UpdateDate = DateTime.Now;
            model.Baslik = belgelerModel.Baslik != null ? belgelerModel.Baslik : model.Baslik;
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var stream = imageFile.OpenReadStream())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        if (imageFile != null)
                        {
                            model.ImageData = memoryStream.ToArray();
                            model.ImageContentType = imageFile.ContentType;
                            model.ImageName = imageFile.FileName;
                        }
                        belgelerModel.Link = "sadas";
                    }
                }
            }
            _belgeservice.Update(model);
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public IActionResult DeleteBelgeler(Guid Id)
        {
            _belgeservice.Remove(Id);
            return RedirectToAction("Index", "Dashboard");
        }
        #endregion

        #region Galeri
        [HttpGet]
        public IActionResult GaleriIndex()
        {
            var galeri = _galeriServices.GetAllAsync().Result.ToList();
            return View("~/Areas/Admin/Views/Dashboard/GaleriIndex.cshtml", galeri);
        }

        [HttpGet]
        public IActionResult CreateGaleri()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateGaleri(IFormFile imageFile, GaleriModel galeriModel)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var stream = imageFile.OpenReadStream())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);

                        galeriModel.UpdateDate = DateTime.Now;
                        galeriModel.CreateDate = DateTime.Now;
                        galeriModel.ImageData = memoryStream.ToArray();
                        galeriModel.ImageContentType = imageFile.ContentType;
                        galeriModel.ImageName = imageFile.FileName;
                        galeriModel.Link = "sadas";

                        _galeriServices.Create(galeriModel);
                    }
                }
            }
            return RedirectToAction("GaleriIndex", "Dashboard");
        }

        [HttpGet]
        public IActionResult UpdateGaleri(Guid Id)
        {
            var model = _galeriServices.GetAsync(Id).Result;
            return View("~/Areas/Admin/Views/Dashboard/UpdateGaleri.cshtml", model);
        }

        [HttpPost]
        public IActionResult UpdateGaleri(IFormFile imageFile, GaleriModel galeriModel)
        {
            var model = _galeriServices.GetAsync(galeriModel.GaleriId).Result;
            model.UpdateDate = DateTime.Now;
            model.Başlık = galeriModel.Başlık != null ? galeriModel.Başlık : model.Başlık;
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var stream = imageFile.OpenReadStream())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        if (imageFile != null)
                        {
                            model.ImageData = memoryStream.ToArray();
                            model.ImageContentType = imageFile.ContentType;
                            model.ImageName = imageFile.FileName;
                        }
                        galeriModel.Link = "sadas";
                    }
                }
            }
            _galeriServices.Update(model);
            return RedirectToAction("GaleriIndex", "Dashboard");
        }

        [HttpGet]
        public IActionResult DeleteGaleri(Guid Id)
        {
            _galeriServices.Remove(Id);
            return RedirectToAction("GaleriIndex", "Dashboard");
        }
        #endregion

        #region Firma
        [HttpGet]
        public IActionResult FirmaIndex()
        {
            var firma = _firmaServices.GetAllAsync().Result.ToList();
            return View("~/Areas/Admin/Views/Dashboard/FirmaIndex.cshtml", firma);
        }

        [HttpGet]
        public IActionResult CreateFirma()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFirma(string SloganEn, FirmaModel firmaModel)
        {
            if (firmaModel != null)
            {
                //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
                //XDocument docEn = XDocument.Load(resxFilePathEn);
                //XElement dataElementEn = new XElement("data",
                //    new XAttribute("name", firmaModel.Slogan),
                //    new XElement("value", SloganEn)
                //);
                //docEn.Root.Add(dataElementEn);
                //docEn.Save(resxFilePathEn);


                //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.tr-TR.resx");
                //XDocument docTr = XDocument.Load(resxFilePathTr);
                //XElement dataElementTr = new XElement("data",
                //    new XAttribute("name", firmaModel.Slogan),
                //    new XElement("value", firmaModel.Slogan)
                //);
                //docTr.Root.Add(dataElementTr);
                //docTr.Save(resxFilePathTr);

                firmaModel.SloganEn = SloganEn;
                firmaModel.UpdateDate = DateTime.Now;
                firmaModel.CreateDate = DateTime.Now;
                _firmaServices.Create(firmaModel);
            }
            return RedirectToAction("FirmaIndex", "Dashboard");
        }

        [HttpGet]
        public IActionResult UpdateFirma(Guid Id)
        {
            var model = _firmaServices.GetAsync(Id).Result;
            string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
            string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.tr-TR.resx");
            LanguageCrud languageCrud = new LanguageCrud();
            var sloganEn = languageCrud.FindValueByName(model.Slogan, resxFilePathEn);

            FirmaDto firmaDto = new FirmaDto()
            {
                Adres = model.Adres,
                Slogan = model.Slogan,
                CreateDate = model.CreateDate,
                Email = model.Email,
                FacebookLink = model.FacebookLink,
                FirmaAdi = model.FirmaAdi,
                FirmaId = model.FirmaId,
                InstagramLink = model.InstagramLink,
                PhoneNumber = model.PhoneNumber,
                SiteAdresi = model.SiteAdresi,
                SloganEn = sloganEn,
                UpdateDate = model.UpdateDate,
                WhatsappNumber = model.WhatsappNumber,
                YoutubeUrl = model.YoutubeUrl
            };

            return View("~/Areas/Admin/Views/Dashboard/UpdateFirma.cshtml", firmaDto);
        }

        [HttpPost]
        public IActionResult UpdateFirma([FromForm] FirmaDto firmaModel)
        {
            try
            {
                //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
                //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.tr-TR.resx");

                var model = _firmaServices.GetAsync(firmaModel.FirmaId).Result;
                //firmaModel.UpdateDate = DateTime.Now;

                //LanguageCrud languageCrud = new LanguageCrud();

                //var sloganTr = languageCrud.Update(model.Slogan, firmaModel.Slogan, firmaModel.SloganEn, resxFilePathEn);
                //var sloganEn = languageCrud.Update(model.Slogan, firmaModel.Slogan, firmaModel.Slogan, resxFilePathTr);

                model.Adres = firmaModel.Adres;
                model.Slogan = firmaModel.Slogan;
                model.Email = firmaModel.Email;
                model.FacebookLink = firmaModel.FacebookLink;
                model.FirmaAdi = firmaModel.FirmaAdi;
                model.InstagramLink = firmaModel.InstagramLink;
                model.PhoneNumber = firmaModel.PhoneNumber;
                model.SiteAdresi = firmaModel.SiteAdresi;
                model.UpdateDate = firmaModel.UpdateDate;
                model.WhatsappNumber = firmaModel.WhatsappNumber;
                model.YoutubeUrl = firmaModel.YoutubeUrl;
                model.SloganEn = firmaModel.SloganEn;
                var update = _firmaServices.Update(model);
            }
            catch (Exception rx)
            {
                throw;
            }
            return RedirectToAction("FirmaIndex", "Dashboard");
        }

        [HttpGet]
        public IActionResult DeleteFirma(Guid Id)
        {
            //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
            //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.tr-TR.resx");
            //var model = _firmaServices.GetAsync(Id);
            //LanguageCrud languageCrud = new LanguageCrud();
            //languageCrud.DeleteByName(model.Result.Slogan, resxFilePathTr);
            //languageCrud.DeleteByName(model.Result.Slogan, resxFilePathEn);
            _firmaServices.Remove(Id);
            return RedirectToAction("FirmaIndex", "Dashboard");
        }
        #endregion

        #region Slider
        [HttpGet]
        public IActionResult SliderIndex()
        {
            var slider = _sliderServices.GetAllAsync().Result.ToList();
            return View("~/Areas/Admin/Views/Dashboard/SliderIndex.cshtml", slider);
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateSlider(string SliderBaslikEn, string SliderAltBaslikEn, IFormFile imageFile, SliderModel sliderModel)
        {
            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {


                    using (var stream = imageFile.OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);

                            sliderModel.UpdateDate = DateTime.Now;
                            sliderModel.CreateDate = DateTime.Now;
                            sliderModel.ImageData = memoryStream.ToArray();
                            sliderModel.ImageContentType = imageFile.ContentType;
                            sliderModel.ImageName = imageFile.FileName;
                            sliderModel.SliderAltBaslikEn = SliderAltBaslikEn;
                            sliderModel.SliderBaslikEn = SliderBaslikEn;
                            _sliderServices.Create(sliderModel);
                        }
                    }

                    //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
                    //XDocument docEn = XDocument.Load(resxFilePathEn);
                    //XElement dataElementEn = new XElement("data",
                    //    new XAttribute("name", sliderModel.SliderBaslik),
                    //    new XElement("value", SliderBaslikEn)
                    //);
                    //docEn.Root.Add(dataElementEn);
                    //docEn.Save(resxFilePathEn);


                    //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.tr-TR.resx");
                    //XDocument docTr = XDocument.Load(resxFilePathTr);
                    //XElement dataElementTr = new XElement("data",
                    //    new XAttribute("name", sliderModel.SliderBaslik),
                    //    new XElement("value", sliderModel.SliderBaslik)
                    //);
                    //docTr.Root.Add(dataElementTr);
                    //docTr.Save(resxFilePathTr);

                    //string resxFilePathEn1 = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
                    //XDocument docEn1 = XDocument.Load(resxFilePathEn);
                    //XElement dataElementEn1 = new XElement("data",
                    //    new XAttribute("name", sliderModel.SliderAltBaslik),
                    //    new XElement("value", SliderAltBaslikEn)
                    //);
                    //docEn1.Root.Add(dataElementEn1);
                    //docEn1.Save(resxFilePathEn1);

                    //string resxFilePathTr2 = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.tr-TR.resx");
                    //XDocument docTr2 = XDocument.Load(resxFilePathTr);
                    //XElement dataElementTr2 = new XElement("data",
                    //    new XAttribute("name", sliderModel.SliderAltBaslik),
                    //    new XElement("value", sliderModel.SliderAltBaslik)
                    //);
                    //docTr2.Root.Add(dataElementTr2);
                    //docTr2.Save(resxFilePathTr2);


                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction("SliderIndex", "Dashboard");
        }

        [HttpGet]
        public IActionResult UpdateSlider(Guid Id)
        {
            var model = _sliderServices.GetAsync(Id).Result;
            //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
            //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.tr-TR.resx");
            //LanguageCrud languageCrud = new LanguageCrud();

            //var baslikEn = languageCrud.FindValueByName(model.SliderBaslik, resxFilePathEn);
            //var altBaslikEn = languageCrud.FindValueByName(model.SliderBaslik, resxFilePathEn);

            SliderDto sliderDto = new SliderDto()
            {
                CreateDate = model.CreateDate,
                SliderAltBaslik = model.SliderAltBaslik,
                SliderBaslik = model.SliderBaslik,
                UpdateDate = model.UpdateDate,
                SliderId = model.SliderId,
                SliderAltBaslikEn = model.SliderAltBaslikEn,
                SliderBaslikEn = model.SliderBaslikEn,
                ImageContentType = model.ImageContentType,
                ImageData = model.ImageData,
                ImageName = model.ImageName
            };
            return View("~/Areas/Admin/Views/Dashboard/UpdateSlider.cshtml", sliderDto);
        }

        [HttpPost]
        public IActionResult UpdateSlider([FromForm] IFormFile imageFile, SliderDto sliderDto)
        {
            try
            {
                //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
                //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.tr-TR.resx");

                var model = _sliderServices.GetAsync(sliderDto.SliderId);
                sliderDto.UpdateDate = DateTime.Now;

                //LanguageCrud languageCrud = new LanguageCrud();

                //languageCrud.Update(model.Result.SliderBaslik, sliderDto.SliderBaslik, sliderDto.SliderBaslikEn, resxFilePathEn);
                //languageCrud.Update(model.Result.SliderBaslik, sliderDto.SliderBaslik, sliderDto.SliderBaslik, resxFilePathTr);

                //languageCrud.Update(model.Result.SliderAltBaslik, sliderDto.SliderAltBaslik, sliderDto.SliderAltBaslikEn, resxFilePathEn);
                //languageCrud.Update(model.Result.SliderAltBaslik, sliderDto.SliderAltBaslik, sliderDto.SliderAltBaslik, resxFilePathTr);


                model.Result.SliderAltBaslik = sliderDto.SliderAltBaslik;
                model.Result.SliderBaslik = sliderDto.SliderBaslik;
                model.Result.UpdateDate = DateTime.Now;
                model.Result.SliderAltBaslikEn = sliderDto.SliderAltBaslikEn;
                model.Result.SliderBaslikEn = sliderDto.SliderBaslikEn;
                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var stream = imageFile.OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);
                            if (imageFile != null)
                            {

                                model.Result.ImageContentType = imageFile.ContentType;
                                model.Result.ImageData = memoryStream.ToArray();
                                model.Result.ImageName = imageFile.FileName;
                            }
                        }
                    }
                }
                var update = _sliderServices.Update(model.Result);
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("SliderIndex", "Dashboard");
        }

        [HttpGet]
        public IActionResult DeleteSlider(Guid Id)
        {
            //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
            //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.tr-TR.resx");
           // var model = _sliderServices.GetAsync(Id);
            //LanguageCrud languageCrud = new LanguageCrud();
            //languageCrud.DeleteByName(model.Result.SliderBaslik, resxFilePathTr);
            //languageCrud.DeleteByName(model.Result.SliderBaslik, resxFilePathEn);
            //languageCrud.DeleteByName(model.Result.SliderAltBaslik, resxFilePathTr);
            //languageCrud.DeleteByName(model.Result.SliderAltBaslik, resxFilePathEn);
           var a = _sliderServices.Remove(Id);
            return RedirectToAction("SliderIndex", "Dashboard");
        }
        #endregion

        #region Rakamlar
        [HttpGet]
        public IActionResult RakamlarIndex()
        {
            var rakamlar = _rakamServices.GetAllRakamlarAsync().Result.ToList();
            return View("~/Areas/Admin/Views/Dashboard/RakamlarIndex.cshtml", rakamlar);
        }

        [HttpGet]
        public IActionResult CreateRakamlar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRakamlar(RakamlarModel rakamlarModel)
        {
            rakamlarModel.UpdateDate = DateTime.Now;
            rakamlarModel.CreateDate = DateTime.Now;
            _rakamServices.CreateRakamlar(rakamlarModel);
            return RedirectToAction("RakamlarIndex", "Dashboard");
        }

        [HttpGet]
        public IActionResult UpdateRakamlar(Guid id)
        {
            var model = _rakamServices.GetRakamlarAsync(id).Result;
            return View("~/Areas/Admin/Views/Dashboard/UpdateRakamlar.cshtml", model);
        }

        [HttpPost]
        public IActionResult UpdateRakamlar(RakamlarModel rakamlarModel)
        {
            rakamlarModel.UpdateDate = DateTime.Now;
            var a = _rakamServices.UpdateRakamlar(rakamlarModel);
            return RedirectToAction("RakamlarIndex", "Dashboard");
        }

        [HttpGet]
        public IActionResult DeleteRakamlar(Guid Id)
        {
            _rakamServices.RemoveRakamlar(Id);
            return RedirectToAction("RakamlarIndex", "Dashboard");
        }
        #endregion

        #region RakamlarYani
        [HttpGet]
        public IActionResult RakamlarYaniIndex()
        {
            var model = _rakamServices.GetAllRakamYaniAsync().Result.ToList();
            return View("~/Areas/Admin/Views/Dashboard/RakamlarYaniIndex.cshtml", model);

        }

        [HttpGet]
        public IActionResult CreateRakamlarYani()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRakamlarYani(IFormFile imageFile, RakamYaniDto rakamYaniDto)
        {
            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {


                    using (var stream = imageFile.OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);

                            rakamYaniDto.UpdateDate = DateTime.Now;
                            rakamYaniDto.CreateDate = DateTime.Now;
                            rakamYaniDto.ImageData = memoryStream.ToArray();
                            rakamYaniDto.ImageContentType = imageFile.ContentType;
                            rakamYaniDto.ImageName = imageFile.FileName;

                            var rakamYaniModel = new RakamYaniModel()
                            {
                                AltBaslik = rakamYaniDto.AltBaslik,
                                Baslik = rakamYaniDto.Baslik,
                                CreateDate = DateTime.Now,
                                Icerik = rakamYaniDto.Icerik,
                                ImageContentType = rakamYaniDto.ImageContentType,
                                ImageData = rakamYaniDto.ImageData,
                                ImageName = rakamYaniDto.ImageName,
                                UpdateDate = DateTime.Now,
                                AltBaslikEn = rakamYaniDto.AltBaslikEn,
                                BaslikEn = rakamYaniDto.BaslikEn,
                                IcerikEn = rakamYaniDto.IcerikEn
                            };
                            _rakamServices.CreateRakamYani(rakamYaniModel);
                        }
                    }
                    ////[Baslik]
                    //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
                    //XDocument docEn = XDocument.Load(resxFilePathEn);
                    //XElement dataElementEn = new XElement("data",
                    //    new XAttribute("name", rakamYaniDto.Baslik),
                    //    new XElement("value", rakamYaniDto.BaslikEn)
                    //);
                    //docEn.Root.Add(dataElementEn);
                    //docEn.Save(resxFilePathEn);

                    //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.tr-TR.resx");
                    //XDocument docTr = XDocument.Load(resxFilePathTr);
                    //XElement dataElementTr = new XElement("data",
                    //    new XAttribute("name", rakamYaniDto.Baslik),
                    //    new XElement("value", rakamYaniDto.Baslik)
                    //);
                    //docTr.Root.Add(dataElementTr);
                    //docTr.Save(resxFilePathTr);


                    ////[AltBaslik]
                    //string resxFilePathEn1 = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
                    //XDocument docEn1 = XDocument.Load(resxFilePathEn);
                    //XElement dataElementEn1 = new XElement("data",
                    //    new XAttribute("name", rakamYaniDto.AltBaslik),
                    //    new XElement("value", rakamYaniDto.AltBaslikEn)
                    //);
                    //docEn1.Root.Add(dataElementEn1);
                    //docEn1.Save(resxFilePathEn1);

                    //string resxFilePathTr2 = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.tr-TR.resx");
                    //XDocument docTr2 = XDocument.Load(resxFilePathTr);
                    //XElement dataElementTr2 = new XElement("data",
                    //    new XAttribute("name", rakamYaniDto.AltBaslik),
                    //    new XElement("value", rakamYaniDto.AltBaslik)
                    //);
                    //docTr2.Root.Add(dataElementTr2);
                    //docTr2.Save(resxFilePathTr2);


                    ////[Icerik]
                    //string resxFilePathEn12 = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
                    //XDocument docEn12 = XDocument.Load(resxFilePathEn12);
                    //XElement dataElementEn12 = new XElement("data",
                    //    new XAttribute("name", rakamYaniDto.Icerik),
                    //    new XElement("value", rakamYaniDto.IcerikEn)
                    //);
                    //docEn12.Root.Add(dataElementEn12);
                    //docEn12.Save(resxFilePathEn12);

                    //string resxFilePathTr21 = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.tr-TR.resx");
                    //XDocument docTr21 = XDocument.Load(resxFilePathTr21);
                    //XElement dataElementTr21 = new XElement("data",
                    //    new XAttribute("name", rakamYaniDto.Icerik),
                    //    new XElement("value", rakamYaniDto.Icerik)
                    //);
                    //docTr21.Root.Add(dataElementTr21);
                    //docTr21.Save(resxFilePathTr21);



                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction("RakamlarYaniIndex", "Dashboard");
        }

        [HttpGet]
        public IActionResult UpdateRakamlarYani(Guid Id)
        {
            var model = _rakamServices.GetRakamYaniAsync(Id).Result;
            //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
            //LanguageCrud languageCrud = new LanguageCrud();

            //var baslikEn = languageCrud.FindValueByName(model.Baslik, resxFilePathEn);
            //var altBaslikEn = languageCrud.FindValueByName(model.AltBaslik, resxFilePathEn);
            //var içerikEn = languageCrud.FindValueByName(model.Icerik, resxFilePathEn);

            var dtoModel = new RakamYaniDto()
            {
                Baslik = model.Baslik,
                BaslikEn = model.BaslikEn,
                AltBaslik = model.AltBaslik,
                AltBaslikEn = model.AltBaslikEn,
                Icerik = model.Icerik,
                IcerikEn = model.IcerikEn,
                CreateDate = model.CreateDate,
                UpdateDate = model.UpdateDate,
                ImageContentType = model.ImageContentType,
                ImageData = model.ImageData,
                ImageName = model.ImageName,
                RakamYaniId = model.RakamYaniId
            };

            return View("~/Areas/Admin/Views/Dashboard/UpdateRakamlarYani.cshtml", dtoModel);
        }

        [HttpPost]
        public IActionResult UpdateRakamlarYani([FromForm] IFormFile imageFile, RakamYaniDto rakamYaniDto)
        {
            try
            {
                //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
                //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.tr-TR.resx");

                var model = _rakamServices.GetRakamYaniAsync(rakamYaniDto.RakamYaniId);

                //LanguageCrud languageCrud = new LanguageCrud();

                //languageCrud.Update(model.Result.Baslik, rakamYaniDto.Baslik, rakamYaniDto.BaslikEn, resxFilePathEn);
                //languageCrud.Update(model.Result.Baslik, model.Result.Baslik, model.Result.Baslik, resxFilePathTr);

                //languageCrud.Update(model.Result.AltBaslik, rakamYaniDto.AltBaslik, rakamYaniDto.AltBaslikEn, resxFilePathEn);
                //languageCrud.Update(model.Result.AltBaslik, rakamYaniDto.AltBaslik, rakamYaniDto.AltBaslik, resxFilePathTr);

                //languageCrud.Update(model.Result.Icerik, rakamYaniDto.Icerik, rakamYaniDto.IcerikEn, resxFilePathEn);
                //languageCrud.Update(model.Result.Icerik, rakamYaniDto.Icerik, rakamYaniDto.Icerik, resxFilePathTr);

                model.Result.AltBaslik = rakamYaniDto.AltBaslik;
                model.Result.Baslik = rakamYaniDto.Baslik;
                model.Result.UpdateDate = DateTime.Now;
                model.Result.Icerik = rakamYaniDto.Icerik;
                model.Result.AltBaslikEn = rakamYaniDto.AltBaslikEn;
                model.Result.BaslikEn = rakamYaniDto.BaslikEn;
                model.Result.IcerikEn = rakamYaniDto.IcerikEn;

                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var stream = imageFile.OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);
                            if (imageFile != null)
                            {
                                model.Result.ImageContentType = imageFile.ContentType;
                                model.Result.ImageData = memoryStream.ToArray();
                                model.Result.ImageName = imageFile.FileName;
                            }
                        }
                    }
                }

                var update = _rakamServices.UpdateRakamYani(model.Result);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("RakamlarYaniIndex", "Dashboard");
        }


        [HttpGet]
        public IActionResult DeleteRakamlarYani(Guid Id)
        {
            //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
            //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.tr-TR.resx");
            var model = _rakamServices.GetRakamYaniAsync(Id);
            //LanguageCrud languageCrud = new LanguageCrud();

            //languageCrud.DeleteByName(model.Result.Baslik, resxFilePathTr);
            //languageCrud.DeleteByName(model.Result.Baslik, resxFilePathEn);
            //languageCrud.DeleteByName(model.Result.AltBaslik, resxFilePathTr);
            //languageCrud.DeleteByName(model.Result.AltBaslik, resxFilePathEn);
            //languageCrud.DeleteByName(model.Result.Icerik, resxFilePathTr);
            //languageCrud.DeleteByName(model.Result.Icerik, resxFilePathEn);
            _rakamServices.RemoveRakamYani(Id);
            return RedirectToAction("RakamlarYaniIndex", "Dashboard");
        }

        #endregion

        #region Hakkımızda

        [HttpGet]
        public IActionResult VisionIndex()
        {
            var model = _visionService.GetAllAsync().Result.ToList();
            return View("~/Areas/Admin/Views/Dashboard/VisionIndex.cshtml", model);

        }
        [HttpGet]
        public IActionResult CreateVision()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateVision(IFormFile imageFile, string IcerikEn, VisionModel visionModel)
        {
            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {


                    using (var stream = imageFile.OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);

                            visionModel.UpdateDate = DateTime.Now;
                            visionModel.CreateDate = DateTime.Now;
                            visionModel.ImageData = memoryStream.ToArray();
                            visionModel.ImageContentType = imageFile.ContentType;
                            visionModel.ImageName = imageFile.FileName;
                            visionModel.IcerikEn = IcerikEn;
                            _visionService.Create(visionModel);
                        }
                    }

                    //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Corporate.Vision.en-US.resx");
                    //XDocument docEn = XDocument.Load(resxFilePathEn);
                    //XElement dataElementEn = new XElement("data",
                    //    new XAttribute("name", visionModel.Icerik),
                    //    new XElement("value", IcerikEn)
                    //);
                    //docEn.Root.Add(dataElementEn);
                    //docEn.Save(resxFilePathEn);


                    //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Corporate.Vision.tr-TR.resx");
                    //XDocument docTr = XDocument.Load(resxFilePathTr);
                    //XElement dataElementTr = new XElement("data",
                    //    new XAttribute("name", visionModel.Icerik),
                    //    new XElement("value", visionModel.Icerik)
                    //);
                    //docTr.Root.Add(dataElementTr);
                    //docTr.Save(resxFilePathTr);

                    //string resxFilePathEnHome = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
                    //XDocument docEnHome = XDocument.Load(resxFilePathEnHome);
                    //XElement dataElementEnHome = new XElement("data",
                    //    new XAttribute("name", visionModel.Icerik),
                    //    new XElement("value", IcerikEn)
                    //);
                    //docEnHome.Root.Add(dataElementEnHome);
                    //docEnHome.Save(resxFilePathEnHome);



                    //string resxFilePathTrHome = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.tr-TR.resx");

                    //XDocument doctrHome = XDocument.Load(resxFilePathTrHome);
                    //XElement dataElementtrHome = new XElement("data",
                    //    new XAttribute("name", visionModel.Icerik),
                    //    new XElement("value", IcerikEn)
                    //);
                    //doctrHome.Root.Add(dataElementtrHome);
                    //doctrHome.Save(resxFilePathTrHome);





                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction("VisionIndex", "Dashboard");
        }

        [HttpGet]
        public IActionResult UpdateVision(Guid Id)
        {

            var model = _visionService.GetAsync(Id).Result;
            //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Corporate.Vision.en-US.resx");
            //LanguageCrud languageCrud = new LanguageCrud();

            //var içerikEn = languageCrud.FindValueByName(model.Icerik, resxFilePathEn);


            VisionModelDto sliderDto = new VisionModelDto()
            {
                CreateDate = model.CreateDate,
                UpdateDate = model.UpdateDate,
                VisionId = model.VisionId,
                ImageContentType = model.ImageContentType,
                ImageData = model.ImageData,
                ImageName = model.ImageName,
                Icerik = model.Icerik,
                IcerikEn = model.IcerikEn,

            };
            return View("~/Areas/Admin/Views/Dashboard/UpdateVision.cshtml", sliderDto);
        }

        [HttpPost]
        public IActionResult UpdateVision(IFormFile imageFile, VisionModelDto visionModelDto)
        {

            try
            {
                //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Corporate.Vision.en-US.resx");
                //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Corporate.Vision.tr-TR.resx");

                //string resxFilePathEnHome = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
                //string resxFilePathTrHome = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.tr-TR.resx");

                var model = _visionService.GetAsync(visionModelDto.VisionId);

                //LanguageCrud languageCrud = new LanguageCrud();

                //languageCrud.Update(model.Result.Icerik, visionModelDto.Icerik, visionModelDto.IcerikEn, resxFilePathEn);
                //languageCrud.Update(model.Result.Icerik, visionModelDto.Icerik, visionModelDto.IcerikEn, resxFilePathTr);


                //languageCrud.Update(model.Result.Icerik, visionModelDto.Icerik, visionModelDto.IcerikEn, resxFilePathEnHome);
                //languageCrud.Update(model.Result.Icerik, visionModelDto.Icerik, visionModelDto.IcerikEn, resxFilePathTrHome);

                model.Result.IcerikEn = visionModelDto.IcerikEn;
                model.Result.Icerik = visionModelDto.Icerik;
                model.Result.UpdateDate = DateTime.Now;


                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var stream = imageFile.OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);
                            if (imageFile != null)
                            {
                                model.Result.ImageContentType = imageFile.ContentType;
                                model.Result.ImageData = memoryStream.ToArray();
                                model.Result.ImageName = imageFile.FileName;
                            }
                        }
                    }
                }

                var update = _visionService.Update(model.Result);
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction("VisionIndex", "Dashboard");
        }

        [HttpGet]
        public IActionResult DeleteVision(Guid Id)
        {
            //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Corporate.Vision.en-US.resx");
            //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Corporate.Vision.tr-TR.resx");
            var model = _visionService.GetAsync(Id);
            //LanguageCrud languageCrud = new LanguageCrud();

            //languageCrud.DeleteByName(model.Result.Icerik, resxFilePathTr);
            //languageCrud.DeleteByName(model.Result.Icerik, resxFilePathEn);

            _visionService.Remove(Id);
            return RedirectToAction("VisionIndex", "Dashboard");
        }

        [HttpGet]
        public IActionResult MissionIndex()
        {
            var model = _missionService.GetAllAsync().Result.ToList();
            return View("~/Areas/Admin/Views/Dashboard/MissionIndex.cshtml", model);

        }
        [HttpGet]
        public IActionResult CreateMission()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMission(IFormFile imageFile, string IcerikEn, MissionModel missionModel)
        {
            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {


                    using (var stream = imageFile.OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);

                            missionModel.UpdateDate = DateTime.Now;
                            missionModel.CreateDate = DateTime.Now;
                            missionModel.ImageData = memoryStream.ToArray();
                            missionModel.ImageContentType = imageFile.ContentType;
                            missionModel.ImageName = imageFile.FileName;
                            missionModel.IcerikEn = IcerikEn;
                            _missionService.Create(missionModel);
                        }
                    }

                    //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Corporate.Mission.en-US.resx");
                    //XDocument docEn = XDocument.Load(resxFilePathEn);
                    //XElement dataElementEn = new XElement("data",
                    //    new XAttribute("name", missionModel.Icerik),
                    //    new XElement("value", IcerikEn)
                    //);
                    //docEn.Root.Add(dataElementEn);
                    //docEn.Save(resxFilePathEn);


                    //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Corporate.Mission.tr-TR.resx");
                    //XDocument docTr = XDocument.Load(resxFilePathTr);
                    //XElement dataElementTr = new XElement("data",
                    //    new XAttribute("name", missionModel.Icerik),
                    //    new XElement("value", missionModel.Icerik)
                    //);
                    //docTr.Root.Add(dataElementTr);
                    //docTr.Save(resxFilePathTr);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction("MissionIndex", "Dashboard");
        }

        [HttpGet]
        public IActionResult UpdateMission(Guid Id)
        {

            var model = _missionService.GetAsync(Id).Result;
            //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Corporate.Mission.en-US.resx");
            //LanguageCrud languageCrud = new LanguageCrud();

            //var içerikEn = languageCrud.FindValueByName(model.Icerik, resxFilePathEn);


            MissionModelDto missionModelDto = new MissionModelDto()
            {
                CreateDate = model.CreateDate,
                UpdateDate = model.UpdateDate,
                MissionId = model.MissionId,
                ImageContentType = model.ImageContentType,
                ImageData = model.ImageData,
                ImageName = model.ImageName,
                Icerik = model.Icerik,
                IcerikEn = model.IcerikEn

            };
            return View("~/Areas/Admin/Views/Dashboard/UpdateMission.cshtml", missionModelDto);
        }

        [HttpPost]
        public IActionResult UpdateMission(IFormFile imageFile, VisionModelDto visionModelDto)
        {

            try
            {
                //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Corporate.Mission.en-US.resx");
                //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Corporate.Mission.tr-TR.resx");

                var model = _missionService.GetAsync(visionModelDto.VisionId);

                //LanguageCrud languageCrud = new LanguageCrud();

                //languageCrud.Update(model.Result.Icerik, visionModelDto.Icerik, visionModelDto.IcerikEn, resxFilePathEn);
                //languageCrud.Update(model.Result.Icerik, visionModelDto.Icerik, visionModelDto.Icerik, resxFilePathTr);


                model.Result.Icerik = visionModelDto.Icerik;
                model.Result.UpdateDate = DateTime.Now;
                model.Result.IcerikEn = visionModelDto.IcerikEn;


                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var stream = imageFile.OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);
                            if (imageFile != null)
                            {
                                model.Result.ImageContentType = imageFile.ContentType;
                                model.Result.ImageData = memoryStream.ToArray();
                                model.Result.ImageName = imageFile.FileName;
                            }
                        }
                    }
                }

                var update = _missionService.Update(model.Result);
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction("MissionIndex", "Dashboard");
        }

        [HttpGet]
        public IActionResult DeleteMission(Guid Id)
        {
            //    string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Corporate.Mission.en-US.resx");
            //    string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Corporate.Mission.tr-TR.resx");
            var model = _missionService.GetAsync(Id);
            //LanguageCrud languageCrud = new LanguageCrud();

            //languageCrud.DeleteByName(model.Result.Icerik, resxFilePathTr);
            //languageCrud.DeleteByName(model.Result.Icerik, resxFilePathEn);

            _missionService.Remove(Id);
            return RedirectToAction("MissionIndex", "Dashboard");
        }
        #endregion

        #region Ürünler Kategori
        [HttpGet]
        public IActionResult UrünKategoriIndex()
        {
            var model = _urünServices.UrünKategoriGetAllAsync().Result.ToList();
            return View("~/Areas/Admin/Views/Dashboard/UrünKategoriIndex.cshtml", model);
        }

        [HttpGet]
        public IActionResult CreateUrünKategori()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUrünKategori(IFormFile imageFile, string BaslıkEn, UrünKategoriModel urünKategoriModel)
        {
            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {


                    using (var stream = imageFile.OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);

                            urünKategoriModel.UpdateDate = DateTime.Now;
                            urünKategoriModel.CreateDate = DateTime.Now;
                            urünKategoriModel.ImageData = memoryStream.ToArray();
                            urünKategoriModel.ImageContentType = imageFile.ContentType;
                            urünKategoriModel.ImageName = imageFile.FileName;
                            urünKategoriModel.BaslıkEn = BaslıkEn;
                            _urünServices.UrünKategoriCreate(urünKategoriModel);
                        }
                    }

                    //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Urün.ProductCategorys.en-US.resx");
                    //XDocument docEn = XDocument.Load(resxFilePathEn);
                    //XElement dataElementEn = new XElement("data",
                    //    new XAttribute("name", urünKategoriModel.Baslık),
                    //    new XElement("value", BaslıkEn)
                    //);
                    //docEn.Root.Add(dataElementEn);
                    //docEn.Save(resxFilePathEn);


                    //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Urün.ProductCategorys.tr-TR.resx");
                    //XDocument docTr = XDocument.Load(resxFilePathTr);
                    //XElement dataElementTr = new XElement("data",
                    //    new XAttribute("name", urünKategoriModel.Baslık),
                    //    new XElement("value", urünKategoriModel.Baslık)
                    //);
                    //docTr.Root.Add(dataElementTr);
                    //docTr.Save(resxFilePathTr);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction("UrünKategoriIndex", "Dashboard");
        }

        [HttpGet]
        public IActionResult UpdateUrünKategori(Guid Id)
        {
            var model = _urünServices.UrünKategoriGetIncludeUrün(Id);
            //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Urün.ProductCategorys.en-US.resx");
            //LanguageCrud languageCrud = new LanguageCrud();

            //var baslıkEn = languageCrud.FindValueByName(model.Baslık, resxFilePathEn);

            UrünKategoriDto urünKategoriDto = new UrünKategoriDto()
            {
                CreateDate = model.CreateDate,
                UpdateDate = model.UpdateDate,
                UrünKategorId = model.UrünKategorId,
                ImageContentType = model.ImageContentType,
                ImageData = model.ImageData,
                ImageName = model.ImageName,
                Baslık = model.Baslık,
                BaslıkEn = model.BaslıkEn,
                UrünlerModels = model.UrünlerModel?.ToList()

            };
            return View("~/Areas/Admin/Views/Dashboard/UpdateUrünKategori.cshtml", urünKategoriDto);
        }

        [HttpPost]
        public IActionResult UpdateUrünKategori(IFormFile imageFile, UrünKategoriDto urünKategoriDto)
        {
            try
            {
                //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Urün.ProductCategorys.en-US.resx");
                //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Urün.ProductCategorys.tr-TR.resx");
                var model = _urünServices.UrünKategoriGetIncludeUrün(urünKategoriDto.UrünKategorId);

                //LanguageCrud languageCrud = new LanguageCrud();

                //languageCrud.Update(model.Baslık, urünKategoriDto.Baslık, urünKategoriDto.BaslıkEn, resxFilePathEn);
                //languageCrud.Update(model.Baslık, urünKategoriDto.Baslık, urünKategoriDto.Baslık, resxFilePathTr);

                model.BaslıkEn = urünKategoriDto.BaslıkEn;
                model.Baslık = urünKategoriDto.Baslık;
                model.UpdateDate = DateTime.Now;

                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var stream = imageFile.OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);
                            if (imageFile != null)
                            {
                                model.ImageContentType = imageFile.ContentType;
                                model.ImageData = memoryStream.ToArray();
                                model.ImageName = imageFile.FileName;
                            }
                        }
                    }
                }
                var update = _urünServices.UrünKategoriUpdate(model);
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction("UrünKategoriIndex", "Dashboard");
        }

        [HttpGet]
        public IActionResult DeleteUrünKategori(Guid Id)
        {
            //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Urün.ProductCategorys.en-US.resx");
            //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Urün.ProductCategorys.tr-TR.resx");

            //string resxFilePathEnProductDetail = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Urün.ProductDetail.en-US.resx");
            //string resxFilePathTrProductDetail = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Urün.ProductDetail.tr-TR.resx");

           // var model = _urünServices.UrünKategoriGetIncludeUrün(Id);
            //LanguageCrud languageCrud = new LanguageCrud();

            //languageCrud.DeleteByName(model.Baslık, resxFilePathTr);
            //languageCrud.DeleteByName(model.Baslık, resxFilePathEn);

            //languageCrud.DeleteByName(model.UrünlerModel.FirstOrDefault().Baslik, resxFilePathEnProductDetail);
            //languageCrud.DeleteByName(model.UrünlerModel.FirstOrDefault().Baslik, resxFilePathTrProductDetail);

            //languageCrud.DeleteByName(model.UrünlerModel.FirstOrDefault().Içerik, resxFilePathEnProductDetail);
            //languageCrud.DeleteByName(model.UrünlerModel.FirstOrDefault().Içerik, resxFilePathTrProductDetail);

            _urünServices.UrünKategoriRemove(Id);
            return RedirectToAction("UrünKategoriIndex", "Dashboard");
        }
        #endregion

        #region Ürünler

        [HttpGet]
        public IActionResult UrünIndex(Guid Id)
        {
            var urünList = new List<UrünlerModel>();
            var model = _urünServices.UrünGetKategoriId(Id);
            foreach (var item in model)
            {

                item.UrünKategoriModel.UrünKategorId = Id;
                urünList.Add(item);
            }
            return View("~/Areas/Admin/Views/Dashboard/UrünIndex.cshtml", model);

            //var modelKategrori = _urünServices.UrünKategoriGetIncludeUrün(Id);
            //if (modelKategrori != null)
            //{
            //    var model = new UrünlerModel()
            //    {
            //        UrünId = modelKategrori.UrünlerModel.FirstOrDefault().UrünId,
            //        Baslik = modelKategrori.UrünlerModel.FirstOrDefault().Baslik,
            //        UpdateDate = modelKategrori.UrünlerModel.FirstOrDefault().UpdateDate,
            //        CreateDate = modelKategrori.UrünlerModel.FirstOrDefault().CreateDate,
            //        ImageContentType = modelKategrori.UrünlerModel.FirstOrDefault().ImageContentType,
            //        ImageData = modelKategrori.UrünlerModel.FirstOrDefault().ImageData,
            //        ImageName = modelKategrori.UrünlerModel.FirstOrDefault().ImageName,
            //        Içerik = modelKategrori.UrünlerModel.FirstOrDefault().Içerik,
            //        UrünKategoriModel = modelKategrori

            //    };
            //    return View("~/Areas/Admin/Views/Dashboard/UrünIndex.cshtml", model);
            //}

        }

        [HttpGet]
        public IActionResult CreateUrün(Guid Id)
        {
            UrünDto urünDto = new UrünDto();
            urünDto.UrünKategoriId = Id;
            return View("~/Areas/Admin/Views/Dashboard/CreateUrün.cshtml", urünDto);
        }

        [HttpPost]
        public IActionResult CreateUrün(IFormFile imageFile, UrünDto urünDto)
        {
            try
            {
                var urünlerModel = new UrünlerModel();

                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var stream = imageFile.OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);

                            urünlerModel.UpdateDate = DateTime.Now;
                            urünlerModel.CreateDate = DateTime.Now;
                            urünlerModel.ImageData = memoryStream.ToArray();
                            urünlerModel.ImageContentType = imageFile.ContentType;
                            urünlerModel.ImageName = imageFile.FileName;
                            urünlerModel.Içerik = urünDto.Içerik;
                            urünlerModel.Baslik = urünDto.Baslik;
                            urünlerModel.IçerikEn = urünDto.IçerikEn;
                            urünlerModel.BaslikEn = urünDto.BaslikEn;
                            urünlerModel.UrünKategoriModel = _urünServices.UrünKategoriGetAsync(urünDto.UrünKategoriId).Result;
                            _urünServices.UrünCreate(urünlerModel);
                        }
                    }


                    //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Urün.ProductDetail.en-US.resx");
                    //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Urün.ProductDetail.tr-TR.resx");

                    //XDocument docEn = XDocument.Load(resxFilePathEn);
                    //XElement dataElementEn = new XElement("data",
                    //    new XAttribute("name", urünlerModel.Baslik),
                    //    new XElement("value", urünDto.BaslikEn)
                    //);
                    //docEn.Root.Add(dataElementEn);
                    //docEn.Save(resxFilePathEn);


                    //XDocument docTr = XDocument.Load(resxFilePathTr);
                    //XElement dataElementTr = new XElement("data",
                    //    new XAttribute("name", urünlerModel.Baslik),
                    //    new XElement("value", urünlerModel.Baslik)
                    //);
                    //docTr.Root.Add(dataElementTr);
                    //docTr.Save(resxFilePathTr);

                    //XDocument docEn1 = XDocument.Load(resxFilePathEn);
                    //XElement dataElementEn1 = new XElement("data",
                    //    new XAttribute("name", urünlerModel.Içerik),
                    //    new XElement("value", urünDto.IçerikEn)
                    //);
                    //docEn1.Root.Add(dataElementEn1);
                    //docEn1.Save(resxFilePathEn);


                    //XDocument docTr2 = XDocument.Load(resxFilePathTr);
                    //XElement dataElementTr2 = new XElement("data",
                    //    new XAttribute("name", urünlerModel.Içerik),
                    //    new XElement("value", urünlerModel.Içerik)
                    //);
                    //docTr2.Root.Add(dataElementTr2);
                    //docTr2.Save(resxFilePathTr);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction("UrünKategoriIndex", "Dashboard");
        }

        [HttpGet]
        public IActionResult UpdateUrün(Guid Id)
        {
            var model = _urünServices.UrünGetKategoriId(Id).FirstOrDefault();
            //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Urün.ProductDetail.en-US.resx");
            //LanguageCrud languageCrud = new LanguageCrud();

            //var içerikEn = languageCrud.FindValueByName(model.Içerik, resxFilePathEn);
            //var baslıkEn = languageCrud.FindValueByName(model.Baslik, resxFilePathEn);

            UrünDto urünDto = new UrünDto()
            {
                Baslik = model.Baslik,
                UrünKategoriId = Id,
                BaslikEn = model.BaslikEn,
                CreateDate = model.CreateDate,
                ImageContentType = model.ImageContentType,
                ImageData = model.ImageData,
                ImageName = model.ImageName,
                Içerik = model.Içerik,
                IçerikEn = model.IçerikEn,
                UpdateDate = model.UpdateDate,
                UrünId = model.UrünId

            };
            return View("~/Areas/Admin/Views/Dashboard/UpdateUrün.cshtml", urünDto);
        }


        [HttpPost]
        public IActionResult UpdateUrün(IFormFile imageFile, UrünDto urünDto)
        {
            try
            {
                //string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Urün.ProductDetail.en-US.resx");
                //string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Urün.ProductDetail.tr-TR.resx");

                var model = _urünServices.UrünGetAsync(urünDto.UrünId);

                //LanguageCrud languageCrud = new LanguageCrud();

                //languageCrud.Update(model.Result.Baslik, urünDto.Baslik, urünDto.BaslikEn, resxFilePathEn);
                //languageCrud.Update(model.Result.Baslik, urünDto.Baslik, urünDto.Baslik, resxFilePathTr);

                //languageCrud.Update(model.Result.Içerik, urünDto.Içerik, urünDto.IçerikEn, resxFilePathEn);
                //languageCrud.Update(model.Result.Içerik, urünDto.Içerik, urünDto.Içerik, resxFilePathTr);

                model.Result.Baslik = urünDto.Baslik;
                model.Result.Içerik = urünDto.Içerik;
                model.Result.BaslikEn = urünDto.BaslikEn;
                model.Result.IçerikEn = urünDto.IçerikEn;
                model.Result.UpdateDate = DateTime.Now;


                if (imageFile != null && imageFile.Length > 0)
                {
                    using (var stream = imageFile.OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);
                            if (imageFile != null)
                            {
                                model.Result.ImageContentType = imageFile.ContentType;
                                model.Result.ImageData = memoryStream.ToArray();
                                model.Result.ImageName = imageFile.FileName;
                            }
                        }
                    }
                }

                var update = _urünServices.UrünUpdate(model.Result);
            }
            catch (Exception ex)
            {

                throw;
            }

            return RedirectToAction("UrünKategoriIndex", "Dashboard");
        }

        #endregion

        #region Price
        [HttpGet]
        public IActionResult PriceIndex(Guid Id)
        {
            var urünList = new List<PriceModel>();
            var model = _priceServices.GetAllAsync().Result.ToList();
            
            return View("~/Areas/Admin/Views/Dashboard/PriceIndex.cshtml", model);
        }
        [HttpGet]
        public IActionResult CreatePrice()
        {
            var model = new PriceDtoModel();
            return View("~/Areas/Admin/Views/Dashboard/CreatePrice.cshtml",model);
        }
        [HttpPost]
        public IActionResult CreatePrice(PriceDtoModel model)
        {
            if (model != null)
            {
                var builder = new  StringBuilder();
                if (model.PackageContent != null)
                {
                    foreach (var item in model.PackageContent)
                    {
                        builder.Append(item + ",");
                    }
                }
               

                var builderEn = new StringBuilder();
                if (model.PackageContentEn != null)
                {
                    foreach (var item in model.PackageContentEn)
                    {
                        builderEn.Append(item + ",");
                    }
                }
             

                
                var priceModel = new PriceModel()
                {
                    PackageName = model.PackageName,
                    PackageNameEn = model.PackageNameEn,
                    PackageContentEn = builder.ToString().TrimEnd(','),
                    PackageContent = builderEn.ToString().TrimEnd(','),
                    PackagePrice = model.PackagePrice,
                    UpdateDate = DateTime.Now,
                    CreateDate = DateTime.Now
                };
                _priceServices.Create(priceModel);
            }
            return RedirectToAction("PriceIndex", "Dashboard");
        }
        [HttpGet]
        public IActionResult UpdatePrice(Guid id)
        {

            var model = _priceServices.GetAsync(id);

            var returnModel = new PriceDtoModel()
            {
                PriceId = model.Result.PriceId,
                PackageName = model.Result.PackageName,
                PackageNameEn = model.Result.PackageNameEn,
                PackageContent = model.Result.PackageContent?.Split(',').ToList(),
                PackageContentEn = model.Result.PackageContentEn?.Split(',').ToList(),
                PackagePrice = model.Result.PackagePrice,
                CreateDate = model.Result.CreateDate,
                UpdateDate = model.Result.UpdateDate
            };



            return View("~/Areas/Admin/Views/Dashboard/UpdatePrice.cshtml", returnModel);
        }

        [HttpPost]
        public IActionResult UpdatePrice(PriceDtoModel model)
        {
            if (model != null)
            {
               

                var builder = new StringBuilder();
                if (model.PackageContent != null)
                {
                    foreach (var item in model.PackageContent)
                    {
                        builder.Append(item + ",");
                    }
                }
               

                var builderEn = new StringBuilder();
                if (model.PackageContentEn != null)
                {
                    foreach (var item in model.PackageContentEn)
                    {
                        builderEn.Append(item + ",");
                    }
                }

                var price = _priceServices.GetAsync(model.PriceId).Result;
                price.PriceId = model.PriceId;
                price.PackageName = model.PackageName;
                price.PackageNameEn = model.PackageNameEn;
                price.PackageContentEn = builderEn.ToString().TrimEnd(',');
                price.PackageContent = builder.ToString().TrimEnd(',');
                price.PackagePrice = model.PackagePrice;
                price.UpdateDate = DateTime.Now;
                price.CreateDate = DateTime.Now;
                

                _priceServices.Update(price);
            }
            return RedirectToAction("PriceIndex", "Dashboard");
        }

        public IActionResult DeletePrice(Guid id)
        {
            _priceServices.Remove(id);
            return RedirectToAction("PriceIndex", "Dashboard");
        }

        #endregion
        [HttpGet]
        public IActionResult Dil()
        {
            string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.tr-TR.resx");

            string path = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
            string resxFilePath = path;

            List<DilModelDto> dilList = new List<DilModelDto>();
            using (XmlTextReader reader = new XmlTextReader(resxFilePath))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "data"))
                    {
                        string key = reader.GetAttribute("name");
                        reader.ReadToDescendant("value");
                        string value = reader.ReadElementContentAsString();
                        DilModelDto dilModelDto = new DilModelDto()
                        {
                            Data = value,
                            Key = key
                        };
                        dilList.Add(dilModelDto);
                        Console.WriteLine($"Key: {key}, Value: {value}");
                    }
                }
            }

            using (XmlTextReader reader = new XmlTextReader(resxFilePathTr))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "data"))
                    {
                        string key = reader.GetAttribute("name");
                        reader.ReadToDescendant("value");
                        string value = reader.ReadElementContentAsString();
                        DilModelDto dilModelDto = new DilModelDto()
                        {
                            Veri = value,
                            Anahatar = key
                        };
                        dilList.Add(dilModelDto);
                        Console.WriteLine($"Key: {key}, Value: {value}");
                    }
                }
            }

            return View("~/Areas/Admin/Views/Dashboard/Dil.cshtml", dilList); ;
        }

        [HttpGet]
        public IActionResult CreateDil()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDil(DilModelDto dilModelDto)
        {
            List<DilModelDto> dilList = new List<DilModelDto>();

            try
            {


                //[Baslik]
                string resxFilePathEn = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.en-US.resx");
                XDocument docEn = XDocument.Load(resxFilePathEn);
                XElement dataElementEn = new XElement("data",
                    new XAttribute("name", dilModelDto.Key),
                    new XElement("value", dilModelDto.Data)
                );
                docEn.Root.Add(dataElementEn);
                docEn.Save(resxFilePathEn);

                string resxFilePathTr = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources/Views/Home/Index.tr-TR.resx");
                XDocument docTr = XDocument.Load(resxFilePathTr);
                XElement dataElementTr = new XElement("data",
                    new XAttribute("name", dilModelDto.Key),
                    new XElement("value", dilModelDto.Veri)
                );
                docTr.Root.Add(dataElementTr);
                docTr.Save(resxFilePathTr);
            }
            catch (Exception ex)
            {
                dilList.Add(new DilModelDto()
                {
                    Data = "Hata aldık",
                    Key = ex.Message,
                    Anahatar = ex.StackTrace
                });
            }


            return View("Dil", dilList);
        }


    }

}
