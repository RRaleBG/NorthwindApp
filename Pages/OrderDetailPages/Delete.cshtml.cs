using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Northwind.Models;

namespace NorthwindApp.Pages.OrderDetailPages
{
    public class DeleteModel : PageModel
    {
        private readonly Northwind.Data.NorthwindDBContext _context;

        public DeleteModel(Northwind.Data.NorthwindDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; } = default!;



        public async Task<IActionResult> OnGetAsync(int? id, int id2)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderdetail = await _context.OrderDetails.FirstOrDefaultAsync(m => m.OrderID == id);

            if (orderdetail == null)
            {
                return NotFound();
            }
            else
            {
                OrderDetail = orderdetail;
            }
            return Page();
        }



        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderdetail = await _context.OrderDetails.FindAsync(id);
            if (orderdetail != null)
            {
                OrderDetail = orderdetail;
                _context.OrderDetails.Remove(OrderDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
