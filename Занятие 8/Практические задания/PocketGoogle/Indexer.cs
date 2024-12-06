using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle;

public class Indexer : IIndexer

{
    private Dictionary<string, Dictionary<int, List<int>>> _index;
    private int _documentIdCounter;
    public Indexer()
    {
        _index = new Dictionary<string, Dictionary<int, List<int>>>();
        _documentIdCounter = 0;
    }
    public int Add(string document)
    {
        int docId = _documentIdCounter++;
        var words = GetWords(document);
        foreach (var word in words)
        {
            if (!_index.ContainsKey(word))
            {
                _index[word] = new Dictionary<int, List<int>>();
            }
            if (!_index[word].ContainsKey(docId))
            {
                _index[word][docId] = new List<int>();
            }
            int position = 0;
            foreach (var w in words)
            {
                if (w == word)
                {
                    _index[word][docId].Add(position);
                }
                position += w.Length + 1;
            }
        }
        return docId;
    }
    public List<int> GetIds(string word)
    {
        if (_index.ContainsKey(word))
        {
            return _index[word].Keys.ToList();
        }
        return new List<int>();
    }
    public List<int> GetPositions(string word, int docId)
    {
        if (_index.ContainsKey(word) && _index[word].ContainsKey(docId))
        {
            return _index[word][docId];
        }
        return new List<int>();
    }
    public void Remove(int docId)
    {
        foreach (var word in _index.Keys.ToList())
        {
            if (_index[word].ContainsKey(docId))
            {
                _index[word].Remove(docId);
            }
            if (_index[word].Count == 0)
            {
                _index.Remove(word);
            }
        }
    }
    private List<string> GetWords(string document)
    {
        char[] separators = { ' ', '.', ',', '!', '?', ':', '-', '\r', '\n' };
        return document.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                       .Select(word => word.ToLowerInvariant())
                       .ToList();
    }
}
