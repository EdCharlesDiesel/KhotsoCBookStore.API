using System;

namespace KhotsoCBookStore.API.Models
{
    public class CustomerInfosViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get;set; }

        public DateTime DateOfBirth { get;set; }
        
        public int IdNumber { get;set; }

        public string SocialMediaFaceBook { get; set; }

        
        public override string ToString()
        {
            return string.Format("Customer {0} {1} Book Id {2}, Has an Id of  price: {3}",
                FirstName, LastName, Id);
        }
    }
}
