using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeace.Admin.Entities
{
    [Table("FileStore")]
    public class FileStoreEntry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string FileName { get; set; }

        [Required]
        public DateTime UploadedOn { get; set; }

    }
}
