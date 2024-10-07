namespace H
{
    internal class Program
    {
        static double GetSquare(int number)
        {
            return Math.Pow(Convert.ToDouble(number),2);
        } 
        static void Print(double number)
        {
            Console.WriteLine(number.ToString());
        }
        static void Main(string[] args)
        {
            Print(GetSquare(42));
        }
    }
}