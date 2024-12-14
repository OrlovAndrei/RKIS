using System;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, Dictionary<string, int>> FillBigrams(List<List<string>> text)
        {
            var bigramCounts = new Dictionary<string, Dictionary<string, int>>();

            foreach (var sentence in text)
            {
                UpdateBigramCounts(sentence, bigramCounts);
            }

            return bigramCounts;
        }

        private static void UpdateBigramCounts(List<string> sentence, Dictionary<string, Dictionary<string, int>> bigramCounts)
        {
            for (int i = 0; i < sentence.Count - 1; i++)
            {
                var firstWord = sentence[i];
                var secondWord = sentence[i + 1];

                if (!bigramCounts.ContainsKey(firstWord))
                {
                    bigramCounts[firstWord] = new Dictionary<string, int>();
                }

                if (!bigramCounts[firstWord].ContainsKey(secondWord))
                {
                    bigramCounts[firstWord][secondWord] = 1;
                }
                else
                {
                    bigramCounts[firstWord][secondWord]++;
                }
            }
        }

        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var bigrams = FillBigrams(text);
            var mostFrequentBigrams = new Dictionary<string, string>();

            foreach (var firstWordPair in bigrams)
            {
                mostFrequentBigrams[firstWordPair.Key] = GetMostFrequentWord(firstWordPair.Value);
            }

            return mostFrequentBigrams;
        }

        private static string GetMostFrequentWord(Dictionary<string, int> wordCounts)
        {
            string mostFrequentWord = null;
            int maxFrequency = 0;

            foreach (var pair in wordCounts)
            {
                if (pair.Value > maxFrequency ||
                    (pair.Value == maxFrequency && string.CompareOrdinal(mostFrequentWord, pair.Key) > 0))
                {
                    mostFrequentWord = pair.Key;
                    maxFrequency = pair.Value;
                }
            }

            return mostFrequentWord;
        }

        public static Dictionary<string, Dictionary<string, int>> FillTrigrams(List<List<string>> text)
        {
            var trigramCounts = new Dictionary<string, Dictionary<string, int>>();

            foreach (var sentence in text)
            {
                UpdateTrigramCounts(sentence, trigramCounts);
            }

            return trigramCounts;
        }

        private static void UpdateTrigramCounts(List<string> sentence, Dictionary<string, Dictionary<string, int>> trigramCounts)
        {
            for (int i = 0; i < sentence.Count - 2; i++)
            {
                var bigramKey = sentence[i] + " " + sentence[i + 1];
                var thirdWord = sentence[i + 2];

                if (!trigramCounts.ContainsKey(bigramKey))
                {
                    trigramCounts[bigramKey] = new Dictionary<string, int>();
                }

                if (!trigramCounts[bigramKey].ContainsKey(thirdWord))
                {
                    trigramCounts[bigramKey][thirdWord] = 1;
                }
                else
                {
                    trigramCounts[bigramKey][thirdWord]++;
                }
            }
        }

        public static Dictionary<string, string> GetMostFrequentNextWordsTrigram(List<List<string>> text)
        {
            var trigrams = FillTrigrams(text);
            var mostFrequentTrigrams = new Dictionary<string, string>();

            foreach (var wordPair in trigrams)
            {
                mostFrequentTrigrams[wordPair.Key] = GetMostFrequentWord(wordPair.Value);
            }

            return mostFrequentTrigrams;
        }
    }
}
