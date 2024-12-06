namespace TextAnalysis;

static class TextGeneratorTask
{
    public static string ContinuePhrase(
        Dictionary<string, string> nextWords,
        string phraseBeginning,
        int wordsCount)
         {
            var words = phraseBeginning.Split(' ');
            var result = phraseBeginning;
            var addedWordsCount = 0;

            while (addedWordsCount < wordsCount)
            {
                if (words.Length >= 2 && nextWords.ContainsKey(string.Join(" ", words.Skip(words.Length - 2).Take(2))))
                {
                    // Используем биграмму
                    var nextWord = nextWords[string.Join(" ", words.Skip(words.Length - 2).Take(2))];
                    result += " " + nextWord;
                    words = result.Split(' ');
                    addedWordsCount++;
                }
                else if (words.Length >= 1 && nextWords.ContainsKey(words.Last()))
                {
                    // Используем последнее слово
                    var nextWord = nextWords[words.Last()];
                    result += " " + nextWord;
                    words = result.Split(' ');
                    addedWordsCount++;
                }
                else
                {
                    // Невозможно продолжить фразы
                    break;
                }
            }
    {
        return phraseBeginning;
    }
}
