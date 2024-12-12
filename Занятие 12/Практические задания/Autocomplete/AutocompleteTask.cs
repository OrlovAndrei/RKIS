using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Autocomplete;

internal class AutocompleteTask
{
    /// <returns>
    /// Возвращает первую фразу словаря, начинающуюся с prefix.
    /// </returns>
    /// <remarks>
    /// Эта функция уже реализована, она заработает, 
    /// как только вы выполните задачу в файле LeftBorderTask
    /// </remarks>
    public static string FindFirstByPrefix(IReadOnlyList<string> phrases, string prefix)
    {
        var index = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
        if (index < phrases.Count && phrases[index].StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
            return phrases[index];
            
        return null;
    }

    /// <returns>
    /// Возвращает первые в лексикографическом порядке count (или меньше, если их меньше count) 
    /// элементов словаря, начинающихся с prefix.
    /// </returns>
    /// <remarks>Эта функция должна работать за O(log(n) + count)</remarks>
    public static string[] GetTopByPrefix(IReadOnlyList<string> phrases, string prefix, int count)
    {
        // Используем бинарный поиск для нахождения левой границы
        int leftIndex = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, 0, phrases.Count);
        
        if (leftIndex == -1)
            return new string[0]; // Нет подходящих фраз
        
        // Создаем список для хранения найденных фраз
        var result = new List<string>();
        
        // Проходим по списку и добавляем фразы, начинающиеся с префикса
        for (int i = leftIndex + 1; i < phrases.Count && result.Count < count; i++)
        {
            if (phrases[i].StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
            {
                result.Add(phrases[i]);
            }
            else
            {
                break; // Выход, если фраза не начинается с префикса
            }
        }
        
        return result.ToArray();
    }

    /// <returns>
    /// Возвращает количество фраз, начинающихся с заданного префикса
    /// </returns>
    public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
    {
        // Используем бинарный поиск для нахождения левой границы
        int leftIndex = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, 0, phrases.Count);
        
        if (leftIndex == -1)
            return 0; // Нет подходящих фраз
        
        // Используем бинарный поиск для нахождения правой границы
        int rightIndex = RightBorderTask.GetRightBorderIndex(phrases, prefix, 0, phrases.Count);
        
        return rightIndex - leftIndex - 1;
    }
}

[TestFixture]
public class AutocompleteTests
{
    private IReadOnlyList<string> phrases;

    [SetUp]
    public void SetUp()
    {
        // Инициализация списка фраз для тестирования
        phrases = new List<string>
        {
            "apple",
            "banana",
            "cherry",
            "date",
            "grape",
            "apricot",
            "avocado",
            "blueberry"
        };
    }

    [Test]
    public void TopByPrefix_ReturnsCorrectWords_WhenPrefixExists()
    {
        var prefix = "ap";
        var count = 3;

        var result = AutocompleteTask.GetTopByPrefix(phrases, prefix, count);

        Assert.AreEqual(3, result.Length);
        Assert.AreEqual("apple", result[0]);
        Assert.AreEqual("apricot", result[1]);
        Assert.AreEqual("avocado", result[2]);
    }

    [Test]
    public void TopByPrefix_ReturnsEmpty_WhenPrefixDoesNotExist()
    {
        var prefix = "xyz";
        var count = 3;

        var result = AutocompleteTask.GetTopByPrefix(phrases, prefix, count);

        Assert.AreEqual(0, result.Length);
    }

    [Test]
    public void CountByPrefix_ReturnsCorrectCount_WhenPrefixExists()
    {
        var prefix = "ap";

        var result = AutocompleteTask.GetCountByPrefix(phrases, prefix);

        Assert.AreEqual(3, result); // apple, apricot, avocado
    }

    [Test]
    public void CountByPrefix_ReturnsZero_WhenPrefixDoesNotExist()
    {
        var prefix = "xyz";

        var result = AutocompleteTask.GetCountByPrefix(phrases, prefix);

        Assert.AreEqual(0, result);
    }

    [Test]
    public void CountByPrefix_ReturnsTotalCount_WhenEmptyPrefix()
    {
        var prefix = "";
        var expectedCount = phrases.Count;

        var result = AutocompleteTask.GetCountByPrefix(phrases, prefix);

        Assert.AreEqual(expectedCount, result); // Все слова должны быть учтены
    }
}