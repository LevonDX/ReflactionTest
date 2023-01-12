using System.Reflection;

namespace ReflactionTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    string expression = Console.ReadLine();
                    MathExpressionSolver solver = new MathExpressionSolver(expression);

                    double result = solver.Calculate();

                    Console.WriteLine(result);
                    Console.WriteLine();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }
    }
}