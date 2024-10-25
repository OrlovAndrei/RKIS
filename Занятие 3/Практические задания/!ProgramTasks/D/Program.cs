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

            Console.WriteLine("#.#.#.#.");
            Console.WriteLine(".#.#.#.#");
            Console.WriteLine("#.#.#.#.");
            Console.WriteLine(".#.#.#.#");
            Console.WriteLine("#.#.#.#.");
            Console.WriteLine(".#.#.#.#");
            Console.WriteLine("#.#.#.#.");
            Console.WriteLine(".#.#.#.#");
            Console.WriteLine();
        }
    }
}
