using System;

namespace Percentages
{
    internal class Programm
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()!.Split(" ");
            var sum = double.Parse(input[0]);
            var percent = double.Parse(input[1]);
            var mounths = double.Parse(input[2]);
            Console.WriteLine(Calculate(sum, percent, mounths));
        }
        private static double Calculate(double sum, double percent, double months)
        {
            return Math.Pow(1 + (percent / 12) / 100, months);
        }


    }
}