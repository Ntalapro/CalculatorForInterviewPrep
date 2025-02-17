using CalculatorForInterviewPrep.Operations;

namespace CalculatorForInterviewPrep.Models.Operations
{
    public class OperationFactory : IOperationFactory
    {
        // using PATTERN MATCHING - switch expression
        public  CalculationOperation GetCalculationStratey(string operation) => operation.ToLower() switch
        {
            "add" => new Addition(),
            "subtract" => new Subtraction(),
            "multiply" => new Multiplication(),
            "divide" => new Division(),
            _ => throw new ArgumentException("Invalid operation")
        };
    }
}
