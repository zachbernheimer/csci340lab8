using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        ViewData["ChemicalId"] = new SelectList(_context.Chemical, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Bottle Bottle { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Bottle == null || Bottle == null)
            {
                Console.WriteLine("---------- Error 1: ");
                
                for (int i = 0; i < ModelState.Count; i++){
                    string k = ModelState.Keys.ToList()[i];
                    Console.WriteLine(k + ": " + ModelState.Values.ToList()[i]);
                };
                return Page();
            }
            
            
            _context.Bottle.Add(Bottle);
            await _context.SaveChangesAsync();
            Console.WriteLine("---------- Error 2");
            return RedirectToPage("./Index");
        }
    }
}
