using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Pages.OrderDetailPages
{
    public class EditModel : PageModel
    {
        private readonly IOrderDetailsService _orderDetailsService;
        private readonly IProductService _productService;


        public EditModel(IOrderDetailsService orderDetailsService, IProductService productService)
        {
            _orderDetailsService = orderDetailsService;
            _productService = productService;
        }


        [BindProperty]
        public OrderDetailsViewModel OrderDetail { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int id, int id2)
        {

            OrderDetail = await _orderDetailsService.GetByIdAsync(id,id2);

            if (OrderDetail == null)
            {
                return NotFound();
            }

            ViewData["OrderID"] = new SelectList( await _orderDetailsService.GetAllAsync(), "OrderID", "OrderID");
            ViewData["ProductID"] = new SelectList(await _productService.GetAllAsync(), "ProductID", "ProductName");
            return Page();
        }

        //[BindProperty]
        //public OrderDetailsViewModel OrderDetail { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            try
            {
                await _orderDetailsService.UpdateAsync(OrderDetail);
                return RedirectToPage("/Details", new {id = OrderDetail.OrderID});
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (OrderDetail.OrderID == 0)
                {
                    return NotFound();
                }
                else
                {
                    throw new DbUpdateConcurrencyException(ex.Message);
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
