namespace H
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Print(GetSquare(42));
        }
        static int GetSqure(int number)
        {
            return (int)Math.Pow(number, 2);
        }
    }
}