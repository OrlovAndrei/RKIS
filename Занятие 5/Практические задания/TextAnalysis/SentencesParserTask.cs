namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var result = new List<List<string>>();
            var result = new List<List<string>>();
            var sentences = Regex.Split(text, @"(?<=[.!?;:()])\s*");
            foreach (var sentence in sentences)
            {
                var cleanedSentence = sentence.Trim();
                var words = Regex.Matches(cleanedSentence, @"[a-zA-Zа-яА-ЯёЁ']+");
                var wordList = new List<string>();
                foreach (Match word in words)
                {
                    wordList.Add(word.Value.ToLower());
                }
                if (wordList.Count > 0)
                {
                    result.Add(wordList);
                }
            }
            return result;
        }
    }
 }
