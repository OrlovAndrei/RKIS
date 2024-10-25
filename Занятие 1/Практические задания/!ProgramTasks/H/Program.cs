using System;

namespace H
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int baseNum = 42;
            int stepen = 2;
            int GetSquare = 1;

            for (int i = 0; i < stepen; i++)
            {
                GetSquare *= baseNum;
            }
            Console.WriteLine(GetSquare);
        }
    }
}