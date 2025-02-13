using CalculatorForInterviewPrep.Models;
using CalculatorForInterviewPrep.Operations;
using CalculatorForInterviewPrep.Repositories;

namespace CalculatorForInterviewPrep.Services
{
    public class CalculatorService
    {
        private readonly ICalculationRepository _calculationRepository;

        public CalculatorService(ICalculationRepository calculationRepository)
        {
            _calculationRepository = calculationRepository;
        }

        public async Task<double> PerformCalculationAsync(CalculationOperation operation, double operand1, double operand2)
        {
            double result = operation.Execute(operand1, operand2);

            var calculationRecord = new Calculation
            {
                Expression = $"{operand1} {operation.GetType().Name} {operand2}",
                Result = result
            };

            await _calculationRepository.AddAsync(calculationRecord);

            return result;
        }

        public async Task<List<Calculation>> GetAllCalculationsAsync()
        {
            return await _calculationRepository.GetAllAsync();
        }
    }

}
