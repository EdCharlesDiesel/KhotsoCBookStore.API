using System;
using System.ComponentModel.DataAnnotations;
using StarPeaceAdminHubDomain.Aggregates;
using StarPeaceAdminHubDomain.DTOs;

namespace KhotsoCBookStore.API.Models.Books
{
    public class EmployeeFullEditViewModel: IEmployeeFullEditDTO
    {
        public EmployeeFullEditViewModel() { }
        public EmployeeFullEditViewModel(IEmployee o)
        {
            Id = o.Id;
            FirstName = o.FirstName;
            LastName = o.LastName;
            IdNumber = o.IdNumber;
            StartOfEmployment = o.StartOfEmployment;
            EndOfEmployement = o.EndOfEmployement;
        }
         
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int IdNumber { get; set; }
        
        public DateTime StartOfEmployment { get; set; }

        public DateTime? EndOfEmployement { get; set; }
    }
}
