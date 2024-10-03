namespace G
{
    internal class Program
    {
        private static string GetGreetingMessage(string name, double salary)
        {
            // возвращает "Hello, <name>, your salary is <salary>"
            ...
        }

        static void Main(string[] args)
        {
            string a = "Student";
            string b = "Bill Gates";
            string c = "Steve Jobs";
            double a1 = 10.01;
            double b1 = 10000000.5;
            int c1 = 1;
            Console.WriteLine(GetGreetingMessage($"Hello {a}, your salary is {a1}"));
            Console.WriteLine(GetGreetingMessage($"Hello {b}, your salary is {b1}"));
            Console.WriteLine(GetGreetingMessage($"Hello {c}, your salary is {c1}"));
            
        }
    }
}