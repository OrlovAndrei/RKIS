namespace H
{
    internal class Program
    {
        static int GetSquare(int num)
        {
            return (int)Math.Sqrt(num);
        }
        static void Print(int number)
        {
            Console.WriteLine(number);
        }
        static void Main(string[] args)
        {
            Print(GetSquare(42));
        }

    }
}