using NUnit.Framework;

namespace TableParser;

[TestFixture]
public class FieldParserTaskTests
{
    public static void Test(string input, string[] expectedResult)
    {
        var actualResult = FieldsParserTask.ParseLine(input);
        Assert.AreEqual(expectedResult.Length, actualResult.Count);
        for (int i = 0; i < expectedResult.Length; ++i)
        {
            Assert.AreEqual(expectedResult[i], actualResult[i].Value);
        }
    }

    [TestCase("text", new[] { "text" })]
    [TestCase("hello world", new[] { "hello", "world" })]
    [TestCase("123 456", new[] { "123", "456" })]
    [TestCase("'quoted text'", new[] { "quoted text" })]
    [TestCase("text 'quoted'", new[] { "text", "quoted" })]
    [TestCase("'quoted' text", new[] { "quoted", "text" })]
    [TestCase("'quoted text' with more text", new[] { "quoted text", "with", "more", "text" })]
    [TestCase("text with 'quoted' text", new[] { "text", "with", "quoted", "text" })]
    [TestCase("'q1' 'q2' 'q3'", new[] { "q1", "q2", "q3" })]
    [TestCase("1 'q1' 2 'q2'", new[] { "1", "q1", "2", "q2" })]
    [TestCase("", new string[0])]
    [TestCase(null, new string[0])]
    [TestCase(" 'quoted' ", new[] { "quoted" })] // Пробелы вокруг
    [TestCase("'a''b'", new[] { "a'b" })]          // Экранированная кавычка
    [TestCase("'a\\'b'", new[] { "a'b" })]         // Экранированная кавычка с escape символом
    public static void RunTests(string input, string[] expectedOutput)
    {
        Test(input, expectedOutput);
    }
}

public class FieldsParserTask
{
    public static List<Token> ParseLine(string line)
    {
        List<Token> tokens = new List<Token>();
        int index = 0;
        while (index < line?.Length ?? 0)
        {
            index = SkipSpaces(line, index);
            if (index >= line.Length) break;

            if (line[index] == '\'')
            {
                Token token = ReadQuotedField(line, index);
                tokens.Add(token);
                index = token.GetIndexNextToToken();
            }
            else
            {
                Token token = ReadField(line, index);
                tokens.Add(token);
                index = token.GetIndexNextToToken();
            }
        }
        return tokens;
    }

    private static int SkipSpaces(string line, int startIndex)
    {
        while (startIndex < line.Length && char.IsWhiteSpace(line[startIndex]))
        {
            startIndex++;
        }
        return startIndex;
    }

    private static Token ReadField(string line, int startIndex)
    {
        int endIndex = startIndex;
        while (endIndex < line.Length && !char.IsWhiteSpace(line[endIndex]) && line[endIndex] != '\'')
        {
            endIndex++;
        }
        return new Token(line.Substring(startIndex, endIndex - startIndex), startIndex, endIndex - startIndex);
    }

    private static Token ReadQuotedField(string line, int startIndex)
    {
        return QuotedFieldTask.ReadQuotedField(line, startIndex);
    }
}

// ... (Token class and QuotedFieldTask class from previous answer) ...

public static class TokenExtensions
{
    public static int GetIndexNextToToken(this Token token)
    {
        return token.StartIndex + token.Length;
    }
}
