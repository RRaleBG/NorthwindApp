using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using Northwind.Models;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Repository.RepositoryViewModels
{
    public class ProductRepository : IProductService
    {
        private readonly NorthwindDBContext _context;

        public ProductRepository(NorthwindDBContext context)
        {
            _context = context;
        }


        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }


        // Get all information about Product from table
        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            var products = await _context.Products.AsNoTracking().Include(p => p.Supplier).Distinct().Include(p => p.Category).Distinct().ToListAsync();
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    ProductID = product.ProductID,
                    Supplier = product.Supplier,
                    Category = product.Category,
                    ProductName = product.ProductName,
                    SupplierID = product.SupplierID,
                    CategoryID = product.CategoryID,
                    QuantityPerUnit = product.QuantityPerUnit,
                    UnitPrice = product.UnitPrice,
                    UnitsInStock = product.UnitsInStock,
                    UnitsOnOrder = product.UnitsOnOrder,
                    ReorderLevel = product.ReorderLevel,
                    Discontinued = product.Discontinued,
                };

                productViewModels.Add(productViewModel);
            }

            return productViewModels;
        }


        // Find information for Product from table
        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var products = await _context.Products.Where(m => m.ProductID == id).AsNoTracking()
                                                  .Include(p => p.Category).AsNoTracking()
                                                  .Include(p => p.Supplier).AsNoTracking().ToListAsync();


            var productViewModel = new ProductViewModel
            {
                ProductID = products[0].ProductID,
                ProductName = products[0].ProductName,
                SupplierID = products[0].SupplierID,
                Supplier = products[0].Supplier,
                CategoryID = products[0].CategoryID,
                Category = products[0].Category,
                QuantityPerUnit = products[0].QuantityPerUnit,
                UnitPrice = products[0].UnitPrice,
                UnitsInStock = products[0].UnitsInStock,
                UnitsOnOrder = products[0].UnitsOnOrder,
                ReorderLevel = products[0].ReorderLevel,
                Discontinued = products[0].Discontinued,
            };

            return productViewModel;
        }


        // Insert information to Product db table
        public async Task InsertAsync(ProductViewModel productViewModel)
        {
            var product = new Product
            {
                CategoryID = productViewModel.CategoryID,
                Category = productViewModel.Category,
                SupplierID = productViewModel.SupplierID,
                Supplier = productViewModel.Supplier,
                Discontinued = productViewModel.Discontinued,
                OrderDetails = productViewModel.OrderDetails,
                ProductName = productViewModel.ProductName,
                QuantityPerUnit = productViewModel.QuantityPerUnit,
                UnitPrice = productViewModel.UnitPrice,
                ReorderLevel = productViewModel.ReorderLevel,
                UnitsOnOrder = productViewModel.UnitsOnOrder,
                UnitsInStock = productViewModel.UnitsInStock
            };

            try
            {
                if (productViewModel != null)
                {
                    await _context.Products.AddAsync(product);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        // Update information to Product db table
        public async Task UpdateAsync(ProductViewModel editProduct)
        {
            var productViewModel = await _context.Products.FindAsync(editProduct.ProductID);

            productViewModel.Category = editProduct.Category;
            productViewModel.SupplierID = editProduct.SupplierID;
            productViewModel.Supplier = editProduct.Supplier;
            productViewModel.Discontinued = editProduct.Discontinued;
            productViewModel.OrderDetails = editProduct.OrderDetails;
            productViewModel.ProductName = editProduct.ProductName;
            productViewModel.QuantityPerUnit = editProduct.QuantityPerUnit;
            productViewModel.UnitPrice = editProduct.UnitPrice;
            productViewModel.ReorderLevel = editProduct.ReorderLevel;
            productViewModel.UnitsInStock = editProduct.UnitsInStock;
            productViewModel.UnitsOnOrder = editProduct.UnitsOnOrder;

            if (productViewModel != null)
            {
                try
                {
                    _context.Products.Update(productViewModel);
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