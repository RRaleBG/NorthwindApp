using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using NorthwindApp.Models;
using NorthwindApp.ViewModel;



namespace NorthwindApp.Repository.RepositoryViewModels
{
    public class CustomerRepository : ICustomerService
    {
        private readonly NorthwindDBContext _context;

        public CustomerRepository(NorthwindDBContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerViewModel>> GetAllAsync()
        {

            IList<Customer> customers = await _context.Customers
                   .Include(customer => customer.Orders)
                   .ThenInclude(order => order.OrderDetails)
                   .ThenInclude(orderdetails => orderdetails.Product)
                   .AsNoTracking()
                   .ToListAsync();


            List<CustomerViewModel> customerViewModels = new List<CustomerViewModel>();

            foreach (var customer in customers)
            {
                var _customer = new CustomerViewModel
                {
                    CustomerID = customer.CustomerID,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    Address = customer.Address,
                    City = customer.City,
                    Region = customer.Region,
                    PostalCode = customer.PostalCode,
                    Country = customer.Country,
                    Phone = customer.Phone,
                    Fax = customer.Fax,
                    Orders = customer.Orders.ToList()
                };

                if (_customer != null)
                {
                    customerViewModels.Add(_customer);
                }
            }
            return customerViewModels;
        }


        public async Task<CustomerViewModel> GetByIdAsync(string id)
        {
            var customer = await _context.Customers.FindAsync(id);

            IList<Customer> customers = _context.Customers
               .Include(customer => customer.Orders)
               .ThenInclude(order => order.OrderDetails)
               .ToList();


            var customerViewModel = new CustomerViewModel
            {
                CustomerID = customer.CustomerID,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Address = customer.Address,
                City = customer.City,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Phone = customer.Phone,
                Fax = customer.Fax,
                Orders = customer.Orders
            };

            return customerViewModel;
        }

        public async Task DeleteAsync(string id)
        {
            var customer = await _context.Customers.FindAsync(id);

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();
        }


        private static Random rnd = new Random();

        public static string NewID(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

        public async Task InsertAsync(CustomerViewModel customer)
        {
            customer.CustomerID = NewID(6);

            var newCustomer = new Customer()
            {
                CustomerID = customer.CustomerID,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Address = customer.Address,
                City = customer.City,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Phone = customer.Phone,
                Fax = customer.Fax,
            };

            try
            {
                await _context.Customers.AddAsync(newCustomer);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                e.Message.ToString();
                _context.Database.RollbackTransaction();
            }
        }

        public async Task UpdateAsync(CustomerViewModel customerUpdated)
        {
            var customer = await _context.Customers.FindAsync(customerUpdated.CustomerID);

            customer.CompanyName = customerUpdated.CompanyName;
            customer.ContactName = customerUpdated.ContactName;
            customer.ContactTitle = customerUpdated.ContactTitle;
            customer.Address = customerUpdated.Address;
            customer.City = customerUpdated.City;
            customer.Region = customerUpdated.Region;
            customer.PostalCode = customerUpdated.PostalCode;
            customer.Country = customerUpdated.Country;
            customer.Phone = customerUpdated.Phone;
            customer.Fax = customerUpdated.Fax;

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }


    }
}
