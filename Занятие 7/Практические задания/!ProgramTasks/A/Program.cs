namespace A
{
    internal class Program
    {
        public static void Main()
        {
            Print(1, 2);
            Print("a", 'b');
            Print(1, "a");
            Print(true, "a", 1);
        }

        public static void Print(...)
        {
            for (var i = 0; i < ...)
            {
                if (i > 0)
                    Console.Write(", ");
                Console.Write(...);
            }
            Console.WriteLine();
        }
    }
}