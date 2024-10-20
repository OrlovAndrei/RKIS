using System;
using static System.Net.Mime.MediaTypeNames;

namespace Percentages
{
    internal class Programm
    {
        static void Main(string [] args)
        {
            var input = Console.ReadLine()!.Split(" ");
            var summa = double.Parse(input[0]);
            var percent = double.Parse(input[1]);
            var mounths = double.Parse(input[2]);
            Console.WriteLine(Calculate(summa, percent, mounths));
        }
        private static double Calculate(double summa, double percent, double months)
        {
            return Math.Pow(1 + (percent / 12) / 100, months);
        }


    }
}
