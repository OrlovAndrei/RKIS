using System.Collections.Generic;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string Split(string text, int i)
        {

            return text.Split()[text.Split().Length - i];
        }

        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            string phrase = phraseBeginning;
            string additionalphrase = null;
            for (int i = 0; i < wordsCount; i++)
            {
                if (nextWords.ContainsKey(phraseBeginning)) additionalphrase = nextWords[phraseBeginning];
                else if (phraseBeginning.Split().Length > 1)
                {
                    if (nextWords.ContainsKey(Split(phraseBeginning, 2) + " " + Split(phraseBeginning, 1))) additionalphrase = nextWords[Split(phraseBeginning, 2) + " " + Split(phraseBeginning, 1)];
                    else if (nextWords.ContainsKey(Split(phraseBeginning, 1))) additionalphrase = nextWords[Split(phraseBeginning, 1)];
                    else break;
                }
                else break;
                if (phraseBeginning.Split().Length > 1)
                    phraseBeginning = phraseBeginning.Split()[phraseBeginning.Split().Length - 1] + " " + additionalphrase;
                else phraseBeginning = phraseBeginning + " " + additionalphrase;
                phrase += (" " + additionalphrase);
            }
            return phrase;
        }
    }
}