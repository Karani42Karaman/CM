

namespace CM.Core.Dto
{
    public class SliderDto
    {
        public Guid SliderId { get; set; }
        public string SliderBaslik { get; set; }
        public string SliderAltBaslik { get; set; }

        public string SliderBaslikEn { get; set; }
        public string SliderAltBaslikEn { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public string ImageName { get; set; }
        public string ImagePath { get; set; } // Dosya yolu
    }
}
