using Microsoft.EntityFrameworkCore;
using ProjectInAndOut.Models;

namespace ProjectInAndOut.Data
{
    public class ApplicationDbContext :DbContext
    {
        //we created a constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

        public DbSet<Item> Items{ get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
    }
}
