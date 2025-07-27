using CM.Core.Model;


namespace CM.Core.Dto
{
    public  class UrünKategoriDto
    {
        public Guid UrünKategorId { get; set; }
        public string Baslık { get; set; }
        public string BaslıkEn { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public string ImageName { get; set; }
        public string ImagePath { get; set; } // Dosya yolu

        public List<UrünlerModel>? UrünlerModels { get; set; } = new List<UrünlerModel>();

    }
}
