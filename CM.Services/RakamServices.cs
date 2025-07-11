using CM.Core;
using CM.Core.Model;
using CM.Core.Service;

namespace CM.Services
{
    public class RakamServices : IRakamServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public RakamServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateRakamlar(RakamlarModel model)
        {
            _unitOfWork.IRepositoriy<RakamlarModel>().CreateAsync(model);
            _unitOfWork.SaveChanges();
        }

        public void CreateRakamYani(RakamYaniModel model)
        {
            _unitOfWork.IRepositoriy<RakamYaniModel>().CreateAsync(model);
            _unitOfWork.SaveChanges();
        }

        public Task<IEnumerable<RakamlarModel>> GetAllRakamlarAsync()
        {
            return _unitOfWork.IRepositoriy<RakamlarModel>().GetAllAsync();
        }

        public Task<IEnumerable<RakamYaniModel>> GetAllRakamYaniAsync()
        {
            return _unitOfWork.IRepositoriy<RakamYaniModel>().GetAllAsync();
        }

        public ValueTask<RakamlarModel> GetRakamlarAsync(Guid id)
        {
            return _unitOfWork.IRepositoriy<RakamlarModel>().GetAsync(id);
        }

        public ValueTask<RakamYaniModel> GetRakamYaniAsync(Guid id)
        {
            return _unitOfWork.IRepositoriy<RakamYaniModel>().GetAsync(id);
        }

        public bool RemoveRakamlar(Guid id)
        {
            _unitOfWork.IRepositoriy<RakamlarModel>().Remove(id);
            return _unitOfWork.SaveChanges()>0?true:false;
        }

        public bool RemoveRakamYani(Guid id)
        {
            _unitOfWork.IRepositoriy<RakamYaniModel>().Remove(id);
            return _unitOfWork.SaveChanges()>0?true:false;
        }

        public bool UpdateRakamlar(RakamlarModel model)
        {
            _unitOfWork.IRepositoriy<RakamlarModel>().Update(model);
            return _unitOfWork.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateRakamYani(RakamYaniModel model)
        {
            _unitOfWork.IRepositoriy<RakamYaniModel>().Update(model);
            return _unitOfWork.SaveChanges()>0?true:false;
        }
    }
}
