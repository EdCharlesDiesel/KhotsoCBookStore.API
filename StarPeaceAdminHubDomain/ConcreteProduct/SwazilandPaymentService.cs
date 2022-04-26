﻿using StarPeaceAdminHubDomain.Enums;
using StarPeaceAdminHubDomain.ProductInterface;
using System;

namespace StarPeaceAdminHubDomain.ConcreteProduct
{
    class SwazilandPaymentService : IPaymentService
    {
        public string EmailToCharge { get ; set ; }
        public float MoneyToCharge { get ; set ; }
        public EnumChargingOptions OptionToCharge { get ; set ; }

        public bool ProcessCharging()
        {
            Console.WriteLine("This payment will be processed by Brazilian Service.");
            Console.WriteLine($"Person: {EmailToCharge}");
            Console.WriteLine($"Price: R$ {MoneyToCharge:0.00}");
            Console.WriteLine($"Option: {OptionToCharge}");
            Console.WriteLine("");
            return true;
        }
    }
}
