namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amount = 1.11;
            int peopleCount = 60;
            int totalMoney = (int)Math.Round(amount * peopleCount);
            Console.WriteLine(totalMoney);
        }
    }
}