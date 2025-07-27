

namespace CM.Core.Dto
{
    public class UrünDto
    {
        public Guid UrünId { get; set; }
        public string? Baslik { get; set; }
        public string? BaslikEn { get; set; }

        public string? Içerik { get; set; }
        public  string? IçerikEn { get; set; }
        public DateTime CreateDate { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; } // Dosya yolu
        public Guid UrünKategoriId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
