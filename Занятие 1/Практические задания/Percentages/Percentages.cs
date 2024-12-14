using System;

namespace Percentages
{
    class Program
    {
        static double Calculate(string input)
        {
            string[] result = input.Replace(".", ",").Split();
            double principal = Convert.ToDouble(result[0]);
            double annualInterestRate = Convert.ToDouble(result[1]);


            int months = Convert.ToInt32(result[2]);
            return principal * Math.Pow(1 + (annualInterestRate / 1200), months);


        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int result = Convert.ToInt32(Calculate(input));
            Console.WriteLine(result);
        
        }
    }
}
