using System;
using KhotsoCBookStore.API.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace StarPeace.IdentityServer.Authentication
{
    public class UserMaster : IdentityUser
    {
        
        public INotifier Notifier { get; set; }

        public UserMaster(INotifier notifier)
        {
            this.Notifier = notifier;
        }
        private string emailaddr;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }

        //[Required]
        public DateTime DateOfBirth { get; set; }

        // [Required]
        public string EmailAddress
        {
            get { return emailaddr; }
            set
            {
                if (emailaddr.Contains("@") && emailaddr.Contains("."))
                {
                    emailaddr = value;
                }
                else
                {
                    throw new Exception("Invalid Email address!");
                }
            }
        }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }



        public void ChangePassword(string username,string oldpwd,string newpwd)
        {
            //EmailNotifier notifier = new EmailNotifier();

            //change password here

            //Notify the user
            Notifier.Notify("Password was changed on " + DateTime.Now);
        }
    }
}
