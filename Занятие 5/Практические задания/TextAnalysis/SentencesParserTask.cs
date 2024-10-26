using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var sentenceDelimiters = new[] { '.', '!', '?', ';', ':', '(', ')' };
            var sentences = text.Split(sentenceDelimiters, StringSplitOptions.RemoveEmptyEntries);

            foreach (var sentence in sentences)
            {
                // Разделяем предложение на слова
                var words = sentence.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(word => new string(word.Where(c => char.IsLetter(c) || c == '\'').ToArray()))
                    .Where(word => !string.IsNullOrEmpty(word))
                    .Select(word => word.ToLowerInvariant())
                    .ToList();

                if (words.Count > 0)
                {
                    sentencesList.Add(words);
                }
            }

            return sentencesList;
        }
    }

    class Program
    {
        static void Main()
        {
            string text = "Привет! Как дела? Это пример текста: Hello, world! What's up?";
            var sentences = SentencesParserTask.ParseSentences(text);

            foreach (var sentence in sentences)
            {
                Console.WriteLine(string.Join(", ", sentence));
            }
        }
    }
}
