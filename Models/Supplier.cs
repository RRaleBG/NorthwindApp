using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Models
{
    [Table("Suppliers")]
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Supplier ID")]
        public int SupplierID { get; set; }

        [InverseProperty("Supplier")]
        public ICollection<Product> Products { get; set; }

        [Display(Name = "Company name")]
        public string CompanyName { get; set; }

        [Display(Name = "Contact name")]
        public string ContactName { get; set; }

        [Display(Name = "Contact title")]
        public string ContactTitle { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Region")]
        public string Region { get; set; }

        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Fax")]
        public string Fax { get; set; }

        [Display(Name = "Home page")]
        public string HomePage { get; set; }
    }
}