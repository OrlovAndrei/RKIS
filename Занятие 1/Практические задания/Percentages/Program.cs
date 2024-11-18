using System;

namespace Percentages
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите сумму, процентную ставку и срок вклада в месяцах (через пробел):");
            string input = Console.ReadLine();
            double result = Calculate(input);
            Console.WriteLine($"Накопившаяся сумма: {Math.Round(result)}");
        }
        static double Calculate(string input)
        {

            string[] parts = input.Split(' ');

            double principal = Convert.ToDouble(parts[0]);
            double annualInterestRate = Convert.ToDouble(parts[1]);
            int months = Convert.ToInt32(parts[2]);


            double monthlyInterestRate = annualInterestRate / 100 / 12;


            double accumulatedAmount = principal * Math.Pow(1 + monthlyInterestRate, months);

            return accumulatedAmount;
        }
    }
}