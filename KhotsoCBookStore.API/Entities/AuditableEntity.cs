using System;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Entities
{
    public abstract class AuditableEntity
    {
        [Required]
        public DateTime CreatedOn { get; set; } = new DateTime();

        [Required]
        public string CreatedBy { get; set; } = "System";

        public DateTime UpdatedOn { get; set; }

        public string UpdatedBy { get; set; }
    }
}