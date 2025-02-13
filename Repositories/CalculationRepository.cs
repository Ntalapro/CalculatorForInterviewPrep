using CalculatorForInterviewPrep.Models;

namespace CalculatorForInterviewPrep.Repositories
{
    public class CalculationRepository : ICalculationRepository
    {
        private readonly List<Calculation> _calculations = new List<Calculation>();

        public async Task AddAsync(Calculation calculation)
        {
            _calculations.Add(calculation);
            await Task.CompletedTask;
        }

        public async Task<List<Calculation>> GetAllAsync()
        {
            return await Task.FromResult(_calculations);
        }
    }
}
