namespace TextAnalysis;
using System.Collections.Generic;

static class SentencesParserTask
namespace TextAnalysis
{
    public static List<List<string>> ParseSentences(string text)
    static class SentencesParserTask
    {
        var sentencesList = new List<List<string>>();
        //...
        return sentencesList;
        static readonly char[] SplitSymbols = new char[7] { '.', '!', '?', ';', ':', '(', ')' };
        public static List<List<string>> ParseSentences(string text)
        {
            var sentenceList = new List<List<string>>();

            var sentenceIndex = 0;
            var wordIndex = 0;
            var nextWord = true;
            var nextSentence = true;

            foreach (var symbol in text)
            {
                if (char.IsLetter(symbol) || symbol.Equals('\''))
                {
                    nextSentence = true;
                    if (sentenceList.Count == 0) sentenceList.Add(new List<string>());
                    if (nextWord)
                    {
                        if (sentenceList[sentenceIndex].Count != 0) wordIndex++;
                        sentenceList[sentenceIndex].Add("");
                        nextWord = false;
                    }
                    sentenceList[sentenceIndex][wordIndex] += symbol.ToString().ToLower();
                }
                else
                {
                    nextWord = true;
                    if (IsSplitSymbol(symbol) && sentenceList.Count != 0 && nextSentence)
                    {
                        sentenceList.Add(new List<string>());
                        sentenceIndex++;
                        wordIndex = 0;
                        nextSentence = false;
                    }
                }
            }
            if (sentenceList.Count != 0 && sentenceList[sentenceIndex].Count == 0)
                sentenceList.RemoveAt(sentenceIndex);
            return sentenceList;
        }
        private static bool IsSplitSymbol(char c)
        {
            foreach (var splitSymbol in SplitSymbols)
                if (c.Equals(splitSymbol))
                    return true;
            return false;
        }
    }
}