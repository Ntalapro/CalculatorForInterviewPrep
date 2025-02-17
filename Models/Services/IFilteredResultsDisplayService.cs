using CalculatorForInterviewPrep.Models.CalculationDataModel;

namespace CalculatorForInterviewPrep.Models.Services
{
    public interface IFilteredResultsDisplayService
    {
        Task<List<Calculation>> GetAllCalculationsAsync();
        Task<List<Calculation>> GetPositiveResultsAsync();
        Task<List<Calculation>> GetNegativeResultsAsync();
        Task<List<Calculation>> GetZeroResultsAsync();
    }
}
