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

        public void Test(string inputLine, int startPos, string expectedResult, int expectedLen)
        {
            var resultToken = QuotedFieldTask.ReadQuotedField(inputLine, startPos);
            Assert.AreEqual(resultToken, new Token(expectedResult, startPos, expectedLen));
        }

        public void MyTests(string inputLine, int startPos, string expectedResult, int expectedLen)
        {
            var resultToken = QuotedFieldTask.ReadQuotedField(inputLine, startPos);
            Assert.AreEqual(resultToken, new Token(expectedResult, startPos, expectedLen));
        }
    }

    class QuotedFieldTask
    {
        private static bool HandleEscapeChar(StringBuilder sb, char currentChar, bool isEscaped)
        {
            if (isEscaped)
            {
                sb.Append(currentChar);
                return false;
            }
            return true;
        }

        public static Token ReadQuotedField(string inputLine, int startPos)
        {
            var sb = new StringBuilder();
            var isEscaped = false;
            var currentPos = startPos;
            var quoteChar = inputLine[currentPos++];

            while (currentPos < inputLine.Length)
            {
                var currentChar = inputLine[currentPos++];

                if (currentChar == '\\')
                {
                    isEscaped = HandleEscapeChar(sb, currentChar, isEscaped);
                }
                else if (currentChar == quoteChar)
                {
                    if (!isEscaped)
                    {
                        break;
                    }

                    isEscaped = HandleEscapeChar(sb, currentChar, isEscaped);
                }
                else sb.Append(currentChar);
            }
            return new Token(sb.ToString(), startPos, currentPos - startPos);
        }
    }
}
