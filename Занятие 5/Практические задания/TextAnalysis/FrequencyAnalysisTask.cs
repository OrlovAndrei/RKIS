using System.Collections.Generic;
using System;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        private enum Ngrams
        {
            Bigramm = 1,
            Trigramm = 2
        };
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            result = GetNgrams(text, result, Ngrams.Bigramm);
            result = GetNgrams(text, result, Ngrams.Trigramm);
            return result;
        }
        private static Dictionary<string, string> GetNgrams(List<List<string>> text,
          Dictionary<string, string> result,
          Ngrams gramma)
        {
            var grammasWithFrequency = new Dictionary<string, Dictionary<string, int>>();
            grammasWithFrequency = GetGrammasWithFrequency(grammasWithFrequency, text, gramma);
            return GetGrammasWithoutFrequency(grammasWithFrequency, result);
        }
        private static Dictionary<string, string> GetGrammasWithoutFrequency(Dictionary<string, Dictionary<string, int>> grammasWithFrequency,
            Dictionary<string, string> result)
        {
            foreach (var pairs in grammasWithFrequency)
            {
                var min = 1;
                foreach (var pair in pairs.Value)
                {
                    if (!result.TryGetValue(pairs.Key, out _))
                        result.Add(pairs.Key, pair.Key);
                    if (pair.Value > min || (pair.Value >= min && string.CompareOrdinal(pair.Key, result[pairs.Key]) < 0))
                    {
                        result[pairs.Key] = pair.Key;
                        min = pair.Value;
                    }
                }
            }
            return result;
        }
        private static Dictionary<string, Dictionary<string, int>> GetGrammasWithFrequency(Dictionary<string, Dictionary<string, int>> grammas,
            List<List<string>> text,
            Ngrams gramma)
        {
            for (int i = 0; i < text.Count; i++)
            {
                var sentence = text[i];
                for (int j = 0; j < sentence.Count - (int)gramma; j++)
                {
                    string firstWord;
                    string nextWord;
                    switch (gramma)
                    {
                        case Ngrams.Bigramm:
                            firstWord = sentence[j];
                            nextWord = sentence[j + 1];
                            break;
                        case Ngrams.Trigramm:
                            firstWord = String.Join(" ", new string[2] { sentence[j], sentence[j + 1] });
                            nextWord = sentence[j + 2];
                            break;
                        default:
                            throw new ArgumentException();
                    }
                    grammas = GetFrequency(grammas, firstWord, nextWord);
                }
            }
            return grammas;
        }
        private static Dictionary<string, Dictionary<string, int>> GetFrequency(Dictionary<string, Dictionary<string, int>> grammas,
            string word,
            string nextWord)
        {
            if (grammas.TryGetValue(word, out _))
            {
                if (grammas[word].TryGetValue(nextWord, out _))
                    grammas[word][nextWord]++;
                else
                    grammas[word].Add(nextWord, 1);
            }
            else
                grammas.Add(word, new Dictionary<string, int> { { nextWord, 1 } });
            return grammas;
        }
    }
}
