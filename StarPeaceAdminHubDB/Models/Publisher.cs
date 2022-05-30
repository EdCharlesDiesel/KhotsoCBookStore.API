using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB.Models
{
    public class Publisher 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        public string FullName { get; set; }


        [EmailAddress]
        public string EmailAddress { get; set; }

        public int PhoneNumber { get; set; }
    }
}