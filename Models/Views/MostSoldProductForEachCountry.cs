using System.ComponentModel.DataAnnotations;

namespace NorthwindApp.Models.Views
{
    public class MostSoldProductForEachCountry
    {
        public long? CountryRank { get; set; }

        [StringLength(15)]
        public string? Country { get; set; }

        [StringLength(40)]
        public string ProductName { get; set; } = String.Empty;

        public int? Quantity { get; set; }
    }
}
