

using System.ComponentModel.DataAnnotations.Schema;

namespace CM.Core.Model
{
    [Table("Iletisim")]
    public class IletişimModel
    {
        public Guid IletisimId { get; set; }
        public string Name { get; set; }
        public string SurName{ get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public bool Durum { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
