using System;
using System.Text.RegularExpressions;

namespace C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "Россия: 145872256, США - 331883986, Индия; 1380004385, Бразилия 213993437";

            Console.WriteLine("Оригинальная строка:");
            Console.WriteLine(input);

            string pattern = @"[ :;,-]+";
            string output = Regex.Replace(input, pattern, "\t");

            Console.WriteLine("\nПреобразованная строка:");
            Console.WriteLine(output);
        }
    }
}
