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
    public class IndexModel : PageModel
    {
        private readonly StockSolutions.Data.StockSolutionsContext _context;

        public IndexModel(StockSolutions.Data.StockSolutionsContext context)
        {
            _context = context;
        }

        public IList<Bottle> Bottle { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Bottle != null)
            {
                Bottle = await _context.Bottle
                .Include(b => b.Chemical).ToListAsync();
            }
        }
    }
}
