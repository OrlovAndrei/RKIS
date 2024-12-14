using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextAnalysis
{
    public static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            char[] sentenceDelimiters = new char[] { '.', '!', '?', ';', ':', '(', ')' };
            var sentences = text.Split(sentenceDelimiters, StringSplitOptions.RemoveEmptyEntries);
            var result = new List<List<string>>();

            foreach (var sentence in sentences)
            {
                var trimmedSentence = sentence.Trim();
                var words = Regex.Matches(trimmedSentence, @"[a-zA-Zа-яА-ЯёЁ']+");

                if (words.Count > 0)
                {
                    var wordList = new List<string>();
                    foreach (Match word in words)
                    {
                        wordList.Add(word.Value.ToLower());
                    }
                    result.Add(wordList);
                }
            }

            return result;
        }
    }
}
