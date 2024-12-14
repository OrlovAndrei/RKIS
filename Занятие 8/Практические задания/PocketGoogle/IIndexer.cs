using System.Collections.Generic;
using NUnit.Framework;

namespace TableParser

{
    [TestFixture]
    public class FieldParserTaskTests
    {
        public static void Test(string inputLine, string[] expectedOutput)
        {
            var actualTokens = FieldsParserTask.ParseLine(inputLine);
            Assert.AreEqual(expectedOutput.Length, actualTokens.Count);

            for (int index = 0; index < expectedOutput.Length; ++index)
            {
                Assert.AreEqual(expectedOutput[index], actualTokens[index].Value);
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
            // Тело метода изменять не нужно
            Test(input, expectedOutput);
        }
    }


    public class FieldsParserTask
    {
        public static List<Token> ParseLine(string inputLine)
        {
            List<Token> tokenList = new List<Token>();
            Token currentToken = new Token("", 0, 0);

            for (var currentIndex = 0; currentIndex < inputLine.Length; currentIndex++)
            {
                if (inputLine[currentIndex] == '\'' || inputLine[currentIndex] == '\"')
                {
                    currentToken = ReadQuotedField(inputLine, currentIndex);
                }
                else
                {
                    currentToken = ReadField(inputLine, currentIndex);
                }

                tokenList.Add(currentToken);

                if (currentToken.Length > 1)
                {
                    currentIndex += currentToken.Length - 1;
                }
            }
            return CreateFinalList(tokenList);
        }

        public static List<Token> CreateFinalList(List<Token> tokenList)
        {
            List<Token> filteredTokenList = new List<Token>();

            foreach (var token in tokenList)
            {
                if (token.Length > 0)
                {
                    filteredTokenList.Add(token);
                }
            }
            return filteredTokenList;
        }

        private static Token ReadField(string inputLine, int startIndex)
        {
            var word = "";

            for (var currentIndex = startIndex; currentIndex < inputLine.Length; currentIndex++)
            {
                if (inputLine[currentIndex] == '\'' || inputLine[currentIndex] == '\"' || inputLine[currentIndex] == ' ')
                {
                    break;
                }

                word += inputLine[currentIndex];
            }

            return new Token(word, startIndex, word.Length);
        }

        public static Token ReadQuotedField(string inputLine, int startIndex)
        {
            return QuotedFieldTask.ReadQuotedField(inputLine, startIndex);
        }
    }
}