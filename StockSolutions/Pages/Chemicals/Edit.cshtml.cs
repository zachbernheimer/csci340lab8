using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using StockSolutions.Data;

namespace StockSolutions.Pages.Chemicals
{
    public class EditModel : PageModel
    {
        private readonly StockSolutions.Data.StockSolutionsContext _context;

        public EditModel(StockSolutions.Data.StockSolutionsContext context)
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

            var chemical =  await _context.Chemical.FirstOrDefaultAsync(m => m.Id == id);
            if (chemical == null)
            {
                return NotFound();
            }
            Chemical = chemical;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Chemical).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChemicalExists(Chemical.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ChemicalExists(int id)
        {
          return (_context.Chemical?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
