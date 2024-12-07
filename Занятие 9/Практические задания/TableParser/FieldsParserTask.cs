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
     [TestCase("field1,field2", new[] { "field1", "field2" })]
    [TestCase("'field with spaces'", new[] { "field with spaces" })]
    [TestCase("'escaped \'quote\''", new[] { "escaped 'quote'" })]
    [TestCase("'unclosed quote", new[] { "unclosed quote" })]
    [TestCase("field1,'field2 with spaces'", new[] { "field1", "field2 with spaces" })]
    [TestCase("", new string[] { })]
    [TestCase("'field with, comma'", new[] { "field with, comma" })]
    [TestCase("field1,,field3", new[] { "field1", "", "field3" })]
    [TestCase(",,", new[] { "", "", "" })]
    [TestCase("'nested \"quote\" example'", new[] { "nested \"quote\" example" })]
    [TestCase("field1 , field2", new[] { "field1", "field2" })]
    [TestCase(" \"leading and trailing spaces\" ", new[] { "leading and trailing spaces" })]
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
		return new List<Token> { ReadQuotedField(line, 0) }; // сокращенный синтаксис для инициализации коллекции.
	}
        
	private static Token ReadField(string line, int startIndex)
	{
		return new Token(line, 0, line.Length);
	}

	public static Token ReadQuotedField(string line, int startIndex)
	{
		return QuotedFieldTask.ReadQuotedField(line, startIndex);
	}
}