namespace H
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Print(GetSquare(42));
        }
        static int GetSquare(int number)
        {
            return number * number;
        }
        static void Print(int result)
        {
            Console.WriteLine(result);
        }
    }
}