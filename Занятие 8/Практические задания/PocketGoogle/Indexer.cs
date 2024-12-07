using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle;

public class Indexer : IIndexer
{
	public void Add(int id, string documentText)
	if (document == null)
            throw new ArgumentNullException(nameof(document));

        // Разделители слов
        char[] delimiters = { ' ', '.', ',', '!', '?', ':', '-', '\r', '\n' };

        // Разбиваем текст документа на слова с учетом позиций
        string[] words = document.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0, position = 0; i < words.Length; i++, position += words[i].Length + 1)
        {
            string word = words[i].ToLower();

            if (!_index.ContainsKey(word))
                _index[word] = new Dictionary<int, List<int>>();

            if (!_index[word].ContainsKey(documentId))
                _index[word][documentId] = new List<int>();

            _index[word][documentId].Add(position);
        }
    }

	public List<int> GetIds(string word)
	{
        word = word?.ToLower();
        if (string.IsNullOrEmpty(word) || !_index.ContainsKey(word))
            return new List<int>();

        return _index[word].Keys.ToList();
    }

	public List<int> GetPositions(int id, string word)
	 {
        word = word?.ToLower();
        if (string.IsNullOrEmpty(word) || !_index.ContainsKey(word) || !_index[word].ContainsKey(documentId))
            return new List<int>();

        return _index[word][documentId];
    }

	public void Remove(int id)
	{
        foreach (var word in _index.Keys.ToList())
        {
            _index[word].Remove(documentId);

            // Удаляем слово, если больше нет ссылок на документы
            if (_index[word].Count == 0)
                _index.Remove(word);
        }
    }
}