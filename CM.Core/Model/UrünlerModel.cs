 using System.ComponentModel.DataAnnotations.Schema;

namespace CM.Core.Model
{
    [Table("Urünler")]
    public class UrünlerModel: ImageModel
    {
        public Guid UrünId { get; set; }
        public string? Baslik { get; set; } 
        public string? BaslikEn { get; set; }

        public string? Içerik { get;set; }
        public string? IçerikEn { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Guid UrünKategoriModelUrünKategorId { get; set; }

        public UrünKategoriModel? UrünKategoriModel { get; set; } = new UrünKategoriModel();
    }
}
