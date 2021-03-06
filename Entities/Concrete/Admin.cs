using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [StringLength(500)]
        public string UserName { get; set; }

        [StringLength(500)]
        public string Password { get; set; }

        [StringLength(1)]
        public string Role { get; set; }
    }
}
