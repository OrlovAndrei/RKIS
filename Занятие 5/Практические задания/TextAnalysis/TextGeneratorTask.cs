using System.Collections.Generic;
using System;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            List<string> key = new List<string>();

            for (int word = 0; word < wordsCount; word++)
            {
                key = RebuildPhraseBeginning(key, phraseBeginning);

                if (key.Count == 0)
                    return phraseBeginning;

                if (key.Count == 2)
                {
                    if (TryAddWord(nextWords, String.Join(" ", key[0], key[1]), ref phraseBeginning))
                        continue;
                    if (TryAddWord(nextWords, key[1], ref phraseBeginning))
                        continue;
                    return phraseBeginning;
                }
                else //keycount = 1
                {
                    if (TryAddWord(nextWords, key[0], ref phraseBeginning))
                        continue;
                    return phraseBeginning;
                }
            }
            return phraseBeginning;
        }
        private static List<string> RebuildPhraseBeginning(List<string> key, string phraseBeginning)
        {
            key.Clear();
            var phrases = phraseBeginning.Split(' ');
            if (phrases.Length >= 2)
            {
                key.Add(phrases[phrases.Length - 2]);
                key.Add(phrases[phrases.Length - 1]);
            }
            else if (phrases.Length == 1)
            {
                key.Add(phrases[0]);
            }
            return key;
        }
        private static bool TryAddWord(Dictionary<string, string> nextWords, string skey, ref string phraseBeginning)
        {
            if (nextWords.TryGetValue(skey, out _))
            {
                phraseBeginning = String.Join(" ", phraseBeginning, nextWords[skey]);
                return true;
            }
            return false;
        }
    }
}
