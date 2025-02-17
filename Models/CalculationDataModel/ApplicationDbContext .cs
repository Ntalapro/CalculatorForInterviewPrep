using Microsoft.EntityFrameworkCore;

namespace CalculatorForInterviewPrep.Models.CalculationDataModel
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Calculation> Calculations { get; set; }
    }
}
