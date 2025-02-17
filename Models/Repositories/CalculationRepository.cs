using CalculatorForInterviewPrep.Models.CalculationDataModel;

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

        public async Task<List<Calculation>> GetAllAsync() => await Task.FromResult(_calculations);
        public async Task<List<Calculation>> GetPositiveResultsAsync() =>
            await Task.FromResult(_calculations.Where(c => c.Result > 0).ToList());

        public async Task<List<Calculation>> GetNegativeResultsAsync() =>
            await Task.FromResult(_calculations.Where(c => c.Result < 0).ToList());

        public async Task<List<Calculation>> GetZeroResultsAsync() =>
            await Task.FromResult(_calculations.Where(c => c.Result == 0).ToList());
    }
}
