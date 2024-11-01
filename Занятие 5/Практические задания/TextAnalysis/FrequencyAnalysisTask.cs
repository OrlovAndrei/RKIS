namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> sentences)
        {
            var wordConnections = new Dictionary<string, Dictionary<string, int>>();
            foreach (var sentence in sentences)
            {
                for (int i = 0; i < sentence.Count - 1; i++)
                {
                    string key = sentence[i];
                    string nextWord = sentence[i + 1];
                    if (!wordConnections.ContainsKey(key))
                    {
                        wordConnections[key] = new Dictionary<string, int>();
                    }
                    if (!wordConnections[key].ContainsKey(nextWord))
                    {
                        wordConnections[key][nextWord] = 0;
                    }
                    wordConnections[key][nextWord]++;
                }
                for (int i = 0; i < sentence.Count - 2; i++)
                {
                    string key = $"{sentence[i]} {sentence[i + 1]}";
                    string nextWord = sentence[i + 2];
                    if (!wordConnections.ContainsKey(key))
                    {
                        wordConnections[key] = new Dictionary<string, int>();
                    }
                    if (!wordConnections[key].ContainsKey(nextWord))
                    {
                        wordConnections[key][nextWord] = 0;
                    }
                    wordConnections[key][nextWord]++;
                }
            }
            var result = new Dictionary<string, string>();
            foreach (var entry in wordConnections)
            {
                var mostFrequent = entry.Value
                    .OrderByDescending(kvp => kvp.Value)
                    .ThenBy(kvp => kvp.Key)
                    .First();
                result[entry.Key] = mostFrequent.Key;
            }
            return result;
        }
     }
 }
