namespace TextAnalysis;

static class FrequencyAnalysisTask
{
    public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
    {
        var result = new Dictionary<string, string>();
        var bigrams = new Dictionary<string, Dictionary<string, int>>();
            var trigrams = new Dictionary<string, Dictionary<string, int>>();

            foreach (var sentence in text)
            {
                for (int i = 0; i < sentence.Count; i++)
                {
                    // Биграммы
                    if (i < sentence.Count - 1)
                    {
                        var bigramKey = sentence[i];
                        var bigramValue = sentence[i + 1];

                        if (!bigrams.ContainsKey(bigramKey))
                        {
                            bigrams[bigramKey] = new Dictionary<string, int>();
                        }

                        if (!bigrams[bigramKey].ContainsKey(bigramValue))
                        {
                            bigrams[bigramKey][bigramValue] = 0;
                        }

                        bigrams[bigramKey][bigramValue]++;
                    }

                    // Триграммы
                    if (i < sentence.Count - 2)
                    {
                        var trigramKey = string.Join(" ", sentence.Skip(i).Take(2));
                        var trigramValue = sentence[i + 2];

                        if (!trigrams.ContainsKey(trigramKey))
                        {
                            trigrams[trigramKey] = new Dictionary<string, int>();
                        }

                        if (!trigrams[trigramKey].ContainsKey(trigramValue))
                        {
                            trigrams[trigramKey][trigramValue] = 0;
                        }

                        trigrams[trigramKey][trigramValue]++;
                    }
                }
            }

            // Создание словаря самых частотных продолжений
            foreach (var key in bigrams.Keys)
            {
                var mostFrequentValue = bigrams[key].OrderByDescending(x => x.Value).ThenBy(x => x.Key).FirstOrDefault();
                if (mostFrequentValue.Key != null)
                {
                    result[key] = mostFrequentValue.Key;
                }
            }

            foreach (var key in trigrams.Keys)
            {
                var mostFrequentValue = trigrams[key].OrderByDescending(x => x.Value).ThenBy(x => x.Key).FirstOrDefault();
                if (mostFrequentValue.Key != null)
                {
                    result[key] = mostFrequentValue.Key;
                }
            }

        return result;
    }
}
