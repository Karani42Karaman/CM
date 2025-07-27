using CM.Core.Model;
 

namespace CM.Core.Service
{
    public interface IVisionService
    {
        void Create(VisionModel model);
        Task<bool> Update(VisionModel model);
        Task<bool> Remove(Guid id);
        Task<IEnumerable<VisionModel>> GetAllAsync();
        ValueTask<VisionModel> GetAsync(Guid id);
    }
}
