using System.Collections.Generic;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class FieldParserTaskTests
    {
        public static void Test(string inputLine, string[] expectedValues)
        {
            var actualTokens = FieldsParserTask.ParseLine(inputLine);
            Assert.AreEqual(expectedValues.Length, actualTokens.Count);

            for (int index = 0; index < expectedValues.Length; ++index)
            {
                Assert.AreEqual(expectedValues[index], actualTokens[index].Value);
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
        public static void RunTests(string inputLine, string[] expectedValues)
        {
            // Тело метода изменять не нужно
            Test(inputLine, expectedValues);
        }
    }

    public class FieldsParserTask
    {
        // При решении этой задачи постарайтесь избежать создания методов, длиннее 10 строк.
        // Подумайте, как можно использовать ReadQuotedField и Token в этой задаче.
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