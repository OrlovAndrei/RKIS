using System;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            var words = phraseBeginning.Split(' ');
            var result = new List<string>(words);

            for (int i = 0; i < wordsCount; i++)
            {
                string lastTwoWordsKey = null;
                string lastWordKey = null;

                if (result.Count >= 2)
                {
                    lastTwoWordsKey = result[^2] + " " + result[^1];
                }

                if (result.Count >= 1)
                {
                    lastWordKey = result[^1];
                }

                if (lastTwoWordsKey != null && nextWords.ContainsKey(lastTwoWordsKey))
                {
                    result.Add(nextWords[lastTwoWordsKey]);
                }
                else if (lastWordKey != null && nextWords.ContainsKey(lastWordKey))
                {
                    result.Add(nextWords[lastWordKey]);
                }
                else
                {
                    break;
                }
            }

            return string.Join(" ", result);
        }
    }
}
