using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Models;
using StockSolutions.Data;

namespace StockSolutions.Pages.Bottles
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
        public Bottle Bottle { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Bottle == null || Bottle == null)
            {
                return Page();
            }

            _context.Bottle.Add(Bottle);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
