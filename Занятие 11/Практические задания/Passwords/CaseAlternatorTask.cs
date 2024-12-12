namespace Passwords;

public class CaseAlternatorTask
    {
        // Тесты будут вызывать этот метод
        public static List<string> AlternateCharCases(string lowercaseWord)
        {
            var result = new List<string>();
            AlternateCharCases(lowercaseWord.ToCharArray(), 0, result);
            return result.OrderBy(s => s).Distinct().ToList(); // сортировка и удаление дубликатов
        }

        static void AlternateCharCases(char[] word, int startIndex, List<string> result)
        {
            if (startIndex == word.Length)
            {
                result.Add(new string(word));
                return;
            }

            if (char.IsLetter(word[startIndex]))
            {
                // Вариант с маленькой буквой
                AlternateCharCases(word, startIndex + 1, result);

                // Вариант с большой буквой
                char originalChar = word[startIndex];
                word[startIndex] = char.ToUpper(originalChar);
                AlternateCharCases(word, startIndex + 1, result);
                word[startIndex] = originalChar; // Восстанавливаем исходный символ
            }
            else
            {
                AlternateCharCases(word, startIndex + 1, result);
            }
        }
    }
}
