using System.Text;
namespace TextAnalysis;
static class TextGeneratorTask
{
    public static string ContinuePhrase(Dictionary<string, string> frequentNextWords, string initialWord, int totalWordsCount)
    {
        StringBuilder resultPhrase = new StringBuilder(initialWord);
        for (int index = 1; index < totalWordsCount; index++)
        {
            if (!frequentNextWords.ContainsKey(initialWord))
                break;
            initialWord = frequentNextWords[initialWord];
            resultPhrase.Append(" " + initialWord);
        }
        return resultPhrase.ToString();
    }
}