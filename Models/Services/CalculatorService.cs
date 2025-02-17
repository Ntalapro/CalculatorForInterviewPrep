using CalculatorForInterviewPrep.Models.CalculationDataModel;
using CalculatorForInterviewPrep.Operations;
using CalculatorForInterviewPrep.Repositories;
using Microsoft.Extensions.Logging;

namespace CalculatorForInterviewPrep.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ICalculationRepository _calculationRepository;
        private readonly ILogger<CalculatorService> _logger;

        public CalculatorService(ICalculationRepository calculationRepository, ILogger<CalculatorService> logger)
        {
            _calculationRepository = calculationRepository;
            _logger = logger;
        }

        public async Task<double> PerformCalculationAsync(CalculationOperation operation, double operand1, double operand2)
        {
            try{
                double result = operation.Calculate(operand1, operand2);

                var calculation = new Calculation
                {
                    Expression = $"{operand1} {operation.GetType().Name} {operand2} = {result}",
                    Result = result
                };

                await _calculationRepository.AddAsync(calculation);
                return result;
            }
            catch(Exception ex){
                _logger.LogError($"Error performing calculation: {ex.Message}");
                throw;
            }
        }

    }

}
