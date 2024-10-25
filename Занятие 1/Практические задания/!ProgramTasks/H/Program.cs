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
            return (uint)Math.row(number, 2);
        }