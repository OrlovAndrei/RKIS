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
        public void Test(string Line, int startIndex, string expectedValue, int expectedLength)
        {
            var parsedToken = QuotedFieldTask.ReadQuotedField(Line, startIndex);
            Assert.AreEqual(parsedToken, new Token(expectedValue, startIndex, expectedLength));
        }

        public void MyTests(string Line, int startIndex, string expectedValue, int expectedLength)
        {
            var parsedToken = QuotedFieldTask.ReadQuotedField(Line, startIndex);
            Assert.AreEqual(parsedToken, new Token(expectedValue, startIndex, expectedLength));
        }
    }

    class QuotedFieldTask
    {
        private static bool HandleEscapeCharacter(StringBuilder stringBuilder, char currentCharacter, bool isEscaped)
        {
            if (isEscaped)
            {
                stringBuilder.Append(currentCharacter);
                return false;
            }
            return true;
        }

        public static Token ReadQuotedField(string Line, int startIndex)
        {
            var stringBuilder = new StringBuilder();
            var isEscaped = false;
            var currentIndex = startIndex;
            var firstQuoteChar = Line[currentIndex++];

            while (currentIndex < Line.Length)
            {
                var currentChar = Line[currentIndex++];

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

            return new Token(stringBuilder.ToString(), startIndex, currentIndex - startIndex);
        }

    }
}