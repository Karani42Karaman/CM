
using CM.Core.Model;

namespace CM.Core.Service
{
    public interface IPriceService
    {
        void Create(PriceModel model);
        bool Update(PriceModel model);
        bool Remove(Guid id);
        Task<IEnumerable<PriceModel>> GetAllAsync();
        ValueTask<PriceModel> GetAsync(Guid id);

    }
}
