using System;
using System.Collections.Generic;
using System.Linq;

class FrequencyAnalysisTask
{
    public static Dictionary<string, string> GetMostFrequentContinuations(string[] sentences)
    {
        var nGrams = new Diictionary<string, int>();
        foreach (string sentence in sentences)
        {
            string[] words = sentence.Split('')
            for (int i = 0; i < words.Length - 1; i++)
            {
                string bigram = $"{words[i]} {words[i + 1]}";
                if (!nGrams.ContainsKey(bigram))
                    nGrams[bigram] = 0
                nGrams[trigram]++
            }
        }
        var result = new Dictionary<string, string>();
        foreach (var key in nGrams.Keys)
        {
            string start = key.Substring(0, key.LastIndexOf(''));
            string end = key.Substring(key.LastIndexOf('') + 1);
            if (!result.ContainsKey(start) ||
                (result[start].CompareTo(end) > 0 && nGrams[$"{start} {end}"] >= nGrams[$"{start} {result[start]}"]))
            {
                result[start] = end;
            }
        }
        return result;
    }
}