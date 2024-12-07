using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using Northwind.Models;
using Syncfusion.EJ2.Linq;
using System.Linq;

namespace NorthwindApp.Repository.RepositoryViewModels
{
    public class OrderStatsViewModel
    {
        private readonly NorthwindDBContext _dbContext;


        public OrderStatsViewModel(NorthwindDBContext dbContext)
        {
                _dbContext = dbContext;
        }

        public List<OrderStatistic> OrderStatistics { get; set; }

        public async Task GetStats()
        {
            var listDetails = await _dbContext.OrderDetails.AsNoTracking().ToListAsync();

            var orders = await _dbContext.Orders
                .AsNoTracking()
                .Include(o => o.OrderDetails)
                .Include(o => o.Customer)
                .Include(o => o.Employee).ToListAsync();
            var total = orders.Select(o => o.OrderDetails.Select(g => g.UnitPrice).ToList());
         

            OrderStatistics = await _dbContext.Orders
                .AsNoTracking()
                .Include(o => o.OrderDetails).GroupBy( p => new
                {
                    p.OrderDate.Value.Year, p.OrderDate.Value.Month
                })
                .Select(g=> new OrderStatistic
                {
                    Month = $"{g.Key.Year} - {g.Key.Month}",
                    TotalOrders = g.Count(),
                    TotalRevenue = (decimal)g.Sum(o => o.Freight)
                }).ToListAsync();
            

        }
    }
}
