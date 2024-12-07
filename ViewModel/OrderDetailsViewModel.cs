using Northwind.Models;
using NorthwindApp.Models;
using System.ComponentModel.DataAnnotations;

namespace NorthwindApp.ViewModel
{
    public class OrderDetailsViewModel
    {
        //[Key]
        //[Display(Name = "Order ID")]
        public int OrderID { get; set; }

        [Display(Name = "Order")]
        public Order Order { get; set; }

        [Display(Name = "Product ID")]
        [Required(ErrorMessage = "Required field!")]
        public int ProductID { get; set; }

        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Required field!")]
        public Product Product { get; set; }

        [Display(Name = "Customer ID")]
        [Required(ErrorMessage = "Required field!")]
        public string CustomerID { get; set; }

        [Display(Name = "Customer name")]
        [Required(ErrorMessage = "Required field!")]
        public Customer Customer { get; set; }


        [Display(Name = "Unit price")]
        [Required(ErrorMessage = "Required field!")]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Required field!")]
        public Int16? Quantity { get; set; }

        [Display(Name = "Discount")]
        [Required(ErrorMessage = "Required field!")]
        public float? Discount { get; set; }
    }
}
