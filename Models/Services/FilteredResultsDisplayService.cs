using CalculatorForInterviewPrep.Models.CalculationDataModel;
using CalculatorForInterviewPrep.Repositories;
using CalculatorForInterviewPrep.Services;

namespace CalculatorForInterviewPrep.Models.Services
{
    public class FilteredResultsDisplayService : IFilteredResultsDisplayService
    {
        private readonly ICalculationRepository _calculationRepository;

        public FilteredResultsDisplayService(ICalculationRepository calculationRepository, ILogger<CalculatorService> logger)
        {
            _calculationRepository = calculationRepository;
        }
        public async Task<List<Calculation>> GetAllCalculationsAsync() => await _calculationRepository.GetAllAsync();

        public async Task<List<Calculation>> GetPositiveResultsAsync() => await _calculationRepository.GetPositiveResultsAsync();

        public async Task<List<Calculation>> GetNegativeResultsAsync() => await _calculationRepository.GetNegativeResultsAsync();
        public async Task<List<Calculation>> GetZeroResultsAsync() => await _calculationRepository.GetZeroResultsAsync();
    }
}
