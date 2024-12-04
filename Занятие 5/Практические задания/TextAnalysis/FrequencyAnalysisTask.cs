using System.Collections.Generic;
using System;
namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, Dictionary<string, int>> FillBigrams(List<List<string>> inputText)
        {
            Dictionary<string, Dictionary<string, int>> bigramDictionary = new Dictionary<string, Dictionary<string, int>>();
            foreach (var sentence in inputText)
            {
                for (int index = 0; index < sentence.Count - 1; index++)
                {
                    if (!bigramDictionary.ContainsKey(sentence[index]))
                        bigramDictionary.Add(sentence[index], new Dictionary<string, int>());
                    if (!bigramDictionary[sentence[index]].ContainsKey(sentence[index + 1]))
                        bigramDictionary[sentence[index]].Add(sentence[index + 1], 1);
                    else bigramDictionary[sentence[index]][sentence[index + 1]] += 1;
                }
            }
            return bigramDictionary;
        }
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> inputText)
        {
            Dictionary<string, Dictionary<string, int>> bigramDictionary = FillBigrams(inputText);
            Dictionary<string, string> mostFrequentBigrams = new Dictionary<string, string>();
            foreach (var primaryWord in bigramDictionary)
            {
                var maxCount = 0;
                string mostFrequentSecondaryWord = null;
                foreach (var secondaryWord in primaryWord.Value)
                {
                    if (secondaryWord.Value == maxCount)
                        if (string.CompareOrdinal(mostFrequentSecondaryWord, secondaryWord.Key) > 0)
                            mostFrequentSecondaryWord = secondaryWord.Key;
                    if (secondaryWord.Value > maxCount)
                    {
                        mostFrequentSecondaryWord = secondaryWord.Key;
                        maxCount = secondaryWord.Value;
                    }
                }
                mostFrequentBigrams.Add(primaryWord.Key, mostFrequentSecondaryWord);
            }
            return mostFrequentBigrams;
        }
        public static Dictionary<string, Dictionary<string, int>> FillTrigrams(List<List<string>> inputText)
        {
            Dictionary<string, Dictionary<string, int>> trigramDictionary = new Dictionary<string, Dictionary<string, int>>();
            foreach (var sentence in inputText)
            {
                for (int index = 0; index < sentence.Count - 2; index++)
                {
                    if (!trigramDictionary.ContainsKey(sentence[index] + " " + sentence[index + 1]))
                        trigramDictionary.Add(sentence[index] + " " + sentence[index + 1], new Dictionary<string, int>());
                    if (!trigramDictionary[sentence[index] + " " + sentence[index + 1]].ContainsKey(sentence[index + 2]))
                        trigramDictionary[sentence[index] + " " + sentence[index + 1]].Add(sentence[index + 2], 1);
                    else trigramDictionary[sentence[index] + " " + sentence[index + 1]][sentence[index + 2]] += 1;
                }
            }
            return trigramDictionary;
        }
        public static Dictionary<string, string> GetMostFrequentNextWordsTrigram(List<List<string>> inputText)
        {
            Dictionary<string, Dictionary<string, int>> trigramDictionary = FillTrigrams(inputText);
            Dictionary<string, string> mostFrequentTrigrams = new Dictionary<string, string>();
            foreach (var wordPair in trigramDictionary)
            {
                var maxCount = 0;
                string mostFrequentTertiaryWord = null;
                foreach (var tertiaryWord in wordPair.Value)
                {
                    if (tertiaryWord.Value == maxCount)
                        if (string.CompareOrdinal(mostFrequentTertiaryWord, tertiaryWord.Key) > 0)
                            mostFrequentTertiaryWord = tertiaryWord.Key;
                    if (tertiaryWord.Value > maxCount)
                    {
                        mostFrequentTertiaryWord = tertiaryWord.Key;
                        maxCount = tertiaryWord.Value;
                    }
                }
                mostFrequentTrigrams.Add(wordPair.Key, mostFrequentTertiaryWord);
            }
            return mostFrequentTrigrams;
        }
    }
}