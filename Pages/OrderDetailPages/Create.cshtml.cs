using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;
#nullable enable 

namespace NorthwindApp.Pages.OrderDetailPages
{
    public class CreateModel(IOrderDetailsService orderDetailService, IProductService productService) : PageModel
    {
        private readonly IOrderDetailsService _orderDetailService = orderDetailService;
        private readonly IProductService _productService = productService;

        [BindProperty]
        public OrderDetailsViewModel OrderDetail { get; set; } = default!;

        public async Task OnGet()
        {
            ViewData["OrderID"] = new SelectList(await _orderDetailService.GetAllOrdDetailsAsync(), "OrderID", "OrderID");
            ViewData["ProductID"] = new SelectList(await _productService.GetAllAsync(), "ProductID", "ProductName");
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (OrderDetail != null)
            {
                await _orderDetailService.InsertAsync(OrderDetail);
            }

            return RedirectToPage("./Index");
        }
    }
}
