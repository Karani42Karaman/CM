using CM.Core;
using CM.Core.Model;
using CM.Core.Service;

namespace CM.Services
{
    public class GaleriServices : IGaleriServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public GaleriServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(GaleriModel model)
        {
            try
            {
                _unitOfWork.IRepositoriy<GaleriModel>().CreateAsync(model);
                var a = _unitOfWork.SaveChangesAsync().Result;
            }
            catch (Exception  ex)
            {

                throw;
            }
            
        }

        public Task<IEnumerable<GaleriModel>> GetAllAsync()
        {
            return _unitOfWork.IRepositoriy<GaleriModel>().GetAllAsync();
        }

        public ValueTask<GaleriModel> GetAsync(Guid id)
        {
            return _unitOfWork.IRepositoriy<GaleriModel>().GetAsync(id);
        }

        public bool Remove(Guid id)
        {
            _unitOfWork.IRepositoriy<GaleriModel>().Remove(id);
            return _unitOfWork.SaveChanges() > 0 ? true : false;
        }

        public bool Update(GaleriModel model)
        {
            _unitOfWork.IRepositoriy<GaleriModel>().Update(model);
            return _unitOfWork.SaveChanges() > 0 ? true : false;
        }
    }
}
