//using DDD.DomainLayer;
using Microsoft.AspNetCore.Identity;
using StarPeaceAdminHubDomain.Aggregates;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB.Models
{
    public class UserMaster    {

        // [Required]
        // [Display(Name = "user name")]
        // public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string Password { get; set; }

        [Display(Name = "remember me")]
        public bool RememberMe { get; set; }
        
    }
}
