 

namespace CM.Core.Dto
{
    public class VisionModelDto
    {
        public Guid VisionId { get; set; }
        public string IcerikEn { get; set; }

        public string Icerik { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; } // Dosya yolu
    }
}
