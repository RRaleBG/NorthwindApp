﻿using Northwind.Models;
using NorthwindApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindApp.ViewModel
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string? ShipCountry { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
        public string? CustomerID { get; set; }
        public Customer? Customer { get; set; }
        public int? EmployeeID { get; set; }
        public Employee? Employee { get; set; }

        [NotMapped]
        public IEnumerable<int>? ProductIds { get; set; }

        [NotMapped]
        public bool? ProductDiscontinued { get; set; }
    }
}