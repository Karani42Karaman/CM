using CM.Core.Model;


namespace CM.Core.Service
{
    /// <summary>
    /// ürünler ile ilgili tüm olaylar burda dönecek kategorisi de dahil
    /// </summary>
    public interface IUrünServices
    {
        void UrünCreate(UrünlerModel model);
        bool UrünUpdate(UrünlerModel model);
        Task<IEnumerable<UrünlerModel>> UrünGetAllAsync();
        ValueTask<UrünlerModel> UrünGetAsync(Guid id);
        List<UrünlerModel> UrünGetKategoriId(Guid id);


        UrünKategoriModel? UrünKategoriGetIncludeUrün(string name);

        void UrünKategoriCreate(UrünKategoriModel model);
        bool UrünKategoriUpdate(UrünKategoriModel model);
        bool UrünKategoriRemove(Guid id);
        Task<IEnumerable<UrünKategoriModel>> UrünKategoriGetAllAsync();
        ValueTask<UrünKategoriModel> UrünKategoriGetAsync(Guid id);

        public List<UrünlerModel> UrünGetWord(string word);
        public UrünlerModel GetUrünId(Guid id);
    }
}
