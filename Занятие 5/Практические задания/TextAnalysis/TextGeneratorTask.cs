namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            var phrase = phraseBeginning.Trim();
            int addedWords = 0;

            while (addedWords < wordsCount)
            {
                var words = phrase.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string nextWord;

                if (words.Length >= 2)
                {
                    string key = $"{words[^2]} {words[^1]}"; 
                    if (nextWords.TryGetValue(key, out nextWord))
                    {
                        phrase += " " + nextWord;
                        addedWords++;
                        continue;
                    }
                }

                if (words.Length >= 1)
                {
                    string key = words[^1]; 
                    if (nextWords.TryGetValue(key, out nextWord))
                    {
                        phrase += " " + nextWord;
                        addedWords++;
                        continue;
                    }
                }

                break; 
            }

            return phrase;
        }
    }
}
