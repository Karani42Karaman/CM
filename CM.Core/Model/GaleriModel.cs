

using System.ComponentModel.DataAnnotations.Schema;

namespace CM.Core.Model
{
    [Table("Galeri")]
    public class GaleriModel: ImageModel
    {
        public Guid GaleriId { get; set; }
         public string Başlık { get; set; }
        public string BaşlıkEn { get; set; }

        public bool Durum { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }


    }
}
