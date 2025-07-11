using CM.Core.Model;

namespace CM.Core.Service
{
    public  interface IRakamServices
    {
        void CreateRakamlar(RakamlarModel model);
        bool UpdateRakamlar(RakamlarModel model);
        bool RemoveRakamlar(Guid id);
        Task<IEnumerable<RakamlarModel>> GetAllRakamlarAsync();
        ValueTask<RakamlarModel> GetRakamlarAsync(Guid id);


        void CreateRakamYani(RakamYaniModel model);
        bool UpdateRakamYani(RakamYaniModel model);
        bool RemoveRakamYani(Guid id);
        Task<IEnumerable<RakamYaniModel>> GetAllRakamYaniAsync();
        ValueTask<RakamYaniModel> GetRakamYaniAsync(Guid id);
    }
}
