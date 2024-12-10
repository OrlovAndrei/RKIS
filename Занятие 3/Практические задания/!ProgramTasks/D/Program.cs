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
            WriteBoard(8); // 8x8
            WriteBoard(1); // 1x1
            WriteBoard(2); // 2x2
            WriteBoard(3); // 3x3
            WriteBoard(10); // 10x10
        }

        private static void WriteBoard(int size)
        {

            Console.WriteLine("#.#.#.#.");
            Console.WriteLine(".#.#.#.#");
            Console.WriteLine("#.#.#.#.");
            Console.WriteLine(".#.#.#.#");
            Console.WriteLine("#.#.#.#.");
            Console.WriteLine(".#.#.#.#");
            Console.WriteLine("#.#.#.#.");
            Console.WriteLine(".#.#.#.#");
             for (int row = 0; row < size; row++) {
                for (int col = 0; col < size; col++) {
                    if ((row + col) % 2 == 0) {
                        Console.WriteLine('#');
                    } else {
                        Console.WriteLine('.');
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
