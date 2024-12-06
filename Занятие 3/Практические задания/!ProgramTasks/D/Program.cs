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

            var sharp = "#";
            var dot = ".";
            for (int с = 1; с <= size; с++)
            {
                for (int с2 = 1; с2 <= size; с2++)
                {
                    Console.Write((с2 + с) % 2 == 0 ? sharp : dot);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}