using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var listSentences = new List<List<string>>();


            if (text == null) return null;
            text = text.ToLower();
            var sentences = text.Split(".:;?!()".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
            foreach (var sent in sentences)
            {
                var listWords = new List<string>();
                var builder = new StringBuilder();
                foreach (var ch in sent)
                {
                    if (char.IsLetter(ch) || ch == '\'')
                        builder.Append(ch);
                    else
                        AddNotEmptyWord(builder, listWords);
                }
                AddNotEmptyWord(builder, listWords);
                if (listWords.Count > 0)
                    listSentences.Add(listWords);
            }
            return listSentences;
        }

        public static void AddNotEmptyWord(StringBuilder builder, List<string> listWords)
        {
            if (builder.Length > 0)
            {
                listWords.Add(builder.ToString());
                builder.Clear();
            }
        }
    }