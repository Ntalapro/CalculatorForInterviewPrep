using CalculatorForInterviewPrep.Models.CalculationDataModel;

namespace CalculatorForInterviewPrep.Repositories
{
    public interface ICalculationRepository
    {
        Task AddAsync(Calculation calculation);
        Task<List<Calculation>> GetAllAsync();
        Task<List<Calculation>> GetPositiveResultsAsync();
        Task<List<Calculation>> GetNegativeResultsAsync();
        Task<List<Calculation>> GetZeroResultsAsync();

    }
}
