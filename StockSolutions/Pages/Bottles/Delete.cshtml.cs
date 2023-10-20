using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using StockSolutions.Data;

namespace StockSolutions.Pages.Bottles
{
    public class DeleteModel : PageModel
    {
        private readonly StockSolutions.Data.StockSolutionsContext _context;

        public DeleteModel(StockSolutions.Data.StockSolutionsContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Bottle Bottle { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bottle == null)
            {
                return NotFound();
            }

            var bottle = await _context.Bottle.FirstOrDefaultAsync(m => m.Id == id);

            if (bottle == null)
            {
                return NotFound();
            }
            else 
            {
                Bottle = bottle;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Bottle == null)
            {
                return NotFound();
            }
            var bottle = await _context.Bottle.FindAsync(id);

            if (bottle != null)
            {
                Bottle = bottle;
                _context.Bottle.Remove(Bottle);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
