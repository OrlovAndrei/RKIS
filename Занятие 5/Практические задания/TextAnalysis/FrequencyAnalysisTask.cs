namespace TextAnalysis;
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            var nGramFrequencies = new Dictionary<string, Dictionary<string, int>>();

            foreach (var sentence in text)
            {
                // Формируем биграммы
                for (int i = 0; i < sentence.Count - 1; i++)
                {
                    var bigramKey = sentence[i];
                    var bigramNext = sentence[i + 1];
                    AddToNGramFrequencies(nGramFrequencies, bigramKey, bigramNext);

                    // Формируем триграммы
                    if (i < sentence.Count - 2)
                    {
                        var trigramKey = $"{sentence[i]} {sentence[i + 1]}";
                        var trigramNext = sentence[i + 2];
                        AddToNGramFrequencies(nGramFrequencies, trigramKey, trigramNext);
                    }
                }
            }

            // Теперь для каждого N-грамма выбираем самое частотное продолжение
            foreach (var nGram in nGramFrequencies)
            {
                var mostFrequentNextWord = nGram.Value
                    .OrderByDescending(pair => pair.Value) // По частоте
                    .ThenBy(pair => pair.Key, StringComparer.Ordinal) // Лексикографически
                    .First()
                    .Key;

                result[nGram.Key] = mostFrequentNextWord;
            }

            return result;
        }

        private static void AddToNGramFrequencies(Dictionary<string, Dictionary<string, int>> nGramFrequencies, string nGramKey, string nextWord)
        {
            if (!nGramFrequencies.ContainsKey(nGramKey))
                nGramFrequencies[nGramKey] = new Dictionary<string, int>();

            if (!nGramFrequencies[nGramKey].ContainsKey(nextWord))
                nGramFrequencies[nGramKey][nextWord] = 0;

            nGramFrequencies[nGramKey][nextWord]++;
        }
    }
}