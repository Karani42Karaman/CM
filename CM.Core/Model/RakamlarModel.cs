using System.ComponentModel.DataAnnotations.Schema;

namespace CM.Core.Model
{
    [Table("Rakamlar")]
    public class RakamlarModel
    {
        public Guid RakamId { get; set; }
         
        public int MusteriSayi { get; set; }
        public string? MusteriIcon { get; set; }

        public int EkipSayi { get; set; }
        public string? EkipIcon { get; set; }

        public int TecrübeSayi { get; set; }
        public string? TecrübeIcon { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
