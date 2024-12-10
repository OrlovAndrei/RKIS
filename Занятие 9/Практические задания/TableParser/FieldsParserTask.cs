using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TableParser
{
    [TestFixture]
    public class FieldParserTaskTests
    {
<<<<<<< HEAD
        public static void Test(string inputLine, string[] expectedValues)
        {
            var actualTokens = FieldsParserTask.ParseLine(inputLine);
            Assert.AreEqual(expectedValues.Length, actualTokens.Count);

            for (int index = 0; index < expectedValues.Length; ++index)
            {
                Assert.AreEqual(expectedValues[index], actualTokens[index].Value);
=======
        public static void Test(string input, string[] expectedResult)
        {
            var actualResult = FieldsParserTask.ParseLine(input);
            Assert.AreEqual(expectedResult.Length, actualResult.Count);

            for (int i = 0; i < expectedResult.Length; ++i)
            {
                Assert.AreEqual(expectedResult[i], actualResult[i].Value);
>>>>>>> 0c3d4346034ed7e416dbaabec924303a55e29a61
            }
        }

        [TestCase("text", new[] { "text" })]
        [TestCase("hello world", new[] { "hello", "world" })]
<<<<<<< HEAD
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
=======
        [TestCase("", new string[0])] //Нет полей
        [TestCase("\'\"\'", new[] { "\"" })] //Двойные кавычки внутри одинарных
        [TestCase("\"\"", new[] { "" })] //Пустое поле
        [TestCase("ab", new[] { "ab" })] //Одно поле
        [TestCase("a b", new[] { "a", "b" })] //Больше одного поля, Разделитель длиной в один пробел
        [TestCase("a  b", new[] { "a", "b" })] //Разделитель длиной >1 пробела
        [TestCase(" a b ", new[] { "a", "b" })] //Пробелы в начале или в конце строки
        [TestCase("a 'b'", new[] { "a", "b" })] //Поле в кавычках после простого поля
        [TestCase("'b' a", new[] { "b", "a" })] //Простое поле после поля в кавычках
        [TestCase("b \"a", new[] { "b", "a" })] //Нет закрывающей кавычки
        [TestCase("\'a ", new[] { "a " })] //Пробел внутри кавычек, Пробел в конце поля с незакрытой кавычкой
        [TestCase("\"\'b\'\" c", new[] { "'b'", "c" })] //Одинарные кавычки внутри двойных
        [TestCase("\'\"a\"\' b", new[] { "\"a\"", "b" })] //Разделитель без пробелов
        [TestCase(@"'a''b'", new[] { "a", "b" })] //Экранированный обратный слэш перед закрывающей кавычкой
        [TestCase(@"'a\\'", new[] { @"a\" })] //Экранированный обратный слэш внутри кавычек
        [TestCase(@"'\'a'", new[] { @"'a" })] //Экранированные одинарные кавычки внутри одинарных
        [TestCase(@"""\""a""", new[] { @"""a" })] //Экранированный двойные кавычки внутри двойных
        public static void RunTests(string input, string[] expectedOutput)
        {
            // Тело метода изменять не нужно
            Test(input, expectedOutput);
        }
    }

    public class FieldsParserTask
    {
        // При решении этой задаче постарайтесь избежать создания методов, длиннее 10 строк.
        // Подумайте как можно использовать ReadQuotedField и Token в этой задаче.
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
>>>>>>> 0c3d4346034ed7e416dbaabec924303a55e29a61
