namespace AdaCalculator
{
    public class Calculator : ICalculator
    {
        public (string operation, double result) Calculate(string operation, double a, double b)
        {
            (string operation, double result) resultOperation;
            double c;
            switch (operation)
            {
                case "divide":
                    c = Math.Round(a / b, 2);
                    break;
                case "multiply":
                    c = a * b;
                    break;
                case "subtract":
                    c = a - b;
                    break;
                case "sum":
                    c = a + b;
                    break;
                default:
                    c = a + b;
                    break;
            }
            resultOperation = (operation, c);
            return resultOperation;
        }
    }
}
