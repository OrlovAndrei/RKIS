using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWordsDictionary,
            string phraseBeginning,
            int wordsCount)
        {
            if (nextWordsDictionary == null || nextWordsDictionary.Count == 0 || string.IsNullOrWhiteSpace(phraseBeginning))
            {
                return phraseBeginning;
            }

            var result = new List<string>(phraseBeginning.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            int currentCount = 0;

            while (currentCount < wordsCount)
            {
                string key;

                if (result.Count >= 2)
                {
                    key = result[result.Count - 2] + " " + result[result.Count - 1];
                }
                else if (result.Count == 1)
                {
                    key = result.Last();
                }
                else
                {
                    break;
                }

                if (nextWordsDictionary.TryGetValue(key, out string nextWord))
                {
                    result.Add(nextWord);
                }
                else
                {
                    break; 
                }

                currentCount++;
            }

            return string.Join(" ", result);
        }
    }
}
