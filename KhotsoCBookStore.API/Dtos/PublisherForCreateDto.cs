using System;

namespace KhotsoCBookStore.API.Dtos
{
    public class PublisherForCreateDto 
    {
        public Guid PublisherId { get; set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public int PhoneNumber { get; set; }
    }
}