using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle;

public class Indexer : IIndexer
{
    private readonly Dictionary<string, Dictionary<int, List<int>>> _wordIndex = new();
    private readonly Dictionary<int, string> _documents = new();
    private static readonly char[] WordDelimiters = { ' ', '.', ',', '!', '?', ':', '-', '\r', '\n' };

    public void Add(int id, string documentText)
    {
        if (_documents.ContainsKey(id))
        {
            Remove(id);
        }

        _documents[id] = documentText;

        string[] words = documentText.Split(WordDelimiters, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i].ToLower();

            if (!_wordIndex.ContainsKey(word))
            {
                _wordIndex[word] = new Dictionary<int, List<int>>();
            }

            if (!_wordIndex[word].ContainsKey(id))
            {
                _wordIndex[word][id] = new List<int>();
            }

            _wordIndex[word][id].Add(i);
        }
    }

    public List<int> GetIds(string word)
    {
        word = word.ToLower();
        if (_wordIndex.TryGetValue(word, out var documentMap))
        {
            return documentMap.Keys.ToList();
        }
        return new List<int>();
    }

    public List<int> GetPositions(int id, string word)
    {
        word = word.ToLower();
        if (_wordIndex.TryGetValue(word, out var documentMap) && documentMap.TryGetValue(id, out var positions))
        {
            return positions;
        }
        return new List<int>();
    }

    public void Remove(int id)
    {
        if (_documents.ContainsKey(id))
        {
            _documents.Remove(id);

            foreach (var word in _wordIndex.Keys.ToList())
            {
                if (_wordIndex[word].ContainsKey(id))
                {
                    _wordIndex[word].Remove(id);
                }

                if (_wordIndex[word].Count == 0)
                {
                    _wordIndex.Remove(word);
                }
            }
        }
    }
}
