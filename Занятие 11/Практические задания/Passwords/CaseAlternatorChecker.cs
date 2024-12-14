using System;
using System.Collections.Generic;
using System.Linq;

namespace Passwords
{
    public class CaseAlternatorTask
    {
        public static List<string> AlternateCharCases(string lowercaseWord)
        {
            var result = new List<string>();
            AlternateCharCases(lowercaseWord.ToCharArray(), 0, result);
            return result;
        }

        static void AlternateCharCases(char[] word, int startIndex, List<string> result)
        {
            if (startIndex >= word.Length)
            {
                result.Add(new string(word));
                return;
            }

            char currentChar = word[startIndex];

            if (!char.IsLetter(currentChar))
            {
                AlternateCharCases(word, startIndex + 1, result);
                return;
            }

            word[startIndex] = char.ToUpper(currentChar);
            AlternateCharCases(word, startIndex + 1, result);

            word[startIndex] = char.ToLower(currentChar);
            AlternateCharCases(word, startIndex + 1, result);
        }
    }

    public class CaseAlternatorChecker
    {
        static readonly Random random = new Random();

        public static void Main()
        {
            try
            {
                Check("cat", 8);
                Check("", 1);
                Check("a", 2);
                Check("ab", 4);
                Check("ab!", 4);
                Check("!ab", 4);
                Check("!a!b!", 4);
                Check("a!b", 4);
                Check("3141592", 1);
                Check("42ndfloor");
                Check("при4вет", 64);
                Check(GenerateWord(3));
                Check(GenerateWord(4));
                Check(GenerateWord(5));
                Check(GenerateWord(10));
                Check(GenerateWord(15));
                Check("straße", 32);
                Check(GenerateStrangeWord(5));
                Check(GenerateStrangeWord(5));
                Check(GenerateStrangeWord(5));
                Check(GenerateStrangeWord(5));
                Check("ⅲ ⅳ ⅷ", 1);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }

        private static string GenerateWord(int len)
        {
            var abc = "abcdefghijklmnopqrstuvwxyz0123456789-!@#$%^&*() ";
            var letters = Enumerable.Repeat(0, len).Select(i => abc[random.Next(abc.Length)]);
            return new string(letters.ToArray());
        }

        private static string GenerateStrangeWord(int len)
        {
            var abc = "אבגדהוזחטיךכלםמןנסעףפץצקרשת";
            var letters = Enumerable.Repeat(0, len).Select(i => abc[random.Next(abc.Length)]);
            return new string(letters.ToArray());
        }

        private static void Check(string password, int expectedCount = -1)
        {
            try
            {
                if (expectedCount == -1)
                    expectedCount = 1 << password.Count(c => char.IsLetter(c));

                var actual = CaseAlternatorTask.AlternateCharCases(password);

                var duplicateGroup = actual.GroupBy(a => a).FirstOrDefault(g => g.Count() > 1);
                if (duplicateGroup != null)
                    throw new Exception($"Повторение слова '{duplicateGroup.Key}' в результате.");

                for (int i = 0; i < actual.Count - 1; i++)
                {
                    if (string.CompareOrdinal(actual[i], actual[i + 1]) <= 0)
                        throw new Exception($"Слово '{actual[i]}' должно идти после '{actual[i + 1]}'.");
                }

                if (actual.Count != expectedCount)
                    throw new Exception($"Ожидалось {expectedCount} комбинаций, найдено {actual.Count}.");

                Console.WriteLine