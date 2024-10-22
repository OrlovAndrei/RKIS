namespace H
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Print(GetSquare(42));
        }
        public static int GetSquare(int a)
        {
            return (int)Math.Pow(a, 2);
        }
        static void Print(int a)
        {
            Console.WriteLine(a.ToString());
        }
    }
}