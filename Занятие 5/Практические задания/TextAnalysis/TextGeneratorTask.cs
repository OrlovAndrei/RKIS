using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, List<string>> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            var phrase = phraseBeginning.Split(' ').ToList();

            for (int i = 0; i < wordsCount; i++)
            {
                string key = null;

                if (phrase.Count >= 2)
                {
                    key = $"{phrase[^2]} {phrase[^1]}";
                }
                else if (phrase.Count == 1)
                {
                    key = phrase[^1]; 
                }

                if (key != null && nextWords.TryGetValue(key, out var options) && options.Count > 0)
                {
                    var nextWord = options[new Random().Next(options.Count)];
                    phrase.Add(nextWord);
                }
                else if (phrase.Count >= 1 && nextWords.TryGetValue(phrase[^1], out options) && options.Count > 0)
                {
                    var nextWord = options[new Random().Next(options.Count)];
                    phrase.Add(nextWord);
                }
                else
                {
                    break;
                }
            }

            return string.Join(" ", phrase);
        }
    }

    class Program
    {
        static void Main()
        {
            var nextWords = new Dictionary<string, List<string>>
            {
                { "привет", new List<string> { "как", "что", "зачем" } },
                { "как", new List<string> { "дела", "поживаешь" } },
                { "что", new List<string> { "нового", "происходит" } },
                { "дела как", new List<string> { "у тебя", "у нас" } },
                { "поживаешь", new List<string> { "хорошо", "нормально" } },
            };

            Console.Write("Введите начало фразы: ");
            string phraseBeginning = Console.ReadLine();
            Console.Write("Введите количество слов для дополнения: ");
            int wordsCount = int.Parse(Console.ReadLine());

            string result = TextGeneratorTask.ContinuePhrase(nextWords, phraseBeginning, wordsCount);
            Console.WriteLine("Сгенерированная фраза: " + result);
        }
    }
}
