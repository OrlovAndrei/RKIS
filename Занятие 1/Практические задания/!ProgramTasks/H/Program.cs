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
            return (int)Math.row(number, 2);
        }
        static void Print(int number) {
            Console.WriteLine(number);
        }
    }
}
