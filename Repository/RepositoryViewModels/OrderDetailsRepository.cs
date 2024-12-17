using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using Northwind.Models;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Repository.RepositoryViewModels
{
    public class OrderDetailsRepository : IOrderDetailsService
    {
        private readonly NorthwindDBContext _dbContext;
        
        public OrderDetailsRepository(NorthwindDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task DeleteAsync(int id)
        {
            if(id != 0)
            {
                var orderDetail = _dbContext.Orders.FindAsync(id);

                try
                {
                    _dbContext.Remove(orderDetail);
                    await _dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        public async Task<List<OrderDetailsViewModel>> GetAllAsync()
        {
            List<OrderDetailsViewModel> orderDetailsViewModels = new List<OrderDetailsViewModel>();
            var orderDetails = await _dbContext.OrderDetails
                .Include(order => order.Order)
                .ThenInclude(order => order.Customer)
                .Include(order => order.Product)
                .ToListAsync();

            foreach (var item in orderDetails)
            {
                var ordersDetail = new OrderDetailsViewModel
                {
                    OrderID = item.OrderID,
                    ProductID = item.ProductID,
                    Product = item.Product,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity,
                    Discount = item.Discount              
                };
                orderDetailsViewModels.Add(ordersDetail);
            }
            return orderDetailsViewModels;
        }



        public async Task<OrderDetailsViewModel> GetByIdAsync(int id, int id2)
        {
            //var ovm = await _dbContext.OrderDetails.FindAsync(id, id2);

            //var ovm = await _dbContext.OrderDetails
            //    .AsNoTracking()
            //    .Where(o => o.OrderID == id)
            //    .Include(oo => oo.Product)
            //    .Where(o => o.ProductID == id2)
            //    .AsSplitQuery().ToListAsync();

            var ovm = await _dbContext.OrderDetails
                        .AsNoTracking()
                        .Include(o => o.Order)
                        .Include(a => a.Product)
                        .ThenInclude(a => a.Category)
                        .Include(b => (b.Order).Customer)
                        .AsQueryable().ToListAsync();


            var delOrdDetail = new OrderDetailsViewModel
            {
                OrderID = ovm[0].OrderID,
                ProductID = ovm[0].ProductID,
                Product = ovm[0].Product,
                UnitPrice = ovm[0].UnitPrice,
                Quantity = ovm[0].Quantity,
                Discount = ovm[0].Discount,
                Order = ovm[0].Order,               
                Customer= ovm[0].Order.Customer,
            };
            return delOrdDetail;
        }



        public async Task InsertAsync(OrderDetailsViewModel orderDetails)
        {
            var insertOrderDetail = new OrderDetail
            {
                OrderID = orderDetails.OrderID,
                ProductID = orderDetails.ProductID,
                Product = orderDetails.Product,
                UnitPrice = (decimal)orderDetails.UnitPrice,
                Quantity = orderDetails.Quantity,
                Discount = orderDetails.Discount,
                Order = orderDetails.Order,
            };

            if(orderDetails != null)
            {
                await _dbContext.OrderDetails.AddAsync(insertOrderDetail);
                await _dbContext.SaveChangesAsync();
            }
        }


        public async Task UpdateAsync(OrderDetailsViewModel orderDetails)
        {
            var updateOrderDetail = await _dbContext.OrderDetails.FindAsync(orderDetails.OrderID, orderDetails.ProductID);

            updateOrderDetail.ProductID = orderDetails.ProductID;
            updateOrderDetail.Product = orderDetails.Product;
            updateOrderDetail.UnitPrice = (decimal)orderDetails.UnitPrice;
            updateOrderDetail.Discount = orderDetails.Discount;
            updateOrderDetail.Quantity = orderDetails.Quantity;

            if(orderDetails != null)
            {
                _dbContext.OrderDetails.Update(updateOrderDetail);
                await _dbContext.SaveChangesAsync();
            }
        }
        
    }
}
