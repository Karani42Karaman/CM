 

namespace CM.Core.Model
{
    public class PriceModel
    {
        public Guid PriceId { get; set; }
        public string? PackageName { get; set; }
        public string? PackageNameEn { get; set; }

        public int  PackagePrice { get; set; }
        public string? PackageContent { get; set; }
        public string? PackageContentEn { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
