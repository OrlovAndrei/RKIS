using System.Collections.Generic;
using NUnit.Framework;

namespace TableParser;

[TestFixture]
public class QuotedFieldTaskTests
{
    [TestCase("''", 0, "", 2)]
    [TestCase("'a'", 0, "a", 3)]
    [TestCase("'abc'", 0, "abc", 5)]
    [TestCase("'a\\'bc'", 0, "a'bc", 7)] //Обработка экранированных кавычек
    [TestCase("'a\\\"bc'", 0, "a\"bc", 7)] //Обработка экранированных кавычек
    [TestCase("'a\\'b\\'c'", 0, "a'b'c", 9)] //Обработка нескольких экранированных кавычек
    [TestCase("'ab\\'c'", 0, "ab'c", 6)]
    [TestCase("'ab\\\"c'", 0, "ab\"c", 6)]
    [TestCase("\"hello\"", 0, "hello", 7)] //тест с двойными кавычками
    [TestCase("'hello world'", 0, "hello world", 13)] // тест с пробелом внутри
    [TestCase("' '", 0, " ", 4)] // тест с пробелами
    [TestCase("'", 0, "", 1)] // тест с одиночной кавычкой
    [TestCase("", 0, "", 0)] // тест с пустой строкой
    public void Test(string line, int startIndex, string expectedValue, int expectedLength)
    {
        var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
        Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
    }
}

public class QuotedFieldTask
{
    public static Token ReadQuotedField(string line, int startIndex)
    {
        int endIndex = startIndex + 1; // Пропускаем открывающую кавычку
        bool escaped = false;
        while (endIndex < line.Length)
        {
            if (!escaped && line[endIndex] == '\\')
            {
                escaped = true;
            }
            else if (!escaped && line[endIndex] == '\'')
            {
                break; // Нашли закрывающую кавычку
            }
            else
            {
                escaped = false;
            }
            endIndex++;
        }

        // если не найдена закрывающая кавычка, то endIndex останется последним символом строки
        string value = line.Substring(startIndex + 1, endIndex - startIndex - 1).Replace("\\'", "'").Replace("\\\"", "\""); //удаляем экранирование
        return new Token(value, startIndex, endIndex - startIndex); //с учетом начальной и конечной кавычки
    }
}

public class Token
{
    public string Value { get; }
    public int StartIndex { get; }
    public int Length { get; }

    public Token(string value, int startIndex, int length)
    {
        Value = value;
        StartIndex = startIndex;
        Length = length;
    }

    public override bool Equals(object obj)
    {
        return obj is Token token &&
               Value == token.Value &&
               StartIndex == token.StartIndex &&
               Length == token.Length;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, StartIndex, Length);
    }
}
