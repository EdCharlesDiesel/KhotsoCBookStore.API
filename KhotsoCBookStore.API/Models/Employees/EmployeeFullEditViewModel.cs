using System;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;

namespace KhotsoCBookStore.API.Models
{
    public class EmployeeFullEditViewModel: IEmployeeFullEditDTO
    {
        public EmployeeFullEditViewModel() { }
        public EmployeeFullEditViewModel(IEmployee o)
        {
            EmployeeId = o.Id;
            FirstName = o.FirstName;
            LastName = o.LastName;
            IdNumber = o.IdNumber;
            Title = o.Title;
            TitleOfCourtesy = o.TitleOfCourtesy;
            IdNumber = o.IdNumber; 
            BirthDate = o.BirthDate; 
            HireDate = o.HireDate; 
            Address = o.Address; 
            City = o.City; 
            Region = o.Region; 
            PostalCode = o.PostalCode; 
            Country = o.Country; 
            Photo = o.Photo; 
            Notes = o.Notes; 
            ReportsTo = o.ReportsTo; 
            PhotoPath = o.PhotoPath; 
        }
         

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdNumber { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        public string PhotoPath { get; set; }
    }
}
