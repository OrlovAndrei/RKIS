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

            for (int i = 0; i < size; i++)
            {
                if (int j = 0; j < size; j++)
                {
                    if ((i + j) % 2 == 0 )
                    {
                        Console.WriteLine("#");
                    }
                    else
                    {
                        Console.WriteLine(".");
                    }
                }
                Console.WriteLine();
            }
            Cosole.WriteLine();
        }
    }
}