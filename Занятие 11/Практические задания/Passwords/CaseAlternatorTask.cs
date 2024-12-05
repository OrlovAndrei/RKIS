namespace Passwords;

public class CaseAlternatorTask
{
	//Тесты будут вызывать этот метод
	public static List<string> AlternateCharCases(string lowercaseWord)
	{
		var result = new List<string>();
		AlternateCharCases(lowercaseWord.ToCharArray(), 0, result);
		return result;
	}

	static void AlternateCharCases(char[] word, int startIndex, List<string> result)
	{
		// Если дошли до конца слова, добавляем текущую комбинацию в результат
            if (startIndex == word.Length)
            {
                result.Add(new string(word));
                return;
            }

            // Рекурсивно обходим оставшиеся символы
            AlternateCharCases(word, startIndex + 1, result);

            // Если текущий символ — буква, меняем регистр и продолжаем
            if (char.IsLetter(word[startIndex]))
            {
                // Меняем регистр текущей буквы
                word[startIndex] = char.IsLower(word[startIndex])
                    ? char.ToUpper(word[startIndex])
                    : char.ToLower(word[startIndex]);

                // Рекурсивно обходим оставшиеся символы с измененным регистром
                AlternateCharCases(word, startIndex + 1, result);

                // Возвращаем символ в исходный регистр
                word[startIndex] = char.IsLower(word[startIndex])
                    ? char.ToUpper(word[startIndex])
                    : char.ToLower(word[startIndex]);
			}
	}
}