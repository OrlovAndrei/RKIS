namespace H
{
    internal class Program
    {
        public static void Main()
        {
            Print(GetSquare(42));
        }
        static void Print(int number)
        {
            Console.WriteLine(number);
        }

        static int GetSquare(int number)
        {
            return (int)Math.Pow(number, 2);
        }
    }
}