using CM.Core.Model;

namespace CM.Core.Service
{
    public  interface IFirmaServices
    {
        void Create(FirmaModel model);
        bool Update(FirmaModel model);
        bool Remove(Guid id);
        Task<IEnumerable<FirmaModel>> GetAllAsync();
        ValueTask<FirmaModel> GetAsync(Guid id);
    }
}
