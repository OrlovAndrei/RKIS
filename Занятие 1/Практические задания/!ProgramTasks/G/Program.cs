using System;

namespace G
{
    internal class Program
    {
        private static string GetGreetingMessage(string name, double salary)
        {
            // Формируем сообщение с использованием интерполяции строк
            return $"Hello, {name}, your salary is {salary:F2}"; // Ограничиваем вывод зарплаты до 2 знаков после запятой
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetGreetingMessage("Student", 10.01));
            Console.WriteLine(GetGreetingMessage("Bill Gates", 10000000.5));
            Console.WriteLine(GetGreetingMessage("Steve Jobs", 1));
        }
    }
}