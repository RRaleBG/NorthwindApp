﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }
        [InverseProperty("Employee")]
        public ICollection<Order> Orders { get; set; }
        [InverseProperty("Employee")]
        public ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Title { get; set; }
        public string? TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? HomePhone { get; set; }
        public string? Extension { get; set; }
        public byte[] Photo { get; set; }
        public string? Notes { get; set; }
        public string? PhotoPath { get; set; }
        public int? ReportsTo { get; set; }


        [NotMapped]
        public IFormFile PhotoFile { get; set; }
    }
}
