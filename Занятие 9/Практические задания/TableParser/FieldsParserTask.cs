using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class FieldParserTaskTests
    {
        public static void Test(string input string[] expectedResult)
        {
            var actualResult = FieldParserTask.ParseLine(input)
            Assert.AreEqual(expectedResult.Length, actualResult.Count);
            for (int i = 0; i < expectedResult.Length; ++i)
            {
                Assert.AreEqual(expectedResult[i], actualResult[i].Value);
            }
        }

        [TestCase("text", new[] { "text" })]
        [TestCase("hello world", new[] { "hello", "world" })]
        public static void RunTests(string input, string[] expectedOutput)
        {
            Test(input, expectedOutput);
        }
    }
    public static List<Token> ParseLine(string line)
    {
        return new List<Token> { ReadQuotedField(line, 0) };
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

public class Token
{
    public string Value { get; set; }
    public int StartIndex { get; set; }
    public int Length { get; set; }

    public Token(string value, int startIndex, int length)
    {
        Value = value;
        StartIndex = startIndex;
        Length = length;
    }
}

public static class QuotedFieldTask
{
    public static Token ReadQuotedField(string input, int startIndex)
    {
        if (input[startIndex] != '"')
            throw new ArgumentException("Ожидается открывающая кавычка.");

        int endQuote = input.IndexOf('"', startIndex + 1);

        if (endQuote == -1)
            return new Token(input.Substring(startIndex + 1), startIndex + 1, input.Length - startIndex - 1);

        return new Token(input.Substring(startIndex + 1, endQuote - startIndex - 1), startIndex + 1, endQuote - startIndex - 1);
    }
}

[TestFixture]
public class QuotedFieldTests
{
    [TestCase("\"abc\"", 0, ExpectedResult = "abc")]
    [TestCase("\"ab\"cd\"", 4, ExpectedResult = "cd")]
    [TestCase("\"a\\\"b\"", 0, ExpectedResult = "a\"b")]
    [TestCase("\"abc", 0, ExpectedResult = "abc")]
    [TestCase("", 0, ExpectedException = typeof(ArgumentException))]
    [TestCase("abc", 0, ExpectedException = typeof(ArgumentException))]
    public string TestReadQuotedField(string input, int startIndex)
    {
        return QuotedFieldTask.ReadQuotedField(input, startIndex).Value;
    }
}
}
