namespace G
{
    internal class Program
    {
        private static string GetGreetingMessage(string name, double salary)
        {
            int roundedSalary = (int)Math.Ceiling(salary);
            return $"Hello, {name}, your salary is {roundedSalary}";
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetGreetingMessage("Нармиша", 10.01));
            Console.WriteLine(GetGreetingMessage("Мадиша", 10000000.5));
            Console.WriteLine(GetGreetingMessage("Даша", 1));
        }
    }
}