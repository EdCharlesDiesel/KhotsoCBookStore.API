using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Helpers
{
    public class TaxCalculator
    {
        public decimal Calculate(ICountryTaxCalculator obj)
        {
            decimal taxAmount = 0;
            taxAmount = obj.CalculateTaxAmount();
            return taxAmount;
        }

        public decimal Calculate(decimal income, decimal deduction,string country)
        {
            decimal taxAmount = 0;
            decimal taxableIncome = income - deduction;

            switch(country)
            {
                case "India":
                    //calculation here
                    break;
                case "USA":
                    //calculation here
                    break;
                case "UK":
                    //calculation here
                    break;
            }
            return taxAmount;
        }
    }
}
