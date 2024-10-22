using System;
namespace Percentages
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Исходная сумма, процентная ставка и срок вклада:");
            string input = Console.ReadLine();
            Console.WriteLine("Накопившаяся сумма: " + Calculate(input));
        }
        static double Calculate(string input)
        {
            string[] values = input.Split(' ');
            double sum = double.Parse(values[0]);
            double rank = double.Parse(values[1]) / 100;
            int term = int.Parse(values[2]);
            int term = int.Parse(values[2]); 
            return sum * Math.Pow(1 + rank / 12, term);
        }
    }
}
