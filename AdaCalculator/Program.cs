namespace AdaCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            (string op, double res) result = calc.Calculate("sum", 1, 4);
            Console.WriteLine($"{result.op} de 1 com 4 é igual a {result.res}");
            Console.ReadLine();
        }
    }
}
