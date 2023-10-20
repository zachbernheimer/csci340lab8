using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace StockSolutions.Data
{
    public class StockSolutionsContext : DbContext
    {
        public StockSolutionsContext (DbContextOptions<StockSolutionsContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovie.Models.Chemical> Chemical { get; set; } = default!;

        public DbSet<RazorPagesMovie.Models.Bottle> Bottle { get; set; } = default!;
    }
}
