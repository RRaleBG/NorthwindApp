﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    [Table("EmployeeTerritories")]
    public class EmployeeTerritory
    {
        [Key]
        public int EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }
        public string TerritoryID { get; set; }

        [ForeignKey("TerritoryID")]
        public Territory Territory { get; set; }
    }
}