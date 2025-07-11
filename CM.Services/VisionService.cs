

using Microsoft.EntityFrameworkCore.ChangeTracking;
using CM.Core;
using CM.Core.Model;
using CM.Core.Service;

namespace CM.Services
{
    public class VisionService : IVisionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public VisionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(VisionModel model)
        {
            try
            {
                _unitOfWork.IRepositoriy<VisionModel>().CreateAsync(model);
                var a = _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task<IEnumerable<VisionModel>> GetAllAsync()
        {
            return _unitOfWork.IRepositoriy<VisionModel>().GetAllAsync();
        }

        public ValueTask<VisionModel> GetAsync(Guid id)
        {
            return _unitOfWork.IRepositoriy<VisionModel>().GetAsync(id);
        }

        public bool Remove(Guid id)
        {
            _unitOfWork.IRepositoriy<VisionModel>().Remove(id);
            return _unitOfWork.SaveChanges() > 0 ? true:false;
        }

        public bool Update(VisionModel model)
        {
            try
            {
                _unitOfWork.IRepositoriy<VisionModel>().Update(model);
                var deger = _unitOfWork.SaveChanges();

                return deger > 0 ? true : false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
