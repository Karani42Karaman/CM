using CM.Core.Model;

namespace CM.Core.Dto
{
    public class HomePageDto
    {


        public List<SliderDto>? SliderModel { get; set; }
        
        public RakamlarModel? RakamlarModel { get; set; }
        
        public RakamYaniDto? RakamYaniModel { get; set; }

        public FirmaDto? FirmaModel { get; set;}

        public VisionModel? VisionModel { get; set; }
        public List<UrünKategoriModel>?  KategoriModels { get; set; }
        public List<GaleriModel>?  GaleriModels { get; set; }



    }
}
