using NUnit.Framework;

namespace TableParser;

[TestFixture]
public class QuotedFieldTaskTests
{
    [TestCase("''", 0, "", 2)]
    [TestCase("'a'", 0, "a", 3)]
    [TestCase("'ab'", 0, "ab", 4)]
    [TestCase("'a''b'", 0, "a'b", 6)] // Обработка экранированных кавычек
    [TestCase("'test string'", 0, "test string", 13)]
    [TestCase("'string with spaces'", 0, "string with spaces", 19)]
    [TestCase("'string with ''quotes'''", 0, "string with 'quotes'", 25)] // Обработка экранированных кавычек
    [TestCase("not a quoted string", 0, "", 0)] // Строка не в кавычках
    [TestCase("'unclosed quote", 0, "unclosed quote", 15)] // Незакрытая кавычка
    [TestCase("", 0, "", 0)] // Пустая строка
    [TestCase(null, 0, null, 0)] // Null строка

    public void Test(string line, int startIndex, string expectedValue, int expectedLength)
    {
        var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
        Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
    }
}

public class Token
{
    public string Value { get; }
    public int StartIndex { get; }
    public int Length { get; }

    public Token(string value, int startIndex, int length)
    {
        Value = value;
        StartIndex = startIndex;
        Length = length;
    }

    public override bool Equals(object obj)
    {
        if (obj is Token other)
        {
            return Value == other.Value && StartIndex == other.StartIndex && Length == other.Length;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, StartIndex, Length);
    }
}


public class QuotedFieldTask
{
    public static Token ReadQuotedField(string line, int startIndex)
    {
        if (string.IsNullOrEmpty(line) || startIndex >= line.Length || line[startIndex] != '\'') return new Token("", startIndex, 0);

        int endIndex = startIndex + 1;
        StringBuilder sb = new StringBuilder();
        bool escape = false;

        while (endIndex < line.Length)
        {
            char c = line[endIndex];
            if (escape)
            {
                sb.Append(c);
                escape = false;
            }
            else if (c == '\'')
            {
                endIndex++;
                break;
            }
            else if (c == '\\')
            {
                escape = true;
            }
            else
            {
                sb.Append(c);
            }
            endIndex++;
        }

        return new Token(sb.ToString(), startIndex, endIndex - startIndex);
    }
}
