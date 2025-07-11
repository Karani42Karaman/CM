using Microsoft.EntityFrameworkCore;
using CM.Core;
using CM.Core.Model;
using CM.Core.Service;
using CM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.Services
{
    public class UrünKategoriServices : IUrünServices
    {
        protected readonly RCVDBContext _context;

        private readonly IUnitOfWork _unitOfWork;

        public UrünKategoriServices(IUnitOfWork unitOfWork, RCVDBContext context)
        {
            this._context = context;
            _unitOfWork = unitOfWork;
        }
        public void UrünCreate(UrünlerModel model)
        {
            if (model != null)
            {
                _unitOfWork.IRepositoriy<UrünlerModel>().CreateAsync(model);
                var a = _unitOfWork.SaveChanges();
            }
        }

        public Task<IEnumerable<UrünlerModel>> UrünGetAllAsync()
        {
            return _unitOfWork.IRepositoriy<UrünlerModel>().GetAllAsync();
        }

        public ValueTask<UrünlerModel> UrünGetAsync(Guid id)
        {
            return _unitOfWork.IRepositoriy<UrünlerModel>().GetAsync(id);
        }

        public void UrünKategoriCreate(UrünKategoriModel model)
        {
            if (model != null)
            {
                _unitOfWork.IRepositoriy<UrünKategoriModel>().CreateAsync(model);
                var a = _unitOfWork.SaveChangesAsync().Result;
            }
        }

        public Task<IEnumerable<UrünKategoriModel>> UrünKategoriGetAllAsync()
        {
            return _unitOfWork.IRepositoriy<UrünKategoriModel>().GetAllAsync();
        }

        public ValueTask<UrünKategoriModel> UrünKategoriGetAsync(Guid id)
        {
            return _unitOfWork.IRepositoriy<UrünKategoriModel>().GetAsync(id);
        }

        public bool UrünKategoriRemove(Guid id)
        {
            _unitOfWork.IRepositoriy<UrünKategoriModel>().Remove(id);
            var result = _unitOfWork.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool UrünKategoriUpdate(UrünKategoriModel model)
        {
            _unitOfWork.IRepositoriy<UrünKategoriModel>().Update(model);
            var result = _unitOfWork.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool UrünUpdate(UrünlerModel model)
        {
            _unitOfWork.IRepositoriy<UrünlerModel>().Update(model);
            var result = _unitOfWork.SaveChanges();
            return result > 0 ? true : false;
        }


        public UrünKategoriModel? UrünKategoriGetIncludeUrün(Guid id)
        {
            return _context.UrünKategoriModels.Include(x => x.UrünlerModel).FirstOrDefaultAsync(x => x.UrünKategorId == id).Result;
        }

        public List<UrünlerModel> UrünGetWord(string word)
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;
            if (currentCulture.Equals("tr-TR"))
            {

                var model = from c in _context.UrünlerModels
                            where EF.Functions.Like(c.Baslik, $"{word}%")
                            select c;
                return model.ToList();
            }
            else
            {
                var model = from c in _context.UrünlerModels
                            where EF.Functions.Like(c.BaslikEn, $"{word}%")
                            select c;
                foreach (var item in model)
                {
                    item.Baslik = item.BaslikEn;
                }
                return model.ToList();
            }

        }

        public List<UrünlerModel> UrünGetKategoriId(Guid id)
        {
            var model = _context.UrünlerModels.Where(x => x.UrünKategoriModelUrünKategorId == id);
            return model.ToList();
        }

        public UrünlerModel? GetUrünId(Guid id)
        {
            return _context.UrünlerModels.FirstOrDefault(x => x.UrünId == id);            
        }
    }
}
