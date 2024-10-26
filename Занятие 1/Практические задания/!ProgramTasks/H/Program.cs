using System;

namespace H
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Print(GetSquare(42));
        }
        private static void Print(int number)
        {
            Console.WriteLine(number);
        }
        private static int GetSquare(int num)
        {
            return num * num;
        }
    }
}
