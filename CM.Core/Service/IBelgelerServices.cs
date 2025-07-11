using CM.Core.Model;
namespace CM.Core.Service
{
    public  interface IBelgelerServices
    {
        void Create(BelgelerModel model);
        bool Update(BelgelerModel model);
        bool Remove(Guid id);
        Task<IEnumerable<BelgelerModel>> GetAllAsync();
        ValueTask<BelgelerModel> GetAsync(Guid id);
    }
}
