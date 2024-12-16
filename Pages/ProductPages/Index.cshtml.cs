using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using NorthwindApp.Repository;
using NorthwindApp.ViewModel;





namespace NorthwindApp.Pages.ProductPages
{

    public class IndexModel : PageModel
    {


        private readonly IProductService _productService;
        private readonly NorthwindDBContext _ctx;

        public IEnumerable<ProductViewModel> Products { get; set; }

        public IndexModel(IProductService productService, NorthwindDBContext ctx)
        {
            _productService = productService;
            _ctx = ctx;
        }

        public async Task OnGetAsync()
        {
            Products = await _productService.GetAllAsync();

            ViewData["Products"] = Products.Select(m=>m.ProductName).ToList();

            ViewData["Category"] = await _ctx.Products.AsNoTracking()
                                                        .Include(p => p.Category).Distinct()
                                                        .Include(p => p.Category).AsNoTracking()
                                                        .OrderByDescending(p => p.ProductName).AsNoTracking().ToListAsync();
                                                        
                                                        

            if (Products == null)
            {
                BadRequest();
            }
        }


    }
}