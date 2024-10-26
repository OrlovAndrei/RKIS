using System;

namespace I
{
    internal class Program
    {
        static string GetLastHalf(string text)
        {
            // Удаляем пробелы из строки
            string trimmedText = text.Replace(" ", "");

            // Находим индекс начала второй половины
            int halfLength = trimmedText.Length / 2;

            // Возвращаем вторую половину строки
            return trimmedText.Substring(halfLength);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetLastHalf("I love CSharp!")); // Вывод: "CSharp!"
            Console.WriteLine(GetLastHalf("1234567890")); // Вывод: "567890"
            Console.WriteLine(GetLastHalf("до ре ми фа соль ля си")); // Вывод: "сольляси"
        }
    }
}