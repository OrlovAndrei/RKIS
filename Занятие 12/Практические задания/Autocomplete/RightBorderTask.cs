using System;
using System.Collections.Generic;
using System.Linq;

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
            var index = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, 0, phrases.Count - 1) + 1;
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
            int leftIndex = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, 0, phrases.Count - 1) + 1;
            int rightIndex = RightBorderTask.GetRightBorderIndex(phrases, prefix, 0, phrases.Count - 1);

            if (leftIndex >= rightIndex) return new string[0]; // Ничего не найдено

            int countToReturn = Math.Min(count, rightIndex - leftIndex); //не больше чем count
            return phrases.Skip(leftIndex).Take(countToReturn).ToArray();

        }

        /// <returns>
        /// Возвращает количество фраз, начинающихся с заданного префикса
        /// </returns>
        public static int GetCountByPrefix(IReadOnlyList<string> phrases, string prefix)
        {
            int leftIndex = LeftBorderTask.GetLeftBorderIndex(phrases, prefix, 0, phrases.Count - 1) + 1;
            int rightIndex = RightBorderTask.GetRightBorderIndex(phrases, prefix, 0, phrases.Count - 1);
            return Math.Max(0, rightIndex - leftIndex); // Возвращаем 0 если ничего не найдено.
        }


        [TestFixture]
        public class AutocompleteTests
        {
            [Test]
            public void TopByPrefix_IsEmpty_WhenNoPhrases()
            {
                CollectionAssert.IsEmpty(GetTopByPrefix(new List<string>(), "test", 10));
            }

            [Test]
            public void TopByPrefix_ReturnsAll_WhenCountGreaterThanPhrases()
            {
                var phrases = new List<string> { "apple", "apricot", "avocado" };
                var result = GetTopByPrefix(phrases, "ap", 10);
                CollectionAssert.AreEqual(phrases.Where(x => x.StartsWith("ap", StringComparison.InvariantCultureIgnoreCase)).ToArray(), result);
            }

            [Test]
            public void TopByPrefix_ReturnsTopN_WhenCountLessThanPhrases()
            {
                var phrases = new List<string> { "apple", "apricot", "avocado", "banana" };
                var result = GetTopByPrefix(phrases, "a", 2);
                CollectionAssert.AreEqual(new[] { "apple", "apricot" }, result);
            }

            [Test]
            public void CountByPrefix_IsZero_WhenNoPhrases()
            {
                Assert.AreEqual(0, GetCountByPrefix(new List<string>(), "test"));
            }

            [Test]
            public void CountByPrefix_IsTotalCount_WhenEmptyPrefix()
            {
                var phrases = new List<string> { "apple", "apricot", "avocado" };
                Assert.AreEqual(phrases.Count, GetCountByPrefix(phrases, ""));
            }

            [Test]
            public void CountByPrefix_CountsCorrectly_WhenPrefixExists()
            {
                var phrases = new List<string> { "apple", "apricot", "avocado", "banana" };
                Assert.AreEqual(2, GetCountByPrefix(phrases, "ap"));
            }
[Test]
            public void CountByPrefix_CountsCorrectly_WhenPrefixDoesNotExist()
            {
                var phrases = new List<string> { "apple", "apricot", "avocado", "banana" };
                Assert.AreEqual(0, GetCountByPrefix(phrases, "xyz"));
            }

        }
    }
}
