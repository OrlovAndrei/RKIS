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
            string symbol = "#";
            for (int i = 0; i < size; i++)
            {
                Console.Write(symbol);
                for (int k = 0; k < size - 1; k++)
                {
                    if (symbol == "#") symbol = ".";
                    else if (symbol == ".") symbol = "#";
                    Console.Write(symbol);
                }

                if (size % 2 != 0)
                {
                    if (symbol == "#") symbol = ".";
                    else if (symbol == ".") symbol = "#";
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
