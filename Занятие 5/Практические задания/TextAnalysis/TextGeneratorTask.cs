

using System;
using System.Collections.Generic;



public class TextGeneratorTask


{


    public string GenerateText(Dictionary<string, string> nextWords, string phraseBeginning, int wordsCount)
    {


        List<string> words = new List<string>(phraseBeginning.Split(' '));


        for (int i = 0; i < wordsCount; i++)
        {


            string key = GetKey(words);
            if (string.IsNullOrEmpty(key) || !nextWords.ContainsKey(key))
            {


                break;
            }


            string nextWord = nextWords[key];
            words.Add(nextWord);
        }


        return string.Join(" ", words);
    }


    private string GetKey(List<string> words)
    {

        if (words.Count >= 2)
        {

            return $"{words[^2]} {words[^1]}"; // последние два слова
        }

        else if (words.Count == 1)
        {

            return words[^1]; // последнее слово
        }

        return string.Empty;
    }

}


