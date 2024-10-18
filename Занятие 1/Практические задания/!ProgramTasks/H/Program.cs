using System;

namespace H
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = 42;
            var b = 2;
            int GetSquare = (int)Math.Pow(a, b);
            Console.WriteLine(GetSquare);
        }
    }
}