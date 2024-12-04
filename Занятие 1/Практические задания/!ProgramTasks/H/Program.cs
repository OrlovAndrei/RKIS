namespace H
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Print(GetSquare(42));
        }
        static void Print(int number)
        {
            Console.WriteLine(number);
        }

        static int GetSquare(int number)
        {
            return (int)Math.Pow(number, 2);    // Math.Pow = number * number
        }
    }
}
