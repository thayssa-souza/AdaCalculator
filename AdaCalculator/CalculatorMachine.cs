namespace AdaCalculator
{
    public class CalculatorMachine
    {
        private ICalculator calc;
        public CalculatorMachine() : this(new Calculator())
        { }
        public CalculatorMachine(ICalculator obj)
        {
            this.calc = obj;
        }
        public (string operation, double result) Calculate(string operationType, double a, double b)
        {
            return calc.Calculate(operationType, a, b);
        }
    }
}
