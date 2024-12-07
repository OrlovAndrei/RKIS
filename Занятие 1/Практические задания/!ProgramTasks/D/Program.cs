namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amount = 1.11; // количество биткоинов от одного человека
            int peopleCount = 60; // количество человек

            // Исправление ошибки: сначала умножаем, затем приводим к int
            int totalMoney = (int)(amount * peopleCount); // Приводим результат к int

            Console.WriteLine(totalMoney);
        }
    }
}