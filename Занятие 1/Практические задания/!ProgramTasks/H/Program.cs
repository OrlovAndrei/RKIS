namespace H
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Print(GetSquare(42));
        }

        static private void Print(int number) {
            Console.WriteLine(number);
        }

        static private int GetSquare(int num) {
            return num * num
        }
    }
}
