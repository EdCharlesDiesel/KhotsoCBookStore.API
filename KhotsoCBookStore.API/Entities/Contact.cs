using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Entities
{
    [Table("Contacts")]
    public class Contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ContactId { get; set; }
        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(40)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string MobilePhone { get; set; }
    }

    public class BusinessContact:Contact
    {
        [StringLength(20)]
        public string CompanyName { get; set; }
        
        [StringLength(20)]
        public string Designation { get; set; }
        
        [StringLength(20)]
        public string  BusinessPhone { get; set; }
    }
    public class ProfessionalContact : Contact
    {
        [StringLength(20)]
        public string Service { get; set; }
        
        [StringLength(20)]
        public string Address { get; set; }

        [StringLength(100)]        
        public string LinkedInLink { get; set; }
    
        [StringLength(20)]
        public string  ProfessionalPhone { get; set; }
    }
    public class PersonalContact : Contact
    {
        public DateTime BirthDate { get; set; }
        
        [StringLength(100)]        
        public string TwitterLink { get; set; }
        
        [StringLength(100)]        
        public string FaceBookLink { get; set; }
        
        [StringLength(20)]
        public string  PersonalPhone { get; set; }
    }
}
