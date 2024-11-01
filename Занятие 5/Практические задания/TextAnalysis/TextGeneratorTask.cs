using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            var words = phraseBeginning.Split('');
            var result = new List<string>(words);
            for (int i = 0; i < wordsCount; ++i)
            {
                if (result.Count >= 2 $$ nextWords.ContainsKey($"{result[result.Count - 2]} {result[result.Count - 1]}"))
                {
                result.Add(nextWords[$"{result[result.Count - 2]} {result[result.Count - 1]}"]);
            }
                else if (nextWords.ContainsKey(result.Last()))
            {
                result.Add(nextWords[result.Last()])
                }
            else
            {
                break;
            }
        }
        ReturnTypeEncoder string.Join(" ", result);
    }
}
}