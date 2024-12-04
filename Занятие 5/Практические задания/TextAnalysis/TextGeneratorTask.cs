using System.Text;
namespace TextAnalysis;
static class TextGeneratorTask
{
    public static string ContinuePhrase(Dictionary<string, string> freqNextWords, string initWord, int totalWordsCount)
    {
        StringBuilder resultPhrase = new StringBuilder(initWord);
        for (int index = 1; index < totalWordsCount; index++)
        {
            if (!freqNextWords.ContainsKey(initWord))
                break;
            initWord = freqNextWords[initWord];
            resultPhrase.Append(" " + initWord);
        }
        return resultPhrase.ToString();
    }
}
