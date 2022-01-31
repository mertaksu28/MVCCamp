using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
        public bool Status { get; set; }

        //İlişkiler
        //ICollection: Bu sınıfa bağlı olarak bir koleksiyon oluşturucaz demek
        public ICollection<Heading> Headings { get; set; } //Bire çok bir ilişki kurulacak. Sen benim heading sınıfım ile ilişkili olacaksın demek
    }
}
