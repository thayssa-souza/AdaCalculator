 namespace AdaCalculator
{
    public interface ICalculator
    {
        (
            string operation,
            double result
        )
            Calculate(string operation, double a, double b);
    }
}

