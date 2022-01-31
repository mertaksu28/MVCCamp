using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingId { get; set; }

        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }

        //İlişkiler
        public int CategoryId { get; set; } //Heading Tablomun içinde CategoryId isminde bir tane sütun olacak
        public virtual Category Category { get; set; } //Virtual; demek ki bir sınıftan değer alıcam demek. Sen benim category sınıfım ile ilişkili olacaksın demek

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        public ICollection<Content> Contents; // Content i Karşılayan alanım
    }
}
