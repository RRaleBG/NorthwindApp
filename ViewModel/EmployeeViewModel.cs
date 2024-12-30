using Northwind.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindApp.ViewModel
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        [InverseProperty("Employee")]

        public ICollection<Order> Orders { get; set; }
        [InverseProperty("Employee")]

        public ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Required field!")]
        public string? LastName { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessage = "Required field!")]
        public string? FirstName { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Required field!")]
        public string? Title { get; set; }

        [Display(Name = "Title of courtesy")]
        [Required(ErrorMessage = "Required field!")]
        public string? TitleOfCourtesy { get; set; }

        [Display(Name = "Birth date")]
        [Required(ErrorMessage = "Required field!")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Hire date")]
        [Required(ErrorMessage = "Required field!")]
        public DateTime? HireDate { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Required field!")]
        public string? Address { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Required field!")]
        public string? City { get; set; }

        [Display(Name = "Region")]
        public string? Region { get; set; }

        [Display(Name = "Postal code")]
        [Required(ErrorMessage = "Required field!")]
        public string? PostalCode { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Required field!")]
        public string? Country { get; set; }

        [Display(Name = "Home phone")]
        [Required(ErrorMessage = "Required field!")]
        public string? HomePhone { get; set; }

        [Display(Name = "Extension")]
        [Required(ErrorMessage = "Required field!")]
        public string? Extension { get; set; }

        [Display(Name = "Photo")]
        [Column(TypeName = "image")]
        public byte[]? Photo { get; set; }

        [Display(Name = "Notes")]
        [Required(ErrorMessage = "Required field!")]
        public string? Notes { get; set; }

        [Display(Name = "Photo path")]
        public string? PhotoPath { get; set; }

        public ICollection<Employee> Employees1 { get; set; }
        public Employee Employee1 { get; set; }


        [Display(Name = "Reports to")]
        [Required(ErrorMessage = "Required field!")]
        public int? ReportsTo { get; set; }

        [NotMapped]
        [Display(Name = "Picture")]
        public IFormFile PhotoFile { get; set; }

    }
}
