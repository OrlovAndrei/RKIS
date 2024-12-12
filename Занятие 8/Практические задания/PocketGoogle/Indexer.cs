using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle;

public class Indexer : IIndexer
{
    public class Indexer : IIndexer
    {
        // Хранение индекса
        private readonly Dictionary<string, Dictionary<int, List<int>>> _index = new();

        // Метод для добавления документа и индексации его слов
        public void Add(int id, string documentText)
        {
            // Разделение документа на слова с использованием регулярного выражения
            string[] words = Regex.Split(documentText, @"[ ,.!?:\r\n-]+");
            
            for (int position = 0; position < words.Length; position++)
            {
                string word = words[position].ToLower(); // Приводим к нижнему регистру

                if (string.IsNullOrWhiteSpace(word)) continue; // Игнорировать пустые слова

                // Если слово еще не индексируется, инициализируем его запись
                if (!_index.ContainsKey(word))
                {
                    _index[word] = new Dictionary<int, List<int>>();
                }

                // Если документ с данным id еще не добавлен для этого слова, инициализируем его запись
                if (!_index[word].ContainsKey(id))
                {
                    _index[word][id] = new List<int>();
                }

                // Добавляем позицию слова в документ
                _index[word][id].Add(position);
            }
        }

        // Метод для получения id документов, содержащих данное слово
        public List<int> GetIds(string word)
        {
            word = word.ToLower(); // Приводим к нижнему регистру
            return _index.ContainsKey(word) ? new List<int>(_index[word].Keys) : new List<int>();
        }

        // Метод для получения позиций слова в документе по id
        public List<int> GetPositions(int id, string word)
        {
            word = word.ToLower(); // Приводим к нижнему регистру
            return _index.ContainsKey(word) && _index[word].ContainsKey(id) ? new List<int>(_index[word][id]) : new List<int>();
        }

        // Метод для удаления документа из индекса
        public void Remove(int id)
        {
            foreach (var word in _index.Keys)
            {
                if (_index[word].ContainsKey(id))
                {
                    _index[word].Remove(id); // Удаляем документ по id
                }
            }
        }
    }
}
