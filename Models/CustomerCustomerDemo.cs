using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NorthwindApp.Models;

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