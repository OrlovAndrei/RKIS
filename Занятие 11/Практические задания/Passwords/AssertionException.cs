namespace Passwords
{
    public class CaseAlternatorTask
    {
        // Тесты будут вызывать этот метод
        public static List<string> AlternateCharCases(string lowercaseWord)
        {
            var result = new List<string>();
            AlternateCharCases(lowercaseWord.ToCharArray(), 0, result);
            return result;
        }

        static void AlternateCharCases(char[] word, int startIndex, List<string> result)
        {
            // Базовый случай: если достигли конца строки, добавить текущее слово в результат
            if (startIndex >= word.Length)
            {
                result.Add(new string(word));
                return;
            }

            // Текущий символ
            char currentChar = word[startIndex];

            // Если текущий символ не буква, пропускаем его
            if (!char.IsLetter(currentChar))
            {
                AlternateCharCases(word, startIndex + 1, result);
                return;
            }

            // Меняем регистр текущего символа
            word[startIndex] = char.ToUpper(currentChar);
            AlternateCharCases(word, startIndex + 1, result);

            // Возвращаемся к исходному значению и меняем регистр обратно
            word[startIndex] = char.ToLower(currentChar);
            AlternateCharCases(word, startIndex + 1, result);
        }
    }
}