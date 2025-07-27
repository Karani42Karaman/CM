 

namespace CM.Core.Dto
{
    public class RakamYaniDto
    {
        public Guid RakamYaniId { get; set; }
        
        public string Baslik { get; set; }
        public string AltBaslik { get; set; }
        public string Icerik { get; set; }


        public string BaslikEn { get; set; }
        public string AltBaslikEn { get; set; }
        public string IcerikEn { get; set; }


        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public string ImageName { get; set; }
        public string ImagePath { get; set; } // Dosya yolu

    }
}
