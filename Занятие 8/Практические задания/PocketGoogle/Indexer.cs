using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle;

public class Indexer : IIndexer
{
    private readonly Dictionary<string, Dictionary<int, HashSet<int>>> indexes = new();
    private static readonly HashSet<char> Separators = new() { ' ', '.', ',', '!', '?', ':', '-', '\r', '\n' };

    public void Add(int id, string documentText)
    {
        int wordStartIndex = 0;

        for (int i = 0; i < documentText.Length; i++)
        {
            if (Separators.Contains(documentText[i]))
            {
                if (i > wordStartIndex)
                {
                    AddWordToIndex(id, documentText.Substring(wordStartIndex, i - wordStartIndex), wordStartIndex);
                }
                wordStartIndex = i + 1;
            }
        }

        if (wordStartIndex < documentText.Length)
        {
            AddWordToIndex(id, documentText.Substring(wordStartIndex), wordStartIndex);
        }
    }

    private void AddWordToIndex(int id, string word, int wordStartIndex)
    {
        if (string.IsNullOrWhiteSpace(word)) return;

        if (!indexes.ContainsKey(word))
        {
            indexes[word] = new Dictionary<int, HashSet<int>>();
        }

        var idDictionary = indexes[word];

        if (!idDictionary.ContainsKey(id))
        {
            idDictionary[id] = new HashSet<int>();
        }

        idDictionary[id].Add(wordStartIndex);
    }

    public List<int> GetIds(string word)
    {
        if (indexes.ContainsKey(word))
        {
            var idDictionary = indexes[word];
            var ids = new List<int>();
            foreach (var id in idDictionary.Keys)
            {
                ids.Add(id);
            }
            return ids;
        }
        return new List<int>();
    }

    public List<int> GetPositions(int id, string word)
    {
        if (indexes.ContainsKey(word) && indexes[word].ContainsKey(id))
        {
            var positions = new List<int>(indexes[word][id]);
            return positions;
        }
        return new List<int>();
    }

    public void Remove(int id)
    {
        var wordsToRemove = new List<string>();

        foreach (var entry in indexes)
        {
            if (entry.Value.ContainsKey(id))
            {
                wordsToRemove.Add(entry.Key);
            }
        }

        foreach (var word in wordsToRemove)
        {
            var idDictionary = indexes[word];
            idDictionary.Remove(id);

            if (idDictionary.Count == 0)
            {
                indexes.Remove(word);
            }
        }
    }
}