using Northwind.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindApp.ViewModel
{
    public class CustomerViewModel
    {
        [Display(Name = "Customer ID")]
        public string CustomerID { get; set; }

        [InverseProperty("Employee")]
        [Display(Name = "Company name")]
        [Required(ErrorMessage = "Required field!")]
        [StringLength(50, ErrorMessage = "Company name can't be longer than 50 characters")]
        public string CompanyName { get; set; }

        [Display(Name = "Contact name")]
        [Required(ErrorMessage = "Required field!")]
        public string ContactName { get; set; }

        [Display(Name = "Contact title")]
        [Required(ErrorMessage = "Required field!")]
        public string ContactTitle { get; set; }

        [Display(Name = "Addreess")]
        [Required(ErrorMessage = "Required field!")]
        public string Address { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Required field!")]
        public string City { get; set; }

        [Display(Name = "Region")]
        //[Required(ErrorMessage = "Required field!")]
        public string Region { get; set; }

        [Display(Name = "Postal code")]
        [Required(ErrorMessage = "Required field!")]
        public string PostalCode { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Required field!")]
        public string Country { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Required field!")]
        public string Phone { get; set; }

        [Display(Name = "Fax")]
        //[Required(ErrorMessage = "Required field!")]
        public string Fax { get; set; }

        [Display(Name = "Order")]
        public ICollection<Order> Orders { get; set; }
    }
}