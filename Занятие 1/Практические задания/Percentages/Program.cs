namespace Percenages
{
    internal class Programm
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] y = input.Split(" ");

            double money = double.Parse(y[0]);
            double percent = double.Parse(y[1]);
            int month = int.Parse(y[2]);
            
            Console.WriteLine("Этот ввод соответствует вкладу " + money + " рублей под " + percent + "% годовых на " + month + " месяц.");
            
            Console.WriteLine("Через месяц на " + money + " рублей добавится 1% (1/12 от годового процента), значит общая сумма будет " + Calculate(money, percent, month));
        }
        
        static double Calculate(double money, double percent, int month)
        {
            double result = (money * (Math.Pow(1 + percent / 1200, month)));
            return result;

        }
    }   
}