using CalculatorForInterviewPrep.Operations;

namespace CalculatorForInterviewPrep.Models.Operations
{
    public interface IOperationFactory
    {
        CalculationOperation GetCalculationStratey(string operation);
    }
}
