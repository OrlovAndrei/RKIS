using System.Collections.Generic;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class ParserTests
    {
        // Метод тестирует функцию ParseInput, сравнивая результат с ожидаемым.
        public static void ValidateParsing(string source, string[] expectedOutput)
        {
            var actualOutput = FieldsParser.ParseInput(source);
            Assert.AreEqual(expectedOutput.Length, actualOutput.Count);

            for (int idx = 0; idx < expectedOutput.Length; ++idx)
            {
                Assert.AreEqual(expectedOutput[idx], actualOutput[idx].Value);
            }
        }

        // Набор тестовых случаев для проверки корректности парсера.
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
        public static void ExecuteTests(string source, string[] expectedOutput)
        {
            ValidateParsing(source, expectedOutput);
        }
    }

    public class FieldsParser
    {
        // Основной метод для парсинга строки на токены.
        public static List<Token> ParseInput(string inputLine)
        {
            var tokenList = new List<Token>();
            for (var index = 0; index < inputLine.Length; index++)
            {
                Token token;

                // Проверка, начинается ли поле с кавычки.
                if (inputLine[index] == '\'' || inputLine[index] == '\"')
                {
                    token = ExtractQuotedField(inputLine, index);
                }
                else if (inputLine[index] != ' ')
                {
                    // Если поле не в кавычках и не пробел — читается обычное поле.
                    token = ExtractField(inputLine, index);
                }
                else
                {
                    continue;
                }

                tokenList.Add(token);

                // Пропуск символа, который уже был обработан.
                index += token.Length - 1;
            }

            // Убираются токены с нулевой длиной.
            return FilterEmptyTokens(tokenList);
        }

        // Убираются токены с нулевой длиной.
        private static List<Token> FilterEmptyTokens(List<Token> tokens)
        {
            var nonEmptyTokens = new List<Token>();
            foreach (var token in tokens)
            {
                if (token.Length > 0)
                {
                    nonEmptyTokens.Add(token);
                }
            }
            return nonEmptyTokens;
        }

        // Читается обычное поле без кавычек.
        private static Token ExtractField(string line, int startIndex)
        {
            var fieldValue = "";
            var currentIndex = startIndex;

            // Считываются символы до пробела, кавычки или конца строки.
            while (currentIndex < line.Length && line[currentIndex] != '\'' && line[currentIndex] != '\"' && line[currentIndex] != ' ')
            {
                fieldValue += line[currentIndex++];
            }

            return new Token(fieldValue, startIndex, fieldValue.Length);
        }

        // Читается поле в кавычках, используя вспомогательный метод.
        private static Token ExtractQuotedField(string line, int startIndex)
        {
            return QuotedFieldTask.ReadQuotedField(line, startIndex);
        }
    }
}
