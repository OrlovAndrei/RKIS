using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis;
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var sentenceSeparators = new[] { '.', '!', '?', ';', ':', '(', ')' };
            var sentences = text.Split(sentenceSeparators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var sentence in sentences)
            {
                var words = new List<string>();
                var word = new List<char>();

                foreach (var ch in sentence)
                {
                    if (char.IsLetter(ch) || ch == '\'')
                    {
                        word.Add(char.ToLower(ch)); // Приводим к нижнему регистру
                    }
                    else if (word.Count > 0)
                    {
                        words.Add(new string(word.ToArray()));
                        word.Clear();
                    }
                }

                // Добавляем последнее слово, если оно есть
                if (word.Count > 0)
                    words.Add(new string(word.ToArray()));

                // Добавляем предложения с минимум одним словом
                if (words.Count > 0)
                    sentencesList.Add(words);
            }

            return sentencesList;
        }
    }
}