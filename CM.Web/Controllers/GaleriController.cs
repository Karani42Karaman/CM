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
            var model = _unitOfWork.IRepositoriy<GaleriModel>().GetAllAsync().Result;
            return View(model);
        }
    }
}
