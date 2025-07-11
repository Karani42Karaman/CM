using CM.Core.Model;


namespace CM.Core.Service
{
    public interface IGaleriServices
    {
        void Create(GaleriModel model);
        bool Update(GaleriModel model);
        bool Remove(Guid id);
        Task<IEnumerable<GaleriModel>> GetAllAsync();
        ValueTask<GaleriModel> GetAsync(Guid id);
    }
}
