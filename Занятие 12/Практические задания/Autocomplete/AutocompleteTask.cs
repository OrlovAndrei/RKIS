using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Autocomplete
{
    internal class AutocompleteTask
    {
        // ... (FindFirstByPrefix remains unchanged) ...

        /// <returns>
        /// Возвращает первые в лексикографическом порядке count (или меньше, если их меньше count)
        /// элементов словаря, начинающихся с prefix.
        /// </returns>
        /// <remarks>Эта функция должна работать за O(log(n) + count)</remarks>
        public static string[] GetTopByPrefix(IReadOnlyList<string> phrases, string prefix, int count)
        {
            int leftIndex = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, 0, phrases.Count - 1) + 1;
            int rightIndex = RightBorderTask.GetRightBorderIndex(phrases, prefix, 0, phrases.Count - 1);

            if (leftIndex >= phrases.Count || leftIndex >= rightIndex) return Array.Empty<string>(); // Ничего не найдено

            return phrases.Skip(leftIndex).Take(Math.Min(count, rightIndex - leftIndex)).ToArray();
        }

        /// <returns>
        /// Возвращает количество фраз, начинающихся с заданного префикса
        /// </returns>
        public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            int leftIndex = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, 0, phrases.Count - 1) + 1;
            int rightIndex = RightBorderTask.GetRightBorderIndex(phrases, prefix, 0, phrases.Count - 1);
            return Math.Max(0, rightIndex - leftIndex);
        }

        [TestFixture]
        public class AutocompleteTests
        {
            [Test]
            public void TopByPrefix_IsEmpty_WhenNoPhrases()
            {
                CollectionAssert.IsEmpty(AutocompleteTask.GetTopByPrefix(new List<string>(), "test", 10));
            }

            [Test]
            public void TopByPrefix_ReturnsAll_WhenCountGreaterThanPhrases()
            {
                var phrases = new List<string> { "apple", "apricot", "avocado" };
                var result = AutocompleteTask.GetTopByPrefix(phrases, "ap", 10);
                CollectionAssert.AreEqual(phrases.Where(x => x.StartsWith("ap", StringComparison.InvariantCultureIgnoreCase)).ToArray(), result);
            }

            [Test]
            public void TopByPrefix_ReturnsTopN_WhenCountLessThanPhrases()
            {
                var phrases = new List<string> { "apple", "apricot", "avocado", "banana" };
                var result = AutocompleteTask.GetTopByPrefix(phrases, "a", 2);
                CollectionAssert.AreEqual(new[] { "apple", "apricot" }, result);
            }

            [Test]
            public void TopByPrefix_HandlesNullPrefix()
            {
                var phrases = new List<string> { "apple", "apricot", "avocado", "banana" };
                var result = AutocompleteTask.GetTopByPrefix(phrases, null, 2);
                Assert.IsEmpty(result); //or some other appropriate assertion depending on your requirements. Consider throwing an exception
            }


            [Test]
            public void CountByPrefix_IsZero_WhenNoPhrases()
            {
                Assert.AreEqual(0, AutocompleteTask.GetCountByPrefix(new List<string>(), "test"));
            }

            [Test]
            public void CountByPrefix_IsTotalCount_WhenEmptyPrefix()
            {
                var phrases = new List<string> { "apple", "apricot", "avocado" };
                Assert.AreEqual(phrases.Count, AutocompleteTask.GetCountByPrefix(phrases, ""));
            }

            [Test]
            public void CountByPrefix_CountsCorrectly_WhenPrefixExists()
            {
                var phrases = new List<string> { "apple", "apricot", "avocado", "banana" };
                Assert.AreEqual(2, AutocompleteTask.GetCountByPrefix(phrases, "ap"));
            }
[Test]
            public void CountByPrefix_CountsCorrectly_WhenPrefixDoesNotExist()
            {
                var phrases = new List<string> { "apple", "apricot", "avocado", "banana" };
                Assert.AreEqual(0, AutocompleteTask.GetCountByPrefix(phrases, "xyz"));
            }

            [Test]
            public void CountByPrefix_HandlesNullPrefix()
            {
                var phrases = new List<string> { "apple", "apricot", "avocado", "banana" };
                Assert.AreEqual(phrases.Count, AutocompleteTask.GetCountByPrefix(phrases, null));
            }

        }
    }
}
