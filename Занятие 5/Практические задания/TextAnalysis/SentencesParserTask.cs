namespace TextAnalysis;

static class SentencesParserTask
{
    public static List<List<string>> ParseSentences(string text)
    {
        var sentencesList = new List<List<string>>();
        var currentSentence = new List<string>();
            bool inWord = false;

            foreach (char c in text)
            {
                if (char.IsLetter(c) || c == '\'')
                {
                    if (!inWord)
                    {
                        inWord = true;
                        currentSentence.Add(c.ToString().ToLower());
                    }
                    else
                    {
                        currentSentence[currentSentence.Count - 1] += c.ToString().ToLower();
                    }
                }
                else if (inWord)
                {
                    inWord = false;
                }

                if (".!?;:()".Contains(c) && currentSentence.Count > 0)
                {
                    sentencesList.Add(currentSentence);
                    currentSentence = new List<string>();
                }
            }

            if (currentSentence.Count > 0)
            {
                sentencesList.Add(currentSentence);
            }
        return sentencesList;
    }
}
