namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
        Dictionary<string, string> nextWords,
        string phraseBeginning,
        int wordsCount)
        {
            for (int i = 0; i < wordsCount; i++)
            {
                string[] splitWords = phraseBeginning.Split(' ');
                if (splitWords.Length > 0)
                {
                    if (splitWords.Length >= 2 && nextWords.ContainsKey(splitWords[splitWords.Length - 2] + " " + splitWords[splitWords.Length - 1]))
                        phraseBeginning += " " + nextWords[splitWords[splitWords.Length - 2] + " " + splitWords[splitWords.Length - 1]];

                    else if (splitWords.Length >= 1 && nextWords.ContainsKey(splitWords[splitWords.Length - 1]))
                        phraseBeginning += " " + nextWords[splitWords[splitWords.Length - 1]];

                    else
                        return phraseBeginning;
                }
            }

            return phraseBeginning;
        }
    }
}