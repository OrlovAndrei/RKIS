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
            Console.WriteLine(GetGreetingMessage("Liam", 10.01));
            Console.WriteLine(GetGreetingMessage("Chris", 10000000.5));
            Console.WriteLine(GetGreetingMessage("John", 1));
        }
    }
}
