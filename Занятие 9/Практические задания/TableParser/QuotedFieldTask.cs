using NUnit.Framework;
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
            Assert.AreEqual(actualToken, new Token(expectedValue, startIndex, expectedLength));
        }

        public void MyTests(string line, int startIndex, string expectedValue, int expectedLength)
        {
            var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
            Assert.AreEqual(actualToken, new Token(expectedValue, startIndex, expectedLength));
        }
    }

    class QuotedFieldTask
    {
        private static bool NewCharIsEcran(StringBuilder builder, char currentChar, bool flag)
        {
            if (flag)
            {
                builder.Append(currentChar);
                return false;
            }
            return true;
        }

        public static Token ReadQuotedField(string line, int startIndex)
        {
            var builder = new StringBuilder();
            var flag = false;
            var currentIndex = startIndex;
            var charFirst = line[currentIndex++];

            while (currentIndex < line.Length)
            {
                var currentChar = line[currentIndex++];

                if (currentChar == '\\')
                {
                    flag = NewCharIsEcran(builder, currentChar, flag);
                }

                else if (currentChar == charFirst)
                {
                    if (!flag)
                    {
                        break;
                    }

                    flag = NewCharIsEcran(builder, currentChar, flag);
                }
                else builder.Append(currentChar);
            }
            return new Token(builder.ToString(), startIndex, currentIndex - startIndex);
        }
    }
}
