using CM.Core;
using CM.Core.Model;
using CM.Core.Service;
 
namespace CM.Services
{
    public class SliderServices : ISliderServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public SliderServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void Create(SliderModel model)
        {
            if (model != null)
            {
                _unitOfWork.IRepositoriy<SliderModel>().CreateAsync(model);
                var a = _unitOfWork.SaveChangesAsync().Result;
            }

        }

        public Task<IEnumerable<SliderModel>> GetAllAsync()
        {
            return _unitOfWork.IRepositoriy<SliderModel>().GetAllAsync();
        }

        public ValueTask<SliderModel> GetAsync(Guid id)
        {
            return _unitOfWork.IRepositoriy<SliderModel>().GetAsync(id);
        }

        public bool Remove(Guid id)
        {
            _unitOfWork.IRepositoriy<SliderModel>().Remove(id);
            var result = _unitOfWork.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool Update(SliderModel model)
        {
            _unitOfWork.IRepositoriy<SliderModel>().Update(model);
            var result = _unitOfWork.SaveChanges();
            return result > 0 ? true:false;
        }
    }
}
