using System;
using System.ComponentModel.DataAnnotations;

namespace KhotsoCBookStore.API.Dtos
{
    public class BookForUpdateDto
    {
        [Required(ErrorMessage ="Please provide title")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Please provide publishing date")]
        public DateTime PublishingDate { get; set; }

        public Guid PublisherId { get; set; }

        public decimal Cost { get; set; }

        public decimal RetailPrice { get; set; }

        public string CoverFileName { get; set; }
    }
}
