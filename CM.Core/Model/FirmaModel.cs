
using System.ComponentModel.DataAnnotations.Schema;

namespace CM.Core.Model
{
    [Table("Firma")]
    public class FirmaModel
    {
        public Guid FirmaId { get; set; }

        public string FirmaAdi { get; set; }
        public string SiteAdresi { get; set; }
        public string Slogan { get; set; }
        public string SloganEn { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adres { get; set; }
        public string FacebookLink { get;set; }
        public string InstagramLink { get; set;}
        public string YoutubeUrl { get; set;}
        public string WhatsappNumber { get; set;}
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
