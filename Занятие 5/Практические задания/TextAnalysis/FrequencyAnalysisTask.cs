﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var bigramCounts = new Dictionary<string, Dictionary<string, int>>();
            var trigramCounts = new Dictionary<string, Dictionary<string, int>>();

            foreach (var sentence in text)
            {
                for (int i = 0; i < sentence.Count; i++)
                {
                    if (i < sentence.Count - 1)
                    {
                        var bigram = sentence[i];
                        var followWord = sentence[i + 1];

                        if (!bigramCounts.ContainsKey(bigram))
                        {
                            bigramCounts[bigram] = new Dictionary<string, int>();
                        }

                        if (!bigramCounts[bigram].ContainsKey(followWord))
                        {
                            bigramCounts[bigram][followWord] = 0;
                        }

                        bigramCounts[bigram][followWord]++;
                    }

                    if (i < sentence.Count - 2)
                    {
                        var trigram = sentence[i] + " " + sentence[i + 1];
                        var followWord = sentence[i + 2];

                        if (!trigramCounts.ContainsKey(trigram))
                        {
                            trigramCounts[trigram] = new Dictionary<string, int>();
                        }

                        if (!trigramCounts[trigram].ContainsKey(followWord))
                        {
                            trigramCounts[trigram][followWord] = 0;
                        }

                        trigramCounts[trigram][followWord]++;
                    }
                }
            }

            var result = new Dictionary<string, string>();

            foreach (var bigram in bigramCounts)
            {
                var nextWords = bigram.Value;
                var mostFrequent = nextWords.OrderByDescending(pair => pair.Value)
                                             .ThenBy(pair => pair.Key)
                                             .First();
                result[bigram.Key] = mostFrequent.Key;
            }

            foreach (var trigram in trigramCounts)
            {
                var nextWords = trigram.Value;
                var mostFrequent = nextWords.OrderByDescending(pair => pair.Value)
                                             .ThenBy(pair => pair.Key)
                                             .First();
                result[trigram.Key] = mostFrequent.Key;
            }

            return result;
        }
    }
}
