namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amount = 1.11; //количество биткоинов от одного человека
            int peopleCount = 60; // количество человек
            double totalMoney = amount * peopleCount;
            int totalBitcoins = (int)Math.Round(totalMoney);
            Console.WriteLine(totalMoney);
        }
    }
}