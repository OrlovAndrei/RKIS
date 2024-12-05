using System;
using System.Collections.Generic;

namespace TextAnalysis;
{
    static class TextGeneratorTask
    {
        public static string ContinuePhrase(
            Dictionary<string, string> nextWords,
            string phraseBeginning,
            int wordsCount)
        {
            var words = new List<string>(phraseBeginning.Split(' ')); // Разбиваем начальную фразу на слова

            for (int i = 0; i < wordsCount; i++)
            {
                string nextWord = null;

                // Попытка найти продолжение по двум последним словам
                if (words.Count >= 2)
                {
                    var lastTwoWords = words[^2] + " " + words[^1]; // Берем последние два слова
                    if (nextWords.ContainsKey(lastTwoWords))
                    {
                        nextWord = nextWords[lastTwoWords];
                    }
                }

                // Если не нашли по двум словам, ищем по последнему слову
                if (nextWord == null && words.Count >= 1)
                {
                    var lastWord = words[^1]; // Берем последнее слово
                    if (nextWords.ContainsKey(lastWord))
                    {
                        nextWord = nextWords[lastWord];
                    }
                }

                // Если подходящего продолжения нет, возвращаем сгенерированную фразу
                if (nextWord == null)
                    break;

                words.Add(nextWord); // Добавляем следующее слово в фразу
            }

            return string.Join(" ", words); // Возвращаем сгенерированную фразу
        }
    }
}