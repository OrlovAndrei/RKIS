using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle

public class Indexer : IIndexer
{
    private char[] _wordsSplitter = new char[] { ' ', '.', ',', '!', '?', ':', '-', '\r', '\n' };
    private Dictionary<string, Dictionary<int, List<int>>> _words;

    public Indexer()
    {
        _words = new Dictionary<string, Dictionary<int, List<int>>>();
    }

    public void Add(int id, string documentText)
    {
        var document = documentText.Split(_wordsSplitter, StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in document)
        {
            if (!_words.ContainsKey(word))
            {
                _words[word] = new Dictionary<int, List<int>>();
            }

            if (!_words[word].ContainsKey(id))
            {
                _words[word][id] = GetWordPositions(word, documentText);
            }
            else
            {

                var existingPositions = GetWordPositions(word, documentText);
                foreach (var position in existingPositions)
                {
                    if (!_words[word][id].Contains(position))
                    {
                        _words[word][id].Add(position);
                    }
                }
            }
        }
    }

    private List<int> GetWordPositions(string word, string text)
    {
        var result = new List<int>();
        var sample = PrefixFunction(word);
        var len = word.Length;
        var j = 0;

        for (var i = 0; i < text.Length; i++)
        {
            while (j > 0 && text[i] != word[j])
                j = sample[j - 1];

            if (text[i] == word[j])
                j++;

            if (j == len)
            {
                result.Add(i - len + 1);
                j = sample[j - 1];
            }
        }

        return result;
    }

    private int[] PrefixFunction(string pattern)
    {
        var len = pattern.Length;
        var prefixLens = new int[len];
        prefixLens[0] = 0;

        for (var i = 1; i < len; i++)
        {
            var j = prefixLens[i - 1];
            while (j > 0 && pattern[i] != pattern[j])
                j = prefixLens[j - 1];

            if (pattern[i] == pattern[j])
                j++;

            prefixLens[i] = j;
        }

        return prefixLens;
    }

    public List<int> GetIds(string word)
    {
        if (_words.ContainsKey(word))
            return new List<int>(_words[word].Keys);
        return new List<int>();
    }

    public List<int> GetPositions(int id, string word)
    {
        if (_words.ContainsKey(word) && _words[word].ContainsKey(id))
            return _words[word][id];
        return new List<int>();
    }

    public void Remove(int id)
    {
        foreach (var word in new List<string>(_words.Keys))
        {
            if (_words[word].ContainsKey(id))
            {
                _words[word].Remove(id);

                if (_words[word].Count == 0)
                {
                    _words.Remove(word);
                }
            }
        }
    }
}