using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Autocomplete
{
    internal class AutocompleteTask
    {
        public static string FindFirstByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var index = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
            if (index < phrases.Count && phrases[index].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return phrases[index];

            return null;
        }

        public static string[] GetTopByPrefix(IReadOnlyList<string> phrases, string prefix, int count)
        {
            var left = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
            var countByPrefix = GetCountByPrefix(phrases, prefix);

            if (countByPrefix <= 0)
                return new string[0];

            if (count > countByPrefix)
                count = countByPrefix;

            var result = new string[count];
            for (int i = 0; i < count; i++)
                result[i] = phrases[left + i];
            return result;
        }

        public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            return RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, phrases.Count) -
                LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) - 1;
        }
    }

    [TestFixture]
    public class AutocompleteTests
    {
        [Test]
        public void TopByPrefix_DictEmpty_ZeroCount()
        {
            var phrases = new List<string>();
            var result = AutocompleteTask.GetTopByPrefix(phrases, "uiuggkko", 0);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void TopByPrefix_DictEmpty_NotZeroCount()
        {
            var phrases = new List<string>();
            var result = AutocompleteTask.GetTopByPrefix(phrases, "q", 5);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void TopByPrefix_PhrasesWithoutPrefix_ZeroCount()
        {
            var phrases = new List<string>() { "bad", "shadow", "stand" };
            var result = AutocompleteTask.GetTopByPrefix(phrases, "l", 0);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void TopByPrefix_PhrasesWithoutPrefix_NotZeroCount()
        {
            var phrases = new List<string>() { "love", "light", "leg" };
            var result = AutocompleteTask.GetTopByPrefix(phrases, "a", phrases.Count);
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void TopByPrefix_IsEmpty_PhrasesWithPrefix_ZeroCount()
        {
            var phrases = new List<string>() { "bad", "shadow", "stand" };
            var result = AutocompleteTask.GetTopByPrefix(phrases, "a", 0);
            CollectionAssert.IsEmpty(result);
        }


        [Test]
        public void CountByPrefix_ZeroCount()
        {
            var phrases = new List<string>() { "asfh", "bfdbfl", "jsbdfdfbd", "dfgdfgdfgdfgfd" };
            var result = AutocompleteTask.GetCountByPrefix(phrases, "poiioasfunp");
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CountByPrefix_EmptyFhrases()
        {
            var phrases = new List<string>();
            var result = AutocompleteTask.GetCountByPrefix(phrases, "le");
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CountByPrefix_EmptyPrefix()
        {
            var phrases = new List<string>() { "i", "love", "programming" };
            var totalCount = phrases.Count;
            var result = AutocompleteTask.GetCountByPrefix(phrases, "");
            Assert.AreEqual(totalCount, result);
        }
    }
}