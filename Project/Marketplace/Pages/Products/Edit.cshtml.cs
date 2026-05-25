using Marketplace.Data;
using Marketplace.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public SelectList Categories { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            Product = product;
            Categories = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Categories = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
                return Page();
            }

            _context.Attach(Product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("/Products/Index");
        }
    }
}
