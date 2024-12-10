namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var currentSentence = new List<string>();
            var currentWord = new StringBuilder();

            foreach (char c in text)
            {
                if (char.IsLetter(c) || c == ''')
                {
                    currentWord.Append(c);
                }
                else
                {
                    if (currentWord.Length > 0)
                    {
                        currentSentence.Add(currentWord.ToString().ToLower());
                        currentWord.Clear();
                    }

                    if (".!?;:()".Contains(c) && currentSentence.Count > 0)
                    {
                        sentencesList.Add(currentSentence);
                        currentSentence = new List<string>();
                    }
                }
            }

            if (currentWord.Length > 0)
            {
                currentSentence.Add(currentWord.ToString().ToLower());
            }

            if (currentSentence.Count > 0)
            {
                sentencesList.Add(currentSentence);
            }

            return sentencesList;
        }
    }
}