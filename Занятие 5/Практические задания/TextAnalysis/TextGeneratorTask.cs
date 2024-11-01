namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            var words = phraseBeginning.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var result = phraseBeginning;

            for (int i = 0; i < wordsCount; i++)
            {
                string nextWord = GetNextWord(nextWords, words);

                if (string.IsNullOrEmpty(nextWord))
                {
                    break;
                }

                result += " " + nextWord;
                words = result.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            return result;
        }

        private static string GetNextWord(Dictionary<string, string> nextWords, string[] words)
        {
            if (words.Length >= 2)
            {
                var bigramKey = $"{words[words.Length - 2]} {words[words.Length - 1]}";
                if (nextWords.TryGetValue(bigramKey, out string nextWord))
                {
                    return nextWord;
                }
            }

            if (words.Length >= 1)
            {
                var unigramKey = words[words.Length - 1];
                if (nextWords.TryGetValue(unigramKey, out string nextWord))
                {
                    return nextWord;
                }
            }

            return null;
        }
    }
}