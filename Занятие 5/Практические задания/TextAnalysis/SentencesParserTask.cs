using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> sentences)
        {
            var bigrams = new Dictionary<string, Dictionary<string, int>>();
            var trigrams = new Dictionary<string, Dictionary<string, int>>();

            foreach (var sentence in sentences)
            {
                for (int i = 0; i < sentence.Count; i++)
                {
                    if (i < sentence.Count - 1)
                    {
                        string bigram = sentence[i];
                        string nextWord = sentence[i + 1];

                        if (!bigrams.ContainsKey(bigram))
                        {
                            bigrams[bigram] = new Dictionary<string, int>();
                        }

                        if (!bigrams[bigram].ContainsKey(nextWord))
                        {
                            bigrams[bigram][nextWord] = 0;
                        }
                        bigrams[bigram][nextWord]++;
                    }

                    if (i < sentence.Count - 2)
                    {
                        string trigram = sentence[i] + " " + sentence[i + 1];
                        string nextWord = sentence[i + 2];

                        if (!trigrams.ContainsKey(trigram))
                        {
                            trigrams[trigram] = new Dictionary<string, int>();
                        }

                        if (!trigrams[trigram].ContainsKey(nextWord))
                        {
                            trigrams[trigram][nextWord] = 0;
                        }
                        trigrams[trigram][nextWord]++;
                    }
                }
            }

            var result = new Dictionary<string, string>();

            foreach (var bigram in bigrams)
            {
                var mostFrequent = bigram.Value
                    .OrderByDescending(pair => pair.Value)
                    .ThenBy(pair => pair.Key)
                    .First();
                result[bigram.Key] = mostFrequent.Key;
            }

            foreach (var trigram in trigrams)
            {
                var mostFrequent = trigram.Value
                    .OrderByDescending(pair => pair.Value)
                    .ThenBy(pair => pair.Key)
                    .First();
                result[trigram.Key] = mostFrequent.Key;
            }

            return result;
        }
    }

    class Program
    {
        static void Main()
        {
            string text = "a b c d. b c d. e b c a d.";
            var sentences = SentencesParserTask.ParseSentences(text);

            var frequentWords = FrequencyAnalysisTask.GetMostFrequentNextWords(sentences);

            foreach (var entry in frequentWords)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
}
