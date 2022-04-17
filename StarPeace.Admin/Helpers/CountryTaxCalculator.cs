
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarPeace.Admin.Services;

namespace StarPeace.Admin.Helpers
{
    public abstract class CountryTaxCalculator
    {
        public abstract decimal CalculateTaxAmount();
    }

    public class TaxCalculatorForBotswana : CountryTaxCalculator
    {
        public override decimal CalculateTaxAmount()
        {
            throw new NotImplementedException();
        }
    }

    public class TaxCalculatorForUS : ICountryTaxCalculator
    {      
        public decimal TotalIncome { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal CalculateTaxAmount()
        {
            decimal taxableIncome = TotalIncome - TotalDeduction;
            return taxableIncome * 30 / 100;
        }
    }

    public class TaxCalculatorForUK : ICountryTaxCalculator
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal CalculateTaxAmount()
        {
            decimal taxableIncome = TotalIncome - TotalDeduction;
            return taxableIncome * 35 / 100;
        }
    }

    public class TaxCalculatorForIN : ICountryTaxCalculator
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal CalculateTaxAmount()
        {
            decimal taxableIncome = TotalIncome - TotalDeduction;
            return taxableIncome * 20 / 100;
        }       
    }
}

