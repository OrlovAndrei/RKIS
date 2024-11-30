using System.Text;
using NUnit.Framework;

namespace TableParser;

[TestFixture]
public class QuotedFieldTaskTests
{
    [TestCase("''", 0, "", 2)]
    [TestCase("'a'", 0, "a", 3)]
    [TestCase("'abc'", 0, "abc", 5)]
    [TestCase("'abc", 0, "abc", 4)]
    [TestCase("xyz'abc'", 3, "abc", 5)]
    [TestCase("\"abc\"", 0, "abc", 5)]
    [TestCase("\"abc", 0, "abc", 4)]
    [TestCase("'", 0, "", 1)]
    [TestCase("'abc'def", 0, "abc", 5)]
    [TestCase("abc'def'", 3, "def", 5)]
    [TestCase(@"'a\' b'", 0, "a' b", 7)]
    [TestCase(@"'a\\b'", 0, @"a\b", 6)]
    [TestCase(@"'a\\\'b'", 0, @"a\'b", 8)]
    [TestCase("'New\nLine'", 0, "New\nLine", 10)]
    public void Test(string line, int startIndex, string expectedValue, int expectedLength)
    {
        var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
        Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
    }

    [Test]
    public void TokenWithSlash()
    {
        var line = @"'a\' b'";
        var expectedToken = new Token("a' b", 0, 7);
        var actualToken = QuotedFieldTask.ReadQuotedField(line, 0);
        Assert.AreEqual(expectedToken, actualToken);
    }
}

class QuotedFieldTask
{
    public static Token ReadQuotedField(string line, int startIndex)
    {
        char quoteChar = line[startIndex];
        int currentIndex = startIndex + 1;
        var sb = new StringBuilder();

        while (currentIndex < line.Length)
        {
            char c = line[currentIndex];

            if (c == '\\' && currentIndex + 1 < line.Length)
            {
                currentIndex++;
                sb.Append(line[currentIndex]);
            }
            else if (c == quoteChar)
            {
                currentIndex++;
                break;
            }
            else
            {
                sb.Append(c);
            }
            currentIndex++;
        }

        int length = currentIndex - startIndex;
        string value = sb.ToString();

        return new Token(value, startIndex, length);
    }
}