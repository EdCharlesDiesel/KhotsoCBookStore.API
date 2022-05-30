using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB
{
    public class MemberOrder
    {

        public int OrderNumber { get; set; } 
        
        public int MemberNumber { get; set; } 

        public DateTime OrderFillDate { get; set; } 

        public DateTime OrderCreationDate { get; set; } 

        public string OrderShipName { get; set; } 

        public string OrderShipAddress { get; set; } 

        public string OrderShipCity { get; set; }

        public string OrderShipPostalCode { get; set; } 

        public string ShippingInstructions { get; set; } 

        public decimal OrderSubTotal { get; set; } 

        public decimal OrderSalesTax { get; set; } 

        public string OrderShopMethod { get; set; } 

         public decimal OrderShippingAndHandlingCosts { get; set; } 

        public string OrderStatus { get; set; } 

        public decimal OrderPrepaidAmount { get; set; } 

        public string OrderPaymentMethod { get; set; } 
    }
}
