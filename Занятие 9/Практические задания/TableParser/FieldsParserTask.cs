using System.Collections.Generic;
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
    [TestCase("", new string[0])] // Пустая строка
	[TestCase("\"quoted\"", new[] { "quoted" })] // Поле в кавычках
	[TestCase("\"he said \\\"hello\\\"\"", new[] { "he said \"hello\"" })] // Экранированные кавычки
	[TestCase("  one    two  ", new[] { "one", "two" })] // Пробелы между полями
	[TestCase("word \"quoted field\" last", new[] { "word", "quoted field", "last" })] // Смешанные поля
    public static void RunTests(string input, string[] expectedOutput)
    {
        // Тело метода изменять не нужно
        Test(input, expectedOutput);
    }
}

public class FieldsParserTask
{
    public static List<Token> ParseLine(string line)
    {
        var tokens = new List<Token>();
        int index = 0;

        while (index < line.Length)
        {
            SkipSpaces(line, ref index);
            if (index >= line.Length) break;

            var token = line[index] == '"' 
                ? ReadQuotedField(line, index) 
                : ReadField(line, index);

            tokens.Add(token);
            index = token.GetIndexNextToToken();
        }

        return tokens;
    }

    private static void SkipSpaces(string line, ref int index)
    {
        while (index < line.Length && char.IsWhiteSpace(line[index]))
            index++;
    }

    private static Token ReadField(string line, int startIndex)
    {
        int endIndex = startIndex;
        while (endIndex < line.Length && !char.IsWhiteSpace(line[endIndex]))
            endIndex++;

        return new Token(line, startIndex, endIndex - startIndex);
    }

    public static Token ReadQuotedField(string line, int startIndex)
    {
        return QuotedFieldTask.ReadQuotedField(line, startIndex);
    }
}