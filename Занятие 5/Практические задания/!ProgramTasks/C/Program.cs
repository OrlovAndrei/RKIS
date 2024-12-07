using System.Text.RegularExpressions;

namespace C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "США: 329957441, Франция - 68859599, Индия; 1375100000, Япония 125950000";

            Console.WriteLine("Оригинальная строка:");
            Console.WriteLine(input);

            string pattern = @"[ ::,-]+";
            string output = Regex.Replace(input, pattern, "\t");

            Console.WriteLine("\nПреобразованная строка:");
            Console.WriteLine(output);

        }
    }
}