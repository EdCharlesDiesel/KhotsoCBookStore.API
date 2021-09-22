using System;
using System.Collections.Generic;

namespace KhotsoCBookStore.API.Authentication
{
    public partial class UserMaster
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        //public string Password { get; set; }        
             public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int UserTypeId { get; set; }
    }
}
