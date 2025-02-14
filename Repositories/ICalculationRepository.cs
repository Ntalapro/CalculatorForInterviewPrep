using CalculatorForInterviewPrep.Models;

namespace CalculatorForInterviewPrep.Repositories
{
    public interface ICalculationRepository
    {
        Task AddAsync(Calculation calculation);
        Task<List<Calculation>> GetAllAsync();

    }
}
