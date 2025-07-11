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
            var model = _unitOfWork.IRepositoriy<BelgelerModel>().GetAllAsync().Result;
            return View(model);
        }
    }
}
