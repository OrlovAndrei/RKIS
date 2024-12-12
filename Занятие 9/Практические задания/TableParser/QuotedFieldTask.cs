using NUnit.Framework;

namespace TableParser;

[TestFixture]
public class QuotedFieldTaskTests
{
    [TestCase("''", 0, "", 2)] // Пустое поле
    [TestCase("'a'", 0, "a", 3)] // Поле с одним символом
    [TestCase("'hello'", 0, "hello", 7)] // Поле с несколькими символами
    [TestCase("'with spaces'", 0, "with spaces", 13)] // Поле с пробелами
    [TestCase("'unterminated", 0, "unterminated", 13)] // Без закрывающей кавычки
    [TestCase("'nested 'quote''", 0, "nested 'quote", 15)] // Вложенные кавычки
    public void Test(string line, int startIndex, string expectedValue, int expectedLength)
    {
        var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
        Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
    }

    [Test]
    public void HandlesEmptyInput()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            QuotedFieldTask.ReadQuotedField("", 0));
    }
}

class QuotedFieldTask
{
    public static Token ReadQuotedField(string line, int startIndex)
    {
        // Начинаем с символа после открывающей кавычки
        int currentIndex = startIndex + 1;
        while (currentIndex < line.Length && line[currentIndex] != '\'')
        {
            currentIndex++;
        }

        // Извлекаем содержимое между кавычками
        string value = line.Substring(startIndex + 1, currentIndex - startIndex - 1);

        // Длина токена включает обе кавычки
        int length = (currentIndex < line.Length ? currentIndex + 1 : line.Length) - startIndex;

        return new Token(value, startIndex, length);
    }
}