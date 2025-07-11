using System.ComponentModel.DataAnnotations.Schema;

namespace CM.Core.Model
{
    [Table("Slider")]
    public class SliderModel: ImageModel
    {
        public Guid SliderId { get; set; }
        public string SliderBaslik { get; set; }
        public string SliderBaslikEn { get; set; }

        public string SliderAltBaslik { get; set; }

        public string SliderAltBaslikEn { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
