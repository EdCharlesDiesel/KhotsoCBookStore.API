using System;
using System.Collections.Generic;
using System.Text;

namespace StarPeaceAdminHubDomain.DTOs
{
    public interface IBookFullEditDTO
    {
        int Id { get; set; }

        string Title { get; set; }        

        string ISBN { get; }

        string Descripion { get; set; }
        
        DateTime PublishingDate { get; set; }
        
        decimal Cost { get; set; }    

        decimal RetailPrice { get; set; }     
        
        string CoverFileName { get; set; }  
    }
}
