using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string SenderMail { get; set; }

        [StringLength(50)]
        public string ReceiverMail { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        public string Content { get; set; }

        public DateTime History { get; set; }
    }
}
