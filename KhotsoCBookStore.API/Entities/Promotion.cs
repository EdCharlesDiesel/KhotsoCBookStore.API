using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Entities
{
    public class Promotion: AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PromoId { get; set; }  =Guid.NewGuid();
        
        public decimal MinimumRetail { get; set; }

        public decimal MaximumRetail { get; set; }
    }
}