using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }

        [StringLength(1000)]
        public string AboutDetail1 { get; set; }

        [StringLength(1000)]
        public string AboutDetail2 { get; set; }

        [StringLength(100)]
        public string AboutImage1 { get; set; }

        [StringLength(100)]
        public string AboutImage2 { get; set; }
    }
}
