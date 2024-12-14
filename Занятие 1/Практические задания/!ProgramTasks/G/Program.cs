namespace G
{
    internal class Program
    {
        private static string GetGreetingMessage(string name, double salary)
        {
            // возвращает "Hello, <name>, your salary is <salary>"
            // Округляем зарплату до ближайшего целого числа вверх
            int roundedSalary = (int)Math.Ceiling(salary);
            return $"Hello, {name}, your salary is {roundedSalary}";
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetGreetingMessage("Student", 10.01));
            Console.WriteLine(GetGreetingMessage("Bill Gates", 10000000.5));
            Console.WriteLine(GetGreetingMessage("Steve Jobs", 1));
        }
    }
}