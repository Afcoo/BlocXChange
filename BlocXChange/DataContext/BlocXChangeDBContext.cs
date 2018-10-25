using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlocXChange.Models;

namespace BlocXChange.DataContext
{
    public class BlocXChangeDBContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Fluctuation> Fluctuations { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=127.0.0.1,2342;Initial Catalog=BlocXChange;User ID=sa;Password=asdfg3579;");
        }
    }
}
