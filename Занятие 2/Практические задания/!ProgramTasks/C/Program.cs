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
            // Первый способ
            int average = 0;
            if ((a >= b) && (a >= c))
            {
                if (b >= c) average = b;
                else average = c;
            }
            if ((b >= c) && (b >= a))
            {
                if (c >= a) average = c;
                else average = a;
            }
            if ((c >= a) && (c >= b))
            {
                if (a >= b) average = a;
                else average = b;
            }
            return average;

            //Второй способ
            //int sum = a + b + c;
            //int max = Math.Max(a, Math.Max(b, c));
            //int min = Math.Min(a, Math.Min(b, c));
            //return sum - max - min;

        }
    }
}