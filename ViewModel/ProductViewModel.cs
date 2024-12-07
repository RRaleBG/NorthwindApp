﻿using Northwind.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NorthwindApp.ViewModel
{
    public class ProductViewModel
    {
        [Display(Name = "ProductID")]
        public int ProductID { get; set; }

        public ICollection<OrderDetail?> OrderDetails { get; set; }


        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Required field!")]
        public string ProductName { get; set; }

        [ForeignKey("SupplierID")]
        [Display(Name = "Supplier")]
        [Required(ErrorMessage = "Required field!")]
        public int SupplierID { get; set; }

        [Display(Name = "Supplier")]
        [Required(ErrorMessage = "Required field!")]
        public Supplier? Supplier { get; set; }

        [ForeignKey("CategoryID")]
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Required field!")]
        public int CategoryID { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Required field!")]
        public Category? Category { get; set; }


        [Display(Name = "Quantity per unit")]
        [Required(ErrorMessage = "Required field!")]
        public string QuantityPerUnit { get; set; }


        [Display(Name = "Unit price")]
        [Required(ErrorMessage = "Required field!")]
        public decimal UnitPrice { get; set; }


        [Display(Name = "Units in stock")]
        [Required(ErrorMessage = "Required field!")]
        public Int16 UnitsInStock { get; set; }


        [Display(Name = "Units on order")]
        [Required(ErrorMessage = "Required field!")]
        public Int16 UnitsOnOrder { get; set; }


        [Display(Name = "Reorder level")]
        [Required(ErrorMessage = "Required field!")]
        public Int16 ReorderLevel { get; set; }


        [Display(Name = "Discontinued")]
        [Required(ErrorMessage = "Required field!")]
        public bool Discontinued { get; set; }
    }
}