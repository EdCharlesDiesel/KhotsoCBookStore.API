using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarPeaceAdminHubDB
{
    public class MemberOrder
    {

        [Key]
        [Required(ErrorMessage = "Order Number is required")]
        public int OrderNumber { get; set; } 
        
        [Required(ErrorMessage = "Member Number is required")]
        public int MemberNumber { get; set; } 

        [Required(ErrorMessage = "Order Fill Date is required")]
        public DateTime OrderFillDate { get; set; } 

        [Required(ErrorMessage = "Order Creation Date is required")]
        public DateTime OrderCreationDate { get; set; } 

        [MaxLength(40)]
        [Required(ErrorMessage = "Order Ship Name is required")]
        public string OrderShipName { get; set; } 

        [MaxLength(40)]
        [Required(ErrorMessage = "Order Ship Address is required")]
        public string OrderShipAddress { get; set; } 

        [MaxLength(30)]
        [Required(ErrorMessage = "Order Ship City is required")]
        public string OrderShipCity { get; set; }

        [MaxLength(9)]
        [Required(ErrorMessage = "Order Ship Postal Code is required")]
        public string OrderShipPostalCode { get; set; } 

        [Required(ErrorMessage = "Shipping Instructions is required")]
        public string ShippingInstructions { get; set; } 

        [Required(ErrorMessage = "Order Sub Total is required")]
        public decimal OrderSubTotal { get; set; } 

        [Required(ErrorMessage = "Order Sales Tax is required")]
        public decimal OrderSalesTax { get; set; } 

        [MaxLength(10)]
        [Required(ErrorMessage = "Order Shop Method is required")]
        public string OrderShopMethod { get; set; } 

        [Required(ErrorMessage = "Order Shipping And Handling Costs is required")]
        public decimal OrderShippingAndHandlingCosts { get; set; } 

        [MaxLength(10)]
        [Required(ErrorMessage = "Order Status is required")]
        public string OrderStatus { get; set; } 

        [Required(ErrorMessage = "Order Prepaid Amount is required")]
        public decimal OrderPrepaidAmount { get; set; } 

        [MaxLength(10)]
        [Required(ErrorMessage = "Order Payment Method is required")]
        public string OrderPaymentMethod { get; set; } 

        [Required(ErrorMessage = "Promotion Number is required")]
        public int PromotionNumber { get; set; } 
    }
}
