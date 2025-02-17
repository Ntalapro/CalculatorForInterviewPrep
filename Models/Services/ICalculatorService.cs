using CalculatorForInterviewPrep.Models.CalculationDataModel;
using CalculatorForInterviewPrep.Operations;

namespace CalculatorForInterviewPrep.Services
{
    public interface ICalculatorService
    {
        Task<double> PerformCalculationAsync(CalculationOperation operation, double operand1, double operand2);
    }
}
