using StarPeaceAdminHubDomain.Enums;
using StarPeaceAdminHubDomain.ProductInterface;
using System;

namespace StarPeaceAdminHubDomain.ConcreteProduct
{
    class LesothoPaymentService : IPaymentService
    {
        public string EmailToCharge { get ; set ; }
        public float MoneyToCharge { get ; set ; }
        public EnumChargingOptions OptionToCharge { get ; set ; }

        public bool ProcessCharging()
        {
            Console.WriteLine("This payment will be processed by Italian Service.");
            Console.WriteLine($"Person: {EmailToCharge}");
            Console.WriteLine($"Price: $ {MoneyToCharge:0.00}");
            Console.WriteLine($"Option: {OptionToCharge}");
            Console.WriteLine("");
            return true;
        }
    }
}
