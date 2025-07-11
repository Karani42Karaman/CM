 

namespace CM.Core.Model
{
    public  class MissionModel : ImageModel
    {
        public Guid MissionId { get; set; }

        public string Icerik { get; set; }
        public string IcerikEn { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
