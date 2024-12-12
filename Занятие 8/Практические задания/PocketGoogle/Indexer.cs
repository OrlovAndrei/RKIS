using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle
{
    public class Indexer : IIndexer
    {
        // Словарь, где ключ — id документа, а значение — текст документа
        private readonly Dictionary<int, string> documents = new Dictionary<int, string>();

        // Словарь, где ключ — слово, а значение — словарь (id документа -> список позиций слова)
        private readonly Dictionary<string, Dictionary<int, List<int>>> index = new Dictionary<string, Dictionary<int, List<int>>>();

        // Разделители слов
        private readonly char[] delimiters = { ' ', '.', ',', '!', '?', ':', '-', '\r', '\n' };

        public void Add(int id, string documentText)
        {
            // Удаляем предыдущий текст документа (если он есть)
            if (documents.ContainsKey(id))
                Remove(id);

            // Сохраняем документ в словарь
            documents[id] = documentText;

            // Разбиваем текст на слова
            var words = documentText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (int position = 0; position < words.Length; position++)
            {
                string word = words[position].ToLower(); // Приводим слова к нижнему регистру

                // Если слово еще не в индексе, добавляем его
                if (!index.ContainsKey(word))
                    index[word] = new Dictionary<int, List<int>>();

                // Если id документа еще не добавлен для этого слова, добавляем
                if (!index[word].ContainsKey(id))
                    index[word][id] = new List<int>();

                // Добавляем позицию слова в документе
                index[word][id].Add(position);
            }
        }

        public List<int> GetIds(string word)
        {
            word = word.ToLower();
            // Возвращаем список id документов, где встречается слово, или пустой список
            return index.ContainsKey(word) ? index[word].Keys.ToList() : new List<int>();
        }

        public List<int> GetPositions(int id, string word)
        {
            word = word.ToLower();
            // Возвращаем список позиций слова в документе с указанным id, или пустой список
            return index.ContainsKey(word) && index[word].ContainsKey(id) ? index[word][id] : new List<int>();
        }

        public void Remove(int id)
        {
            // Удаляем документ из словаря документов
            if (documents.ContainsKey(id))
                documents.Remove(id);

            // Удаляем все упоминания id из индекса
            foreach (var word in index.Keys.ToList())
            {
                if (index[word].ContainsKey(id))
                    index[word].Remove(id);

                // Если для слова больше нет документов, удаляем слово из индекса
                if (index[word].Count == 0)
                    index.Remove(word);
            }
        }
    }
}