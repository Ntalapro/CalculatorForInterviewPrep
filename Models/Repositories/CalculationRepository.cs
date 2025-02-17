using CalculatorForInterviewPrep.Models.CalculationDataModel;
using Microsoft.EntityFrameworkCore;

namespace CalculatorForInterviewPrep.Repositories
{
    public class CalculationRepository : ICalculationRepository
    {
        private readonly ApplicationDbContext _context;

        public CalculationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Calculation calculation)
        {
            _context.Calculations.Add(calculation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Calculation>> GetAllAsync() => await _context.Calculations.ToListAsync();
        public async Task<List<Calculation>> GetPositiveResultsAsync() =>
            await _context.Calculations.Where(c => c.Result > 0).ToListAsync();

        public async Task<List<Calculation>> GetNegativeResultsAsync() =>
            await _context.Calculations.Where(c => c.Result < 0).ToListAsync();

        public async Task<List<Calculation>> GetZeroResultsAsync() =>
            await _context.Calculations.Where(c => c.Result == 0).ToListAsync();
    }
}
