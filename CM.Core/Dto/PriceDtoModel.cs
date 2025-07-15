 

namespace CM.Core.Dto
{
    public class PriceDtoModel
    {

        public Guid PriceId { get; set; }
        public string? PackageName { get; set; }
        public string? PackageNameEn { get; set; }

        public int PackagePrice { get; set; }
        public List<string>? PackageContent { get; set; }
        public List<string>? PackageContentEn { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
