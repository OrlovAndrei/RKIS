namespace H
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Print(GetSquare(42));
        }
        public static void Print(int x)
        {
            Console.WriteLine(x);
        }
        public static int GetSquare(int x)
        {
            return (int)Math.Pow(x, 2);
        }
    }
}