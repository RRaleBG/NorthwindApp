using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using Northwind.Models;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Repository.RepositoryViewModels
{
    public class OrderRepository : IOrderService
    {
        private readonly NorthwindDBContext _dbContext;

        public OrderRepository(NorthwindDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        // INSERT new data in Order table
        public async Task InsertAsync(OrderViewModel order)
        {
            var orderViewModel = new Order
            {
                OrderID = order.OrderID,
                CustomerID = order.CustomerID,
                Customer = order.Customer,
                EmployeeID = order.EmployeeID,
                Employee = order.Employee,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                Freight = order.Freight,
                ShipName = order.ShipRegion,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry,
                OrderDetails = order.OrderDetails,
            };

            try
            {
                if (order != null)
                {
                    await _dbContext.Orders.AddAsync(orderViewModel);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // UPDATE existing data from Order table
        public async Task UpdateAsync(OrderViewModel order)
        {
            var orderViewModel = await _dbContext.Orders.FindAsync(order.OrderID);

            orderViewModel.OrderID = order.OrderID;
            orderViewModel.CustomerID = order.CustomerID;
            orderViewModel.Customer = order.Customer;
            orderViewModel.EmployeeID = order.EmployeeID;
            orderViewModel.Employee = order.Employee;
            orderViewModel.OrderDate = order.OrderDate;
            orderViewModel.RequiredDate = order.RequiredDate;
            orderViewModel.ShippedDate = order.ShippedDate;
            orderViewModel.Freight = order.Freight;
            orderViewModel.ShipName = order.ShipName;
            orderViewModel.ShipAddress = order.ShipAddress;
            orderViewModel.ShipCity = order.ShipCity;
            orderViewModel.ShipRegion = order.ShipRegion;
            orderViewModel.ShipPostalCode = order.ShipPostalCode;
            orderViewModel.ShipCountry = order.ShipCountry;

            if (orderViewModel != null)
            {
                try
                {
                    _dbContext.Orders.Update(orderViewModel);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }



        // READ all data from Order table
        public async Task<IList<OrderViewModel>> GetAllAsync()
        {
            var orders = await _dbContext.Orders
                .Include(o => o.Customer)
                .AsNoTracking()
                .Include(o => o.Employee)
                .AsNoTracking()
                .ToListAsync();

            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();

            foreach (var order in orders)
            {
                var orderViewModel = new OrderViewModel
                {
                    OrderID = order.OrderID,
                    CustomerID = order.CustomerID,
                    Customer = order.Customer,
                    EmployeeID = order.EmployeeID,
                    Employee = order.Employee,
                    OrderDate = order.OrderDate,
                    RequiredDate = order.RequiredDate,
                    ShippedDate = order.ShippedDate,
                    Freight = order.Freight,
                    ShipName = order.ShipRegion,
                    ShipAddress = order.ShipAddress,
                    ShipCity = order.ShipCity,
                    ShipRegion = order.ShipRegion,
                    ShipPostalCode = order.ShipPostalCode,
                    ShipCountry = order.ShipCountry,
                    OrderDetails = order.OrderDetails,
                };
                orderViewModels.Add(orderViewModel);
            }
            return orderViewModels;
        }


        // READ details from Order table
        public async Task<OrderViewModel> GetByIdAsync(int id)
        {
            var orders = await _dbContext.Orders.AsNoTracking()
                .Where(o => o.OrderID == id)
                .Include(c => c.Customer)
                .Include(e => e.Employee)
                .Include(pp => pp.OrderDetails).ToListAsync();

            //var orders = await _dbContext.Orders
            //    .AsNoTracking()
            //    .Where(o => o.OrderID == id)
            //    .Include(oo => oo.Customer)
            //    .Include(oo => oo.OrderDetails)
            //    .ThenInclude(dd => dd.Product)
            //    .ThenInclude(dd => dd.Category)
            //    .AsSplitQuery().ToListAsync();

            var orderViewModel = new OrderViewModel
            {
                OrderID = orders[0].OrderID,
                CustomerID = orders[0].CustomerID,
                Customer = orders[0].Customer,
                EmployeeID = orders[0].EmployeeID,
                Employee = orders[0].Employee,
                OrderDate = orders[0].OrderDate,
                RequiredDate = orders[0].RequiredDate,
                ShippedDate = orders[0].ShippedDate,
                Freight = orders[0].Freight,
                ShipName = orders[0].ShipRegion,
                ShipAddress = orders[0].ShipAddress,
                ShipCity = orders[0].ShipCity,
                ShipRegion = orders[0].ShipRegion,
                ShipPostalCode = orders[0].ShipPostalCode,
                ShipCountry = orders[0].ShipCountry,
                ProductIds = orders[0].ProductIds,
                OrderDetails = orders[0].OrderDetails,
                ProductDiscontinued = orders[0].ProductDiscontinued,
            };

            return orderViewModel;
        }


        // DELETE details from Order table
        public async Task DeleteAsync(int id)
        {
            var order = await _dbContext.Orders.FindAsync(id);

            if (order != null)
            {
                try
                {
                    _dbContext.Orders.Remove(order);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
