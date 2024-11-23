namespace C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MiddleOf(5, 0, 100)); // => 5
            Console.WriteLine(MiddleOf(12, 12, 11)); // => 12
            Console.WriteLine(MiddleOf(1, 1, 1)); // => 1
            Console.WriteLine(MiddleOf(2, 3, 2));
            Console.WriteLine(MiddleOf(8, 8, 8));
            Console.WriteLine(MiddleOf(5, 0, 1));
        }

        public static int MiddleOf(int a, int b, int c)
        {
            return a + b + c - Math.Max(a, Math.Max(b, c)) - Math.Min(a, Math.Min(b, c));
        }
    }
}