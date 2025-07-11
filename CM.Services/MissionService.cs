

using CM.Core;
using CM.Core.Model;
using CM.Core.Service;

namespace CM.Services
{
    public class MissionService : IMissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(MissionModel model)
        {
            try
            {
                _unitOfWork.IRepositoriy<MissionModel>().CreateAsync(model);
                var a = _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public Task<IEnumerable<MissionModel>> GetAllAsync()
        {
            return _unitOfWork.IRepositoriy<MissionModel>().GetAllAsync();
        }

        public ValueTask<MissionModel> GetAsync(Guid id)
        {
            return _unitOfWork.IRepositoriy<MissionModel>().GetAsync(id);
        }

        public bool Remove(Guid id)
        {
            _unitOfWork.IRepositoriy<MissionModel>().Remove(id);
            return _unitOfWork.SaveChanges() > 0 ? true:false;
        }

        public bool Update(MissionModel model)
        {
            try
            {
                _unitOfWork.IRepositoriy<MissionModel>().Update(model);
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
