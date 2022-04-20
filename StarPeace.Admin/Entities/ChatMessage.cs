using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeace.Admin.Entities
{
    [Table("ChatMessages")]
    public class ChatMessage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string From { get; set; }
        [Required]
        [StringLength(20)]
        public string To { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime SentOn { get; set; }
    }
}
