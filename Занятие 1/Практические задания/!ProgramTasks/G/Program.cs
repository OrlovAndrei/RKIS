namespace G
{
    internal class Program
    {
        static void Main()
        {
            string name = "Иван";
            double salary = 1234.56;
            string result = GetGreeting(name, salary);
            Console.WriteLine(result);
        }

        static string GetGreeting(string name, double salary)
        {
            // Округляем зарплату до ближайшего целого числа вверх
            int roundedSalary = (int)Math.Ceiling(salary);
            return $"Hello, {name}, your salary is {roundedSalary}";
        }
    }
}