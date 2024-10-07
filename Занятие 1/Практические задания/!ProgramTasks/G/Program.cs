namespace G
{
    internal class Program
    {
        private static string GetGreetingMessage(string name, double salary)
        {
            string a = "Hello, " + name + ", your salary is " + (int)Math.Ceiling(salary);
            return a;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetGreetingMessage("Student", 10.01));
            Console.WriteLine(GetGreetingMessage("Bill Gates", 10000000.5));
            Console.WriteLine(GetGreetingMessage("Steve Jobs", 1));
        }
    }
}