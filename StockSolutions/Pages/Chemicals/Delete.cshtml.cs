using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using StockSolutions.Data;

namespace StockSolutions.Pages.Chemicals
{
    public class DeleteModel : PageModel
    {
        private readonly StockSolutions.Data.StockSolutionsContext _context;

        public DeleteModel(StockSolutions.Data.StockSolutionsContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Chemical Chemical { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Chemical == null)
            {
                return NotFound();
            }

            var chemical = await _context.Chemical.FirstOrDefaultAsync(m => m.Id == id);

            if (chemical == null)
            {
                return NotFound();
            }
            else 
            {
                Chemical = chemical;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Chemical == null)
            {
                return NotFound();
            }
            var chemical = await _context.Chemical.FindAsync(id);

            if (chemical != null)
            {
                Chemical = chemical;
                _context.Chemical.Remove(Chemical);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
