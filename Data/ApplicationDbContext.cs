using Microsoft.EntityFrameworkCore;
using MyKoloApi.Models;

namespace MyKoloApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Savings> Savings { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}