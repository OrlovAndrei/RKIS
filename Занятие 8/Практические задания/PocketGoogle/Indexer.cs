using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PocketGoogle;

public class Indexer : IIndexer
{
    private readonly Dictionary<string, Dictionary<int, List<int>>> _index = new();
    public void Add(int id, string documentText)
    {
        string[] words = Regex.Split(documentText, @"[ ,.!?:\r\n-]+");

        for (int position = 0; position < words.Length; position++)
        {
            string word = words[position].ToLower();
            if (string.IsNullOrWhiteSpace(word)) continue;
            if (!_index.ContainsKey(word))
            {
                _index[word] = new Dictionary<int, List<int>>();
            }

            if (!_index[word].ContainsKey(id))
            {
                _index[word][id] = new List<int>();
            }

            _index[word][id].Add(position);
        }
    }

    public List<int> GetIds(string word)
    {
        word = word.ToLower();
        return _index.ContainsKey(word) ? new List<int>(_index[word].Keys) : new List<int>();
    }

    public List<int> GetPositions(int id, string word)
    {
        word = word.ToLower();
        return _index.ContainsKey(word) && _index[word].ContainsKey(id) ? new List<int>(_index[word][id]) : new List<int>();
    }

    public void Remove(int id)
    {
        foreach (var word in _index.Keys)
        {
            if (_index[word].ContainsKey(id))
            {
                _index[word].Remove(id);
            }
        }
    }
}