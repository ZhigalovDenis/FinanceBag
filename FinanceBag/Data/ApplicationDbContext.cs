using FinanceBag.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FinanceBag.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TypeOfActive> TypeOfActives { get; set; }
        public DbSet<Active> Actives { get; set; }
        public DbSet<Deal> Deals { get; set; }

    }
}
