namespace CM.Web.Models
{
    public class SeoModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string CanonicalUrl { get; set; }
        public string OgTitle { get; set; }
        public string OgDescription { get; set; }
        public string OgImage { get; set; }
        public string OgType { get; set; } = "website";
        public string TwitterCard { get; set; } = "summary_large_image";
        public string TwitterTitle { get; set; }
        public string TwitterDescription { get; set; }
        public string TwitterImage { get; set; }
        public string StructuredData { get; set; }
    }
}
