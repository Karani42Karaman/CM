using CM.Core;
using CM.Core.Model;
using CM.Core.Service;

namespace CM.Services
{
    public class IletişimServices : IIletişimServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public IletişimServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(IletişimModel model)
        {
            _unitOfWork.IRepositoriy<IletişimModel>().CreateAsync(model);
            _unitOfWork.SaveChangesAsync();
        }

        public Task<IEnumerable<IletişimModel>> GetAllAsync()
        {
            return _unitOfWork.IRepositoriy<IletişimModel>().GetAllAsync();
        }

        public ValueTask<IletişimModel> GetAsync(Guid id)
        {
            return _unitOfWork.IRepositoriy<IletişimModel>().GetAsync(id);
        }

        public bool Remove(Guid id)
        {
            _unitOfWork.IRepositoriy<IletişimModel>().Remove(id);
            return _unitOfWork.SaveChangesAsync().Wait(10);            
        }

        public bool Update(IletişimModel model)
        {
            _unitOfWork.IRepositoriy<IletişimModel>().Update(model);
            return _unitOfWork.SaveChangesAsync().Wait(10);
        }
    }
}
