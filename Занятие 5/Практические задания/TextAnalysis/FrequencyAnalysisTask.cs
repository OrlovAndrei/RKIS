namespace TextAnalysis
{
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
                        var trigram = $"{sentence[i]} {sentence[i + 1]}";
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
                var mostFrequentWord = GetMostFrequentWord(bigram.Value);
                result[bigram.Key] = mostFrequentWord;
            }

            foreach (var trigram in trigramDict)
            {
                var mostFrequentWord = GetMostFrequentWord(trigram.Value);
                result[trigram.Key] = mostFrequentWord;
            }

            return result;
        }

        private static string GetMostFrequentWord(Dictionary<string, int> wordCounts)
        {
            string mostFrequent = null;
            int maxCount = 0;

            foreach (var pair in wordCounts)
            {
                if (pair.Value > maxCount || (pair.Value == maxCount && string.CompareOrdinal(pair.Key, mostFrequent) < 0))
                {
                    mostFrequent = pair.Key;
                    maxCount = pair.Value;
                }
            }

            return mostFrequent;
        }
    }
}