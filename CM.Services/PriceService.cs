using CM.Core;
using CM.Core.Model;
using CM.Core.Service;

namespace CM.Services
{
    public class PriceService : IPriceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PriceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Create(PriceModel model)
        {
            _unitOfWork.IRepositoriy<PriceModel>().CreateAsync(model);
            _unitOfWork.SaveChanges();
        }

        public Task<IEnumerable<PriceModel>> GetAllAsync()
        {
            return _unitOfWork.IRepositoriy<PriceModel>().GetAllAsync();
        }

        public ValueTask<PriceModel> GetAsync(Guid id)
        {
            return _unitOfWork.IRepositoriy<PriceModel>().GetAsync(id);
        }

        public bool Remove(Guid id)
        {
            _unitOfWork.IRepositoriy<PriceModel>().Remove(id);
            var result = _unitOfWork.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool Update(PriceModel model)
        {
            try
            {
                _unitOfWork.IRepositoriy<PriceModel>().Update(model);
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
