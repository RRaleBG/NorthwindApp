﻿using NorthwindApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    [Table("CustomerCustomerDemo")]
    public class CustomerCustomerDemo
    {
        [Key]
        public string CustomerID
        {
            get;
            set;
        }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
        public string CustomerTypeID
        {
            get;
            set;
        }

        [ForeignKey("CustomerTypeID")]
        public CustomerDemographic CustomerDemographic { get; set; }
    }
}