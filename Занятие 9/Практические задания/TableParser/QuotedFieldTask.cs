using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class QuotedFieldParserTests
    {
        // Тесты для проверки парсинга полей в кавычках.
        [TestCase("''", 0, "", 2)]
        [TestCase("'a'", 0, "a", 3)]
        [TestCase("'a\\' b", 0, "a' b", 7)]
        public void ExecuteTest(string inputLine, int startIdx, string expectedOutput, int expectedLen)
        {
            var actualToken = QuotedFieldTask.GetQuotedField(inputLine, startIdx);
            Assert.AreEqual(new Token(expectedOutput, startIdx, expectedLen), actualToken);
        }
    }

    public class QuotedFieldTask
    {
        // Метод для чтения поля в кавычках.
        public static Token GetQuotedField(string inputLine, int startIdx)
        {
            var stringBuilder = new StringBuilder();
            var isCharacterEscaped = false;
            var currentIdx = startIdx + 1; // Пропуск начальной кавычки.
            var quote = inputLine[startIdx];

            while (currentIdx < inputLine.Length)
            {
            var currentChar = inputLine[currentIdx++];

            if (isCharacterEscaped)
            {
                // Если предыдущий символ был '\', текущий добавляется в поле.
            stringBuilder.Append(currentChar);
            isCharacterEscaped = false;
            }
        else if (currentChar == '\\')
            {
                // Символ '\' задаёт экранирование следующего символа.
            isCharacterEscaped = true;
            }
        else if (currentChar == quote)
            {
                // Если текущая кавычка совпадает с начальной, поле завершено.
            break;
            }
        else
            {
            stringBuilder.Append(currentChar);
            }
        }

	return new Token(stringBuilder.ToString(), startIdx, currentIdx - startIdx);
        }
}
