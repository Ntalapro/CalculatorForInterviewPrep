namespace CalculatorForInterviewPrep.Operations
{
    public class Division : CalculationOperation
    {
        public override double Execute(double operand1, double operand2)
        {
            if (operand2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return operand1 / operand2;
        }
    }

}
