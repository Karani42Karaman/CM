using Microsoft.AspNetCore.Mvc;
using CM.Core.Dto;
using CM.Core.Model;
using CM.Core.Service;

namespace RVC.Web.Controllers
{
    public class UrünController : Controller
    {
        private readonly IUrünServices _urünServices;
        public UrünController(IUrünServices urünServices)
        {
            _urünServices = urünServices;
        }
        public IActionResult ProductCategorys()
        {
            var models = _urünServices.UrünKategoriGetAllAsync().Result;
            return View(models);
        }


        public IActionResult GetProducts(Guid Id)
        {
            var products = new List<UrünDto>();

            var models = _urünServices.UrünGetKategoriId(Id);
 
            

            return View(models);
        }
        public List<UrünlerModel> UrünGetWord(string word)
        {
            var list = _urünServices.UrünGetWord(word);
            return list;
        }

        public IActionResult ProductDetail(Guid Id)
        {
            var dto = new ProductDetailDto();
            var urün = _urünServices.UrünKategoriGetIncludeUrün(Id)?.UrünlerModel?.FirstOrDefault();
            var kategoris = _urünServices.UrünKategoriGetAllAsync().Result;
            dto.UrünlerModel = urün;
            dto.UrünKategoris = kategoris?.ToList();
            return View(dto);
        }
    }
}
