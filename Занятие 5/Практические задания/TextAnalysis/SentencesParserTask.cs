namespace TextAnalysis
{
    static class SentencesParserTask
    {
        static char[] sentenceEndSymbols = new char[] { '.', '!', '?', ';', ':', '(', ')' };
        public static readonly string[] stopWordsList =
        {
            "the", "and", "to", "a", "of", "in", "on", "at", "that",
            "as", "but", "with", "out", "for", "up", "one", "from", "into"
        };
        public static List<List<string>> ParseSentences(string inputText)
        {
            inputText = inputText.ToLower();
            List<List<string>> sentenceList = new List<List<string>>();
            string[] sentencesArray = inputText.Split(sentenceEndSymbols);
            foreach (var currentSentence in sentencesArray)
            {
                List<string> wordList = new List<string>();
                var processedSentence = SeparateSimbol(currentSentence);
                string[] wordsArray = processedSentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var currentWord in wordsArray)
                {
                    if (BadWord(currentWord) && currentWord != "")
                        wordList.Add(currentWord);
                }
                if (wordList.Count == 0) continue;
                else sentenceList.Add(wordList);
            }
            return sentenceList;
        }
        private static string SeparateSimbol(string currentWord)
        {
            var processedText = "";
            foreach (var currentChar in currentWord)
            {
                if (char.IsLetter(currentChar) || (currentChar == '\''))
                    processedText = processedText + currentChar;
                else processedText = processedText + ' ';
            }
            return processedText;
        }
        public static bool BadWord(string inputWord)
        {
            foreach (var stopWord in stopWordsList)
                if (stopWord == inputWord)
                    return false;
            return true;
        }
    }
}