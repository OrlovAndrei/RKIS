using System;
namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteBoard(8);
            WriteBoard(1);
            WriteBoard(2);
            WriteBoard(3);
            WriteBoard(10);
        }

        private static void WriteBoard(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 1; j <= size; j++)
                    {
                        Console.Write(j % 2 != 0 ? "." : "#");
                    }
                }
                else
                {
                    for (int k = 1; k <= size; k++)
                    {
                        Console.Write(k % 2 != 0 ? "#" : ".");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }
    }
}