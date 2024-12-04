using System.Text;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class QuotedFieldTaskTests
    {
        // Тесты для проверки парсинга полей в кавычках.
        [TestCase("''", 0, "", 2)]
        [TestCase("'a'", 0, "a", 3)]
        [TestCase("'a\\\' b'", 0, "a' b", 7)]
        public void Test(string line, int startIndex, string expectedValue, int expectedLength)
        {
            var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
            Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
        }
    }

    public class QuotedFieldTask
    {
        // Метод для чтения поля в кавычках.
        public static Token ReadQuotedField(string line, int startIndex)
        {
            var builder = new StringBuilder();
            var isEscaped = false;
            var currentIndex = startIndex + 1; // Пропуск начальной кавычки.
            var quoteChar = line[startIndex];

            while (currentIndex < line.Length)
            {
                var currentChar = line[currentIndex++];

                if (isEscaped)
                {
                    // Если предыдущий символ был '\', текущий добавляется в поле.
                    builder.Append(currentChar);
                    isEscaped = false;
                }
                else if (currentChar == '\\')
                {
                    // Символ '\' задаёт экранирование следующего символа.
                    isEscaped = true;
                }
                else if (currentChar == quoteChar)
                {
                    // Если текущая кавычка совпадает с начальной, поле завершено.
                    break;
                }
                else
                {
                    builder.Append(currentChar);
                }
            }

            return new Token(builder.ToString(), startIndex, currentIndex - startIndex);
        }
    }
}
