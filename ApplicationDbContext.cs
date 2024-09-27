using FinancialProgram.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialProgram.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Survey> Surveys { get; set; }
    }
}
