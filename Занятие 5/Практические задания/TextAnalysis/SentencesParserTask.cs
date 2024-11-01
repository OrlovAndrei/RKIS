using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TextAnalysis;
{
    public static class SentencesParserTask
    {
    public static List<List<string>> ParseSentences(string text)
    {
        var sentencesList = new List<List<string>>();
        var sentencePattern = @".+? [.!?;:}";
        var sentences = Regex.Matches(text, sentencePattern);
        foreach (Match sentence in sentences)
        {
            var words = new List<string>();
            var currentWord = new StringBuilder();
            foreach (char c in sentence.Value)
            {
                if (char.IsLetter(c) || c == '\'')
                {
                    currentWord.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    if (currentWord.Lenght > 0)
                    {
                        words.Add(currentWord.ToString());
                        currentWord.Clear();
                    }
                }
            }
            if (currentWord.Length > 0)
            {
                words.Add(currentWord.ToString())
                    }
            if (words.Count > 0)
            {
                sentencesList.Add(words);
            }
        }
        return sentencesList;
    }
    }
}