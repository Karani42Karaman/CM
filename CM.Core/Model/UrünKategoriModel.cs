using System.ComponentModel.DataAnnotations.Schema;
namespace CM.Core.Model
{
    [Table("UrünKategori")]
    public class UrünKategoriModel: ImageModel
    {
        public Guid UrünKategorId { get; set; }
        public string Baslık { get; set; }
        public string? BaslıkEn { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public ICollection<UrünlerModel>? UrünlerModel { get; set; } = new List<UrünlerModel>();
    }
}
