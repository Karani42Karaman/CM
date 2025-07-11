using CM.Core.Model;


namespace CM.Core.Service
{
    public interface IIletişimServices
    {
        void Create(IletişimModel model);
        bool Update(IletişimModel model);
        bool Remove(Guid id);
        Task<IEnumerable<IletişimModel>> GetAllAsync();
        ValueTask<IletişimModel> GetAsync(Guid id);
    }
}
