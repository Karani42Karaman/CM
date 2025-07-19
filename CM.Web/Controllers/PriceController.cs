using CM.Core.Dto;
using CM.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace CM.Web.Controllers
{
    public class PriceController : Controller
    {
        private readonly IPriceService _priceService;
        public PriceController(IPriceService priceService)
        {
            _priceService = priceService;
        }

        public IActionResult Index()
        {

            var model = _priceService.GetAllAsync().Result.Select(x => new PriceDtoModel
            {
                PackagePrice = x.PackagePrice,
                PackageName = x.PackageName,
                CreateDate = x.CreateDate,
                PackageContent = x.PackageContent?.Split(',').ToList(),
                PackageContentEn = x.PackageContentEn?.Split(',').ToList(),
                PackageNameEn = x.PackageNameEn,
            }
            ).ToList();

            return View(model);
        }
    }
}
