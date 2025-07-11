using CM.Core;
using CM.Core.Model;
using CM.Core.Service;

namespace CM.Services
{
    public class BelgelerService : IBelgelerServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public BelgelerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void Create(BelgelerModel model)
        {
            if (model != null)
            {
                _unitOfWork.IRepositoriy<BelgelerModel>().CreateAsync(model);
                _unitOfWork.SaveChangesAsync().Wait();
            }

        }

        public Task<IEnumerable<BelgelerModel>> GetAllAsync()
        {
            return _unitOfWork.IRepositoriy<BelgelerModel>().GetAllAsync();
        }

        public ValueTask<BelgelerModel> GetAsync(Guid id)
        {
            return _unitOfWork.IRepositoriy<BelgelerModel>().GetAsync(id);
        }

        public bool Remove(Guid id)
        {
            _unitOfWork.IRepositoriy<BelgelerModel>().Remove(id);
            var result = _unitOfWork.SaveChangesAsync().Wait(10);
            return result;
        }

        public bool Update(BelgelerModel model)
        {
            try
            {
                _unitOfWork.IRepositoriy<BelgelerModel>().Update(model);
                _unitOfWork.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {

                return false;
            }
           
            return true;
        }
    }
}
