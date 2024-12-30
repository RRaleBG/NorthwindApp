using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using NorthwindApp.Models;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.OrderPages
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderService _context;
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        private readonly NorthwindDBContext _db;

        public DetailsModel(IOrderService context, NorthwindDBContext db)
        {
            _context = context;
            _db = db;
        }
        public OrderViewModel Orders { get; set; } = default!;



        public async Task<IActionResult> OnGetAsync(int id, int customerId)
        {
            if (id == 0)
            {
                return NotFound();
            }
            CustomerId = customerId;

            Orders = await _context.GetByIdAsync(id);

            if (Orders == null)
            {
                return NotFound();
            }

            if (CustomerId > 0)
            {
                Customer = await _db.Customers
                    .FromSqlInterpolated($"SELECT * FROM Customers WHERE Id = {CustomerId}")
                    .FirstOrDefaultAsync();
            }

            return Page();
        }
    }
}
