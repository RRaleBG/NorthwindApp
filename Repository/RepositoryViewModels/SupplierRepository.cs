using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using Northwind.Models;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Repository.RepositoryViewModels
{
    public class SupplierRepository : ISupplierService
    {
        private readonly NorthwindDBContext _context;

        public SupplierRepository(NorthwindDBContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var deleteSupplier = await _context.Suppliers.FindAsync(id);
            _context.Suppliers.Remove(deleteSupplier);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SupplierViewModel>> GetAllAsync()
        {
            List<Supplier> suppliers = await _context.Suppliers.AsNoTracking().ToListAsync();
            List<SupplierViewModel> supplierViewModel = new List<SupplierViewModel>();

            foreach (var supplier in suppliers)
            {
                var newSupplier = new SupplierViewModel
                {
                    SupplierID = supplier.SupplierID,
                    Address = supplier.Address,
                    City = supplier.City,
                    Region = supplier.Region,
                    PostalCode = supplier.PostalCode,
                    Country = supplier.Country,
                    Phone = supplier.Phone,
                    CompanyName = supplier.CompanyName,
                    ContactName = supplier.ContactName,
                    ContactTitle = supplier.ContactTitle,
                    Fax = supplier.Fax,
                    HomePage = supplier.HomePage,
                    Products = supplier.Products
                };
                supplierViewModel.Add(newSupplier);
            }
            return supplierViewModel;
        }

        public async Task<SupplierViewModel> GetByIdAsync(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            var findSupplier = new SupplierViewModel
            {
                SupplierID = supplier.SupplierID,
                Products = supplier.Products,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Region = supplier.Region,
                PostalCode = supplier.PostalCode,
                Country = supplier.Country,
                Phone = supplier.Phone,
                Fax = supplier.Fax,
                HomePage = supplier.HomePage
            };

            return findSupplier;
        }

        public async Task InsertAsync(SupplierViewModel supplier)
        {
            var newSupplier = new Supplier
            {
                SupplierID = supplier.SupplierID,
                Products = supplier.Products,
                CompanyName = supplier.CompanyName,
                ContactName = supplier.ContactName,
                ContactTitle = supplier.ContactTitle,
                Address = supplier.Address,
                City = supplier.City,
                Region = supplier.Region,
                PostalCode = supplier.PostalCode,
                Country = supplier.Country,
                Phone = supplier.Phone,
                Fax = supplier.Fax,
                HomePage = supplier.HomePage
            };

            if (supplier != null)
            {
                await _context.Suppliers.AddAsync(newSupplier);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(SupplierViewModel supplier)
        {
            var updateSupplier = await _context.Suppliers.FindAsync(supplier.SupplierID);

            if (updateSupplier != null)
            {
                updateSupplier.SupplierID = supplier.SupplierID;
                updateSupplier.Products = supplier.Products;
                updateSupplier.CompanyName = supplier.CompanyName;
                updateSupplier.ContactName = supplier.ContactName;
                updateSupplier.ContactTitle = supplier.ContactTitle;
                updateSupplier.Address = supplier.Address;
                updateSupplier.City = supplier.City;
                updateSupplier.Region = supplier.Region;
                updateSupplier.PostalCode = supplier.PostalCode;
                updateSupplier.Country = supplier.Country;
                updateSupplier.Phone = supplier.Phone;
                updateSupplier.Fax = supplier.Fax;
                updateSupplier.HomePage = supplier.HomePage;

                if (updateSupplier != null)
                {
                    try
                    {
                        _context.Suppliers.Update(updateSupplier);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception)
                    {
                        throw new Exception();
                    }

                }
            }
        }
    }
}
