using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPeace.Extensions.Services
{
    public interface ICountryTaxCalculator
    {
        decimal TotalIncome { get; set; }
        decimal TotalDeduction { get; set; }
        decimal CalculateTaxAmount();
    }    
   
}