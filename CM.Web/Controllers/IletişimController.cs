using Microsoft.AspNetCore.Mvc;
using CM.Core.Dto;
using CM.Core.Model;
using CM.Core.Service;
using System.Net;
using System.Net.Mail;

namespace RVC.Web.Controllers
{
    public class IletişimController : Controller
    {
        private readonly IFirmaServices _firmaServices;
        public IletişimController(IFirmaServices firmaServices)
        {
            _firmaServices = firmaServices;
        }
        public IActionResult Index()
        {
            IletişimDto ıletişimDto = new IletişimDto();
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
            ıletişimDto.FirmaDto = firma;
            #endregion
            return View(ıletişimDto);
        }

        [HttpPost]
        public IActionResult SendMail(IletişimModel? ıletişimModel)
        {
            IletişimDto ıletişimDto = new IletişimDto();

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(ıletişimModel.Email);
            mailMessage.To.Add("info@rcvvalve.com");
            mailMessage.Subject = $"RCVVALVE - Müşteri-Ileti {ıletişimModel.PhoneNumber}";
            mailMessage.Body = ıletişimModel.Message;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "mt-odin-win.guzelhosting.com";
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("info@rcvvalve.com", "xbG3pFSQg4sgXA5");
            smtpClient.EnableSsl = false;
            IletişimModel model = new IletişimModel();
            try
            {

                smtpClient.Send(mailMessage);
                model.Durum = true;
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
                ıletişimDto.FirmaDto = firma;
            }
            catch (Exception ex)
            {
                model.Durum = false;
                Console.WriteLine("Error: " + ex.Message);
            }
            ıletişimDto.Iletişim = model;
            ıletişimDto.isMail = true;
            return View("Index", ıletişimDto);

        }


    }
}
