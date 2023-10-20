using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Models;
using StockSolutions.Data;

namespace StockSolutions.Pages.Chemicals
{
    public class CreateModel : PageModel
    {
        private readonly StockSolutions.Data.StockSolutionsContext _context;

        public CreateModel(StockSolutions.Data.StockSolutionsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Chemical Chemical { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Chemical == null || Chemical == null)
            {
                return Page();
            }

            _context.Chemical.Add(Chemical);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
