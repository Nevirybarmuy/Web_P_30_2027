using Marketplace.Data;
using Marketplace.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; } = new();

        public SelectList Products { get; set; } = default!;

        public async Task OnGetAsync(int? productId)
        {
            Products = new SelectList(await _context.Products.ToListAsync(), "Id", "Name");
            if (productId.HasValue)
                Order.ProductId = productId.Value;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Products = new SelectList(await _context.Products.ToListAsync(), "Id", "Name");
                return Page();
            }

            var product = await _context.Products.FindAsync(Order.ProductId);
            if (product == null)
            {
                ModelState.AddModelError("", "Товар не найден");
                Products = new SelectList(await _context.Products.ToListAsync(), "Id", "Name");
                return Page();
            }

            Order.OrderDate = DateTime.Now;
            Order.TotalPrice = product.Price * Order.Quantity;
            Order.Status = "В обработке";
            Order.Name = $"Заказ #{DateTime.Now.Ticks}";

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Orders/Index");
        }
    }
}
