using System.Collections.Generic;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class FieldParserTaskTests
    {
        // Метод тестирует функцию ParseLine, сравнивая результат с ожидаемым.
        public static void Test(string input, string[] expectedResult)
        {
            var actualResult = FieldsParserTask.ParseLine(input);
            Assert.AreEqual(expectedResult.Length, actualResult.Count);

            for (int i = 0; i < expectedResult.Length; ++i)
            {
                Assert.AreEqual(expectedResult[i], actualResult[i].Value);
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
        public static void RunTests(string input, string[] expectedOutput)
        {
            Test(input, expectedOutput);
        }
    }

    public class FieldsParserTask
    {
        // Основной метод для парсинга строки на токены.
        public static List<Token> ParseLine(string line)
        {
            var tokens = new List<Token>();
            for (var i = 0; i < line.Length; i++)
            {
                Token token;

                // Проверка, начинается ли поле с кавычки.
                if (line[i] == '\'' || line[i] == '\"')
                {
                    token = ReadQuotedField(line, i);
                }
                else if (line[i] != ' ')
                {
                    // Если поле не в кавычках и не пробел — читается обычное поле.
                    token = ReadField(line, i);
                }
                else
                {
                    continue;
                }

                tokens.Add(token);

                // Пропуск символа, который уже был обработан.
                i += token.Length - 1;
            }

            // Убираются токены с нулевой длиной.
            return CreateFinalList(tokens);
        }

        // Убираются токены с нулевой длиной.
        private static List<Token> CreateFinalList(List<Token> tokens)
        {
            var result = new List<Token>();
            foreach (var token in tokens)
            {
                if (token.Length > 0)
                {
                    result.Add(token);
                }
            }
            return result;
        }

        // Читается обычное поле без кавычек.
        private static Token ReadField(string line, int startIndex)
        {
            var word = "";
            var currentIndex = startIndex;

            // Считываются символы до пробела, кавычки или конца строки.
            while (currentIndex < line.Length && line[currentIndex] != '\'' && line[currentIndex] != '\"' && line[currentIndex] != ' ')
            {
                word += line[currentIndex++];
            }

            return new Token(word, startIndex, word.Length);
        }

        // Читается поле в кавычках, используя вспомогательный метод.
        private static Token ReadQuotedField(string line, int startIndex)
        {
            return QuotedFieldTask.ReadQuotedField(line, startIndex);
        }
    }
}
