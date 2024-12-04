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
        public void Test(string line, int startIndex, string expectedValue, int expectedLength)
        {
            var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
            Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
        }
    }

    public class QuotedFieldTask
    {
        public static Token ReadQuotedField(string line, int startIndex)
        {
            var builder = new StringBuilder();
            var isEscaped = false;
            var currentIndex = startIndex + 1;
            var quoteChar = line[startIndex];

            while (currentIndex < line.Length)
            {
                var currentChar = line[currentIndex++];

                if (isEscaped)
                {
                    builder.Append(currentChar);
                    isEscaped = false;
                }
                else if (currentChar == '\\')
                {
                    isEscaped = true;
                }
                else if (currentChar == quoteChar)
                {
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