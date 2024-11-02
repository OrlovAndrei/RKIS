using System.Collections.Generic;
using System;

namespace TextAnalysis;

static class FrequencyAnalysisTask
{
    public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
    {
        var bigramDict = new Dictionary<string, Dictionary<string, int>>();
        var trigramDict = new Dictionary<string, Dictionary<string, int>>();

        foreach (var sentence in text)
        {
            for (int i = 0; i < sentence.Count; i++)
            {

                if (i < sentence.Count - 1)
                {
                    var bigram = sentence[i];
                    var nextWord = sentence[i + 1];

                    if (!bigramDict.ContainsKey(bigram))
                    {
                        bigramDict[bigram] = new Dictionary<string, int>();
                    }

                    if (!bigramDict[bigram].ContainsKey(nextWord))
                    {
                        bigramDict[bigram][nextWord] = 0;
                    }

                    bigramDict[bigram][nextWord]++;
                }


                if (i < sentence.Count - 2)
                {
                    var trigram = sentence[i] + " " + sentence[i + 1];
                    var nextWord = sentence[i + 2];

                    if (!trigramDict.ContainsKey(trigram))
                    {
                        trigramDict[trigram] = new Dictionary<string, int>();
                    }

                    if (!trigramDict[trigram].ContainsKey(nextWord))
                    {
                        trigramDict[trigram][nextWord] = 0;
                    }

                    trigramDict[trigram][nextWord]++;
                }
            }
        }

        var result = new Dictionary<string, string>();

        foreach (var bigram in bigramDict)
        {
            var mostFrequentNextWord = bigram.Value
                .OrderByDescending(kvp => kvp.Value)
                .ThenBy(kvp => kvp.Key)
                .First();

            result[bigram.Key] = mostFrequentNextWord.Key;
        }
        foreach (var trigram in trigramDict)
        {
            var mostFrequentNextWord = trigram.Value
                .OrderByDescending(kvp => kvp.Value)
                .ThenBy(kvp => kvp.Key)
                .First();

            result[trigram.Key] = mostFrequentNextWord.Key;
        }
        return result;
    }
}