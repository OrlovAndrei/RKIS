namespace G
{
    internal class Program
    {
        private static string GetGreetingMessage(string name, double salary)
        {
            // Округляем зарплату вверх до ближайшего целого числа
            int roundedSalary = (int)Math.Ceiling(salary);

            // Формируем и возвращаем строку
            return $"Hello, {name}, your salary is {roundedSalary}";
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetGreetingMessage("Student", 10.01));       // Hello, Student, your salary is 11
            Console.WriteLine(GetGreetingMessage("Bill Gates", 10000000.5)); // Hello, Bill Gates, your salary is 10000001
            Console.WriteLine(GetGreetingMessage("Steve Jobs", 1));         // Hello, Steve Jobs, your salary is 1
        }
    }
}