namespace I
{
    internal class Program
    {
        // Метод для получения второй половины строки и удаления пробелов
        static string GetLastHalf(string text)
        {
            // Находим середину строки
            int midIndex = text.Length / 2;
            
            // Извлекаем вторую половину и удаляем пробелы
            string secondHalf = text.Substring(midIndex).Replace(" ", "");

            return secondHalf;
        }

        static void Main(string[] args)
        {
            // Примеры использования
            Console.WriteLine(GetLastHalf("I love CSharp!")); // Выведет: CSharp!
            Console.WriteLine(GetLastHalf("1234567890")); // Выведет: 567890
            Console.WriteLine(GetLastHalf("до ре ми фа соль ля си")); // Выведет: сольляси
        }
    }
}