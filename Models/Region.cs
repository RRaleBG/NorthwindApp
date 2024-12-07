using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Northwind.Models
{

    [Table("Region")]
    public class Region
    {
        [Key]
        public int RegionID { get; set; }
        [InverseProperty("Region")]
        public ICollection<Territory> Territories { get; set; }
        public string RegionDescription { get; set; }
    }
}