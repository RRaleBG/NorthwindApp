using System.ComponentModel.DataAnnotations;

namespace NorthwindApp.Models.Views
{
    public class TotalSales
    {
        public int ProductId { get; set; }

        [StringLength(40)]
        public string ProductName { get; set; } = String.Empty;

        public float? TotalSales1 { get; set; }
    }
}
