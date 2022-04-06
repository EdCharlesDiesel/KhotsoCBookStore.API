using System;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Dtos
{
    public class PublisherDto 
    {
        public Guid PublisherId { get; set; }
        
        public string NameAndSurname { get; set; }

        public string EmailAddress { get; set; }

        public int PhoneNumber { get; set; }
    }
}