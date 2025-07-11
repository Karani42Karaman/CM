using CM.Core.Model;
 
namespace CM.Core.Service
{
    public interface IMissionService
    {
        void Create(MissionModel model);
        bool Update(MissionModel model);
        bool Remove(Guid id);
        Task<IEnumerable<MissionModel>> GetAllAsync();
        ValueTask<MissionModel> GetAsync(Guid id);
    }
}
