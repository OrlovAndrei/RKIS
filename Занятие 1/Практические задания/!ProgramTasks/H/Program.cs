namespace H
{
    internal class Program
    {
        static int GetSquere(int number)
        {
            return Math.Pow(number, 2);
        }
        static void Print(int number)
        {
            Console.WriteLine(number.ToString());
        }
        static void Main(string[] args) 
        {
            Print(GetSquare(42));
        }
    }
}