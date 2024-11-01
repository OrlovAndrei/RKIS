using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis;
{
    static class FrequencyAnalysisTask
{
    public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
    {
        var ngramsCount = new Dictionary<string, int>();
        foreach (List<string> sentence in text)
        {
            for (int i = 0; i < sentence.Count - 1; i++)
            {
                string bigram = $"{sentence[i]} {sentence[i + 1]}";
                if (!ngramsCount.ContainsKey(bigram))
                    ngremsCount[bigram] = 0;
                ngramsCount[bigram]++;
            }
            for (int i = 0; i < sentence.Count - 1; i++)
            {
                string bigram = $"{sentence[i]} {sentence[i + 1]}";
                if (!ngramsCount.ContainsKey(bigram))
                    ngramsCount[bigram] = 0;
                ngramsCount[bigram]++;
            }
            for (int i = 0; i < sentence.Count - 2; i++)
            {
                string trigram = $"{sentence[i]} {sentence[i + 1]} {sentence[i + 2]}";
                if (!ngramsCount.ContainsKey(trigram))
                    ngramsCount[trigram] = 0;
                ngramsCount[trigram]++;
            }
        }
        var result = new Dictionary<string, string>();
        foreach (var entry in ngramsCount)
        {
            string start = entry.Key.Substring(0, entry.Key.LastIndexOf(''));
            string end = entry.Key.Substring(entry.Key.LastIndexOf('') + 1);
            if (!result.ContainsKey(start) ||
                (String.CompareOrdinal(result[start], end) > 0 &&
                 ngramsCount[$"{start} {end}"] >= ngramsCount[$"{start} {result[start]}"]))
            {
                result[start] = end;
            }
        }
        return result;
    }
}
}
   