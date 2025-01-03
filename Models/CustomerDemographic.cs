﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Models
{
    [Table("CustomerDemographics")]
    public class CustomerDemographic
    {
        [Key]
        public string CustomerTypeID
        {
            get;
            set;
        }


        [InverseProperty("CustomerDemographic")]
        public ICollection<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }
        public string CustomerDesc
        {
            get;
            set;
        }
    }
}