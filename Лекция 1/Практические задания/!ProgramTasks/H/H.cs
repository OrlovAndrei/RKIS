namespace H
{
    internal class Program
    {
        private static int GetSquare(int number)
        {
            return number * number;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetSquare(42));
        }

    }
}