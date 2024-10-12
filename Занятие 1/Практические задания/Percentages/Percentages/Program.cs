namespace Percentages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ввод 100 12 10
            var input = Console.ReadLine()!.Split(" "); //! — это оператор null-forgiving, или null-подавление
            var money = double.Parse(input[0]);
            var percent = double.Parse(input[1]);
            var months = double.Parse(input[2]);
            Console.WriteLine(Calculate(money, percent, months));
        }

        private static double Calculate(double money, double percent, double months)
        {
            return Math.Pow(1 + (percent / 12) / 100, months);
        }
    }
}
