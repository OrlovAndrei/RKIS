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
           for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                               if ((row + col) % 2 == 0)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();  
            }
            Console.WriteLine();  
        }
    }
}