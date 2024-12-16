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
            if (index < phrases.Count &&
                phrases[index].StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                return phrases[index];
            else
                return null;
        }


        public static string[] GetTopByPrefix(IReadOnlyList<string> phrases, string prefix, int count)
        {
            var first = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
            var last = RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, phrases.Count) - 1;
            count = Math.Min(count, Math.Max(0, last - first + 1));
            var ret = new string[count];
            for (var i = 0; i < count; ++i) ret[i] = phrases[first + i];
            return ret;
        }

        public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            var first = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, -1, phrases.Count) + 1;
            var last = RightBorderTask.GetRightBorderIndex(phrases, prefix, -1, phrases.Count) - 1;
            return Math.Max(0, last - first + 1);
        }
    }

    [TestFixture]
    public class AutocompleteTests
    {
        [Test]
        public void TopByPrefix_IsEmpty_WhenNoPhrases()
        {
            var phrases = new string[] { "a", "ab", "abc", "def" };
            var prefix = "zzz";
            int count = 10;
            var actualTopWords = AutocompleteTask.GetTopByPrefix(phrases, prefix, count);
            CollectionAssert.IsEmpty(actualTopWords);
        }

        [Test]
        public void TopByPrefix_SingleResult()
        {
            var phrases = new string[] { "a", "ab", "abc", "def" };
            var prefix = "abc";
            int count = 10;
            var expectedResult = new string[] { "abc" };
            var actualTopWords = AutocompleteTask.GetTopByPrefix(phrases, prefix, count);
            CollectionAssert.AreEqual(expectedResult, actualTopWords);
        }

        [Test]
        public void TopByPrefix_MultipleResult_Uncutted()
        {
            var phrases = new string[] { "a", "ab", "abc", "def" };
            var prefix = "ab";
            int count = 10;
            var expectedResult = new string[] { "ab", "abc" };
            var actualTopWords = AutocompleteTask.GetTopByPrefix(phrases, prefix, count);
            CollectionAssert.Equals(expectedResult, actualTopWords);
        }

        [Test]
        public void TopByPrefix_MultipleResult_CuttedByCount()
        {
            var phrases = new string[] { "a", "ab", "abc", "def" };
            var prefix = "a";
            int count = 2;
            var expectedResult = new string[] { "a", "ab" };
            var actualTopWords = AutocompleteTask.GetTopByPrefix(phrases, prefix, count);
            CollectionAssert.Equals(expectedResult, actualTopWords);
        }

        [Test]
        public void CountByPrefix_IsTotalCount_WhenEmptyPrefix()
        {
            var phrases = new string[] { "a", "ab", "abc", "def" };
            var prefix = "";
            var expectedCount = phrases.Count();
            var actualCount = AutocompleteTask.GetCountByPrefix(phrases, prefix);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CountByPrefix_IsTotalCount_WhenEmptyResult()
        {
            var phrases = new string[] { "a", "ab", "abc", "def" };
            var prefix = "zzz";
            var expectedCount = 0;
            var actualCount = AutocompleteTask.GetCountByPrefix(phrases, prefix);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CountByPrefix_IsTotalCount_WhenSingleResult()
        {
            var phrases = new string[] { "a", "ab", "abc", "def" };
            var prefix = "def";
            var expectedCount = 1;
            var actualCount = AutocompleteTask.GetCountByPrefix(phrases, prefix);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CountByPrefix_IsTotalCount_WhenMultipleResult()
        {
            var phrases = new string[] { "a", "ab", "abc", "def" };
            var prefix = "a";
            var expectedCount = 3;
            var actualCount = AutocompleteTask.GetCountByPrefix(phrases, prefix);
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}