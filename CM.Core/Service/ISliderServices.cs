using CM.Core.Model;

namespace CM.Core.Service
{
    public  interface ISliderServices
    {
        void Create(SliderModel model);
        bool Update(SliderModel model);
        bool Remove(Guid id);
        Task<IEnumerable<SliderModel>> GetAllAsync();
        ValueTask<SliderModel> GetAsync(Guid id);
    }
}
