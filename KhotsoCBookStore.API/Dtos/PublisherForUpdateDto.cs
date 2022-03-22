using System;

namespace KhotsoCBookStore.API.Dto
{
    public class PublisherForUpdateDto 
    {
        public Guid PublisherId { get; set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public int PhoneNumber { get; set; }
    }
}