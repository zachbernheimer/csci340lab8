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
    public class DetailsModel : PageModel
    {
        private readonly StockSolutions.Data.StockSolutionsContext _context;

        public DetailsModel(StockSolutions.Data.StockSolutionsContext context)
        {
            _context = context;
        }

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
    }
}
