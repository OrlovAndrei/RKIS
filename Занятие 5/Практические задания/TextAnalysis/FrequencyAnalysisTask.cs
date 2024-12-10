using System.Collections.Generic;
using System;
namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, Dictionary<string, int>> FillBigrams(List<List<string>> inputText)
        {
            Dictionary<string, Dictionary<string, int>> bigrDictionary = new Dictionary<string, Dictionary<string, int>>();
            foreach (var sentence in inputText)
            {
                for (int i = 0; i < sentence.Count - 1; i++)
                {
                    if (!bigrDictionary.ContainsKey(sentence[i]))
                        bigrDictionary.Add(sentence[i], new Dictionary<string, int>());
                    if (!bigrDictionary[sentence[i]].ContainsKey(sentence[i + 1]))
                        bigrDictionary[sentence[i]].Add(sentence[i + 1], 1);
                    else 
                        bigrDictionary[sentence[i]][sentence[i + 1]] += 1;
                }
            }
            return bigrDictionary;
        }
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> inputText)
        {
            Dictionary<string, Dictionary<string, int>> bigrDictionary = FillBigrams(inputText);
            Dictionary<string, string> mostFreqBigr = new Dictionary<string, string>();
            foreach (var primaryWord in bigrDictionary)
            {
                var maxCount = 0;
                string mostFreqSecondaryWord = null;
                foreach (var secondaryWord in primaryWord.Value)
                {
                    if (secondaryWord.Value == maxCount)
                        if (string.CompareOrdinal(mostFreqSecondaryWord, secondaryWord.Key) > 0)
                            mostFreqSecondaryWord = secondaryWord.Key;
                    if (secondaryWord.Value > maxCount)
                    {
                        mostFreqSecondaryWord = secondaryWord.Key;
                        maxCount = secondaryWord.Value;
                    }
                }
                mostFreqBigr.Add(primaryWord.Key, mostFreqSecondaryWord);
            }
            return mostFreqBigr;
        }
        public static Dictionary<string, Dictionary<string, int>> FillTrigrams(List<List<string>> inputText)
        {
            Dictionary<string, Dictionary<string, int>> trigrDictionary = new Dictionary<string, Dictionary<string, int>>();
            foreach (var sentence in inputText)
            {
                for (int index = 0; index < sentence.Count - 2; index++)
                {
                    if (!trigrDictionary.ContainsKey(sentence[index] + " " + sentence[index + 1]))
                        trigrDictionary.Add(sentence[index] + " " + sentence[index + 1], new Dictionary<string, int>());
                    if (!trigrDictionary[sentence[index] + " " + sentence[index + 1]].ContainsKey(sentence[index + 2]))
                        trigrDictionary[sentence[index] + " " + sentence[index + 1]].Add(sentence[index + 2], 1);
                    else 
                        trigrDictionary[sentence[index] + " " + sentence[index + 1]][sentence[index + 2]] += 1;
                }
            }
            return trigrDictionary;
        }
        public static Dictionary<string, string> GetMostFrequentNextWordsTrigram(List<List<string>> inputText)
        {
            Dictionary<string, Dictionary<string, int>> trigrDictionary = FillTrigrams(inputText);
            Dictionary<string, string> mostFreqTrigrams = new Dictionary<string, string>();
            foreach (var wordPair in trigrDictionary)
            {
                var maxCount = 0;
                string mostFreqTertiaryWord = null;
                foreach (var tertiaryWord in wordPair.Value)
                {
                    if (tertiaryWord.Value == maxCount)
                        if (string.CompareOrdinal(mostFreqTertiaryWord, tertiaryWord.Key) > 0)
                            mostFreqTertiaryWord = tertiaryWord.Key;
                    if (tertiaryWord.Value > maxCount)
                    {
                        mostFreqTertiaryWord = tertiaryWord.Key;
                        maxCount = tertiaryWord.Value;
                    }
                }
                mostFreqTrigrams.Add(wordPair.Key, mostFreqTertiaryWord);
            }
            return mostFreqTrigrams;
        }
    }
}