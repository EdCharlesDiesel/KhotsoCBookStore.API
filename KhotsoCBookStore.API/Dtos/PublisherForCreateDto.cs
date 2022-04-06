using System;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Dtos
{
    public class PublisherForCreateDto 
    {
         [Required(ErrorMessage ="Please provide name and surname")]
        public string NameAndSurname { get; set; }

        [Required(ErrorMessage ="Please provide  email address")]
        [EmailAddress(ErrorMessage ="Please enter valid email address")]
        public string EmailAddress { get; set; }

        public int PhoneNumber { get; set; }
    }
}