using CM.Core;
using CM.Core.Model;
using CM.Core.Service;


namespace CM.Services
{
    public class FirmaServices : IFirmaServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public FirmaServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(FirmaModel model)
        {
            try
            {
                _unitOfWork.IRepositoriy<FirmaModel>().CreateAsync(model);
                var a = _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public Task<IEnumerable<FirmaModel>> GetAllAsync()
        {
            return _unitOfWork.IRepositoriy<FirmaModel>().GetAllAsync();
        }

        public ValueTask<FirmaModel> GetAsync(Guid id)
        {
            return _unitOfWork.IRepositoriy<FirmaModel>().GetAsync(id);
        }

        public bool Remove(Guid id)
        {
            _unitOfWork.IRepositoriy<FirmaModel>().Remove(id);
            return _unitOfWork.SaveChangesAsync().Wait(10);
        }

        public bool Update(FirmaModel model)
        {
            try
            {
                _unitOfWork.IRepositoriy<FirmaModel>().Update(model);
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
