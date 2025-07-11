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
