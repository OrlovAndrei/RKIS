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
            if ((a >= b) && (b >= c) || (c >= b) && (b >= a)) // проверяем b по всем возможным сценариям
                return b;
            else if ((a >= c) && (c >= b) || (b >= c) && (c >= a)) // проверяем c по всем возможным сценариям
                return c;
            else // a можно не проверять так как он крайний вариант
                return a;
        }
    }
}