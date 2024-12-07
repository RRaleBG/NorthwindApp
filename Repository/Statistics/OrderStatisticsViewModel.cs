using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Northwind.Data;
using NuGet.Protocol;

namespace NorthwindApp.Repository.Statistics
{

    public class OrderStats
    {
        public string Month { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    public class OrderStatisticsViewModel
    {


        private readonly NorthwindDBContext _context;

        public OrderStatisticsViewModel(NorthwindDBContext context)
        {
            _context = context;
        }


        public List<OrderStatisticsViewModel> OrderStatistics { get; set; }

        public async Task<List<OrderStatisticsViewModel>> OnGetAsync() 
        {
            return OrderStatistics.ToList();
        }
    }
}
