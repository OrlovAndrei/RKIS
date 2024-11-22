using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle;

public class Indexer : IIndexer
{
    private readonly Dictionary<int, string> indexes = new();

    public void Add(int id, string documentText)
    {
        indexes[id] = documentText.ToLower(); // Сохранение текста в нижнем регистре для поиска
    }

    public List<int> GetIds(string word)
    {
        word = word.ToLower(); // Приведение слова к нижнему регистру
        return indexes
            .Where(entry => entry.Value
                .Split(new[] { ' ', '.', ',', '!', '?', ':', '-', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Contains(word))
            .Select(entry => entry.Key)
            .ToList();
    }

    public List<int> GetPositions(int id, string word)
    {
        if (!indexes.ContainsKey(id)) return new List<int>(); // Проверка существования документа

        List<int> positions = new();
        string[] words = indexes[id].ToLower()
            .Split(new[] { ' ', '.', ',', '!', '?', ':', '-', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] == word.ToLower())
                positions.Add(i);
        }

        return positions;
    }

    public void Remove(int id)
    {
        indexes.Remove(id);
    }
}
