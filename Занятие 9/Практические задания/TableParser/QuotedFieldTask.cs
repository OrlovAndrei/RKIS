using System.Text;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class QuotedFieldTaskTests
    {
        [TestCase("''", 0, "", 2)]
        [TestCase("'a'", 0, "a", 3)]
        [TestCase("'a\\\' b'", 0, "a' b", 7)]
        public void Test(string inputLine, int startIndex, string expectedValue, int expectedLength)
        {
            var parsedToken = QuotedFieldTask.ReadQuotedField(inputLine, startIndex);
            Assert.AreEqual(parsedToken, new Token(expectedValue, startIndex, expectedLength));
        }

        public void MyTests(string inputLine, int startIndex, string expectedValue, int expectedLength)
        {
            var parsedToken = QuotedFieldTask.ReadQuotedField(inputLine, startIndex);
            Assert.AreEqual(parsedToken, new Token(expectedValue, startIndex, expectedLength));
        }
    }

    class QuotedFieldTask
    {
        public static Token ReadQuotedField(string inputLine, int startIndex)
        {
            var stringBuilder = new StringBuilder();
            var isEscaped = false;
            var currentIndex = startIndex;
            var firstQuoteChar = inputLine[currentIndex++];

            // Обработка символов строки
            while (currentIndex < inputLine.Length)
            {
                var currentChar = inputLine[currentIndex++];

                if (currentChar == '\\')
                {
                    isEscaped = HandleEscapeCharacter(stringBuilder, currentChar, isEscaped);
                }
                else if (currentChar == firstQuoteChar)
                {
                    if (!isEscaped)
                    {
                        break;
                    }

                    isEscaped = HandleEscapeCharacter(stringBuilder, currentChar, isEscaped);
                }
                else
                {
                    stringBuilder.Append(currentChar);
                }
            }

            // Возврат токена с результатами
            return new Token(stringBuilder.ToString(), startIndex, currentIndex - startIndex);
        }

        // Метод обработки экранированных символов
        private static bool HandleEscapeCharacter(StringBuilder stringBuilder, char currentCharacter, bool isEscaped)
        {
            if (isEscaped)
            {
                stringBuilder.Append(currentCharacter);
                return false;
            }
            return true;
        }
    }
}
