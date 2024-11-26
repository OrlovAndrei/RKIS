using System;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(Dictionary<string, string> nextWords, string phraseBeginning, int wordsCount)
        {
            var initialWords = phraseBeginning.Split(' ');
            var generatedWords = new List<string>(initialWords);

            for (int i = 0; i < wordsCount; i++)
            {
                string lastTwoWordsKey = GetLastTwoWordsKey(generatedWords);
                string lastWordKey = GetLastWordKey(generatedWords);

                if (!string.IsNullOrEmpty(lastTwoWordsKey) && nextWords.ContainsKey(lastTwoWordsKey))
                {
                    generatedWords.Add(nextWords[lastTwoWordsKey]);
                }
                else if (!string.IsNullOrEmpty(lastWordKey) && nextWords.ContainsKey(lastWordKey))
                {
                    generatedWords.Add(nextWords[lastWordKey]);
                }
                else
                {
                    break;
                }
            }

            return string.Join(" ", generatedWords);
        }

        private static string GetLastTwoWordsKey(List<string> words)
        {
            if (words.Count >= 2)
            {
                return words[^2] + " " + words[^1];
            }
            return null;
        }

        private static string GetLastWordKey(List<string> words)
        {
            if (words.Count > 0)
            {
                return words[^1];
            }
            return null;
        }
    }
}
