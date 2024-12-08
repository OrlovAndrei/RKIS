using System.Collections.Generic;
using NUnit.Framework;

namespace TableParser

{
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
        [TestCase("", new string[0])]
        [TestCase("\'\"\'", new[] { "\"" })]
        [TestCase("\"\"", new[] { "" })]
        [TestCase("ab", new[] { "ab" })]
        [TestCase("a b", new[] { "a", "b" })]
        [TestCase("a  b", new[] { "a", "b" })]
        [TestCase(" a b ", new[] { "a", "b" })]
        [TestCase("a 'b'", new[] { "a", "b" })]
        [TestCase("'b' a", new[] { "b", "a" })]
        [TestCase("b \"a", new[] { "b", "a" })]
        [TestCase("\'a ", new[] { "a " })]
        [TestCase("\"\'b\'\" c", new[] { "'b'", "c" })]
        [TestCase("\'\"a\"\' b", new[] { "\"a\"", "b" })]
        [TestCase(@"'a''b'", new[] { "a", "b" })]
        [TestCase(@"'a\\'", new[] { @"a\" })]
        [TestCase(@"'\'a'", new[] { @"'a" })]
        [TestCase(@"""\""a""", new[] { @"""a" })]
        public static void RunTests(string input, string[] expectedOutput)
        {

            Test(input, expectedOutput);
        }
    }
}

public class FieldsParserTask
{
	public class FieldsParserTask
    {

        public static List<Token> ParseLine(string line)
        {
            List<Token> list = new List<Token>();
            Token token = new Token("", 0, 0);

            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == '\'' || line[i] == '\"')
                {
                    token = ReadQuotedField(line, i);
                }

                else
                    token = ReadField(line, i);
                list.Add(token);

                if (token.Length > 1)
                {
                    i += token.Length - 1;
                }

            }
            return CreateFinalList(list);
        }

        public static List<Token> CreateFinalList(List<Token> list)
        {
            List<Token> list1 = new List<Token>();

            foreach (var l in list)
            {
                if (l.Length > 0)
                {
                    list1.Add(l);
                }

            }
            return list1;
        }

        private static Token ReadField(string line, int startIndex)
        {
            var word = "";

            for (var i = startIndex; i < line.Length; i++)
            {
                if (line[i] == '\'' || line[i] == '\"' || line[i] == ' ')
                {
                    break;
                }

                word += line[i];
            }

            return new Token(word, startIndex, word.Length);
        }

        public static Token ReadQuotedField(string line, int startIndex)
        {
            return QuotedFieldTask.ReadQuotedField(line, startIndex);

        }
	}
}