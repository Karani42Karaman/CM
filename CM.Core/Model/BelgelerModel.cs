
using System.ComponentModel.DataAnnotations.Schema;

namespace CM.Core.Model
{
    [Table("Belgeler")]
    public class BelgelerModel: ImageModel
    {
        public Guid BelgelerId { get; set; }
        public string Baslik { get; set; }
        public string BaslikEn { get; set; }

        public string Link { get; set; } 
        public bool Durum { get;set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
