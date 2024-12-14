namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amount = 1.11; //количество биткоинов от одного человека
            int peopleCount = 60; // количество человек
            int totalMoney = Math.Round(amount * peopleCount);
            Console.WriteLine(totalMoney);
        }
    }
}
