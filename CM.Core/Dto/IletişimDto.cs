using CM.Core.Model;

namespace CM.Core.Dto
{
    public class IletişimDto
    {
        public FirmaDto FirmaDto { get; set; }
        public IletişimModel Iletişim { get; set; }
        public bool isMail { get; set; }
    }
}
