using CM.Core.Model;


namespace CM.Core.Service
{
    /// <summary>
    /// hakkımızda kısmının db si yok onu oluşuturacağız
    /// </summary>
    public interface ICorporateServices
    {
        void Create(SliderModel model);
        bool Update(SliderModel model);
        bool Remove(Guid id);
        Task<IEnumerable<SliderModel>> GetAllAsync();
        ValueTask<SliderModel> GetAsync(Guid id);
    }
}
