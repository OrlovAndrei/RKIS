using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PocketGoogle
{
    public interface IIndexer
    {
        void Add(int id, string documentText);
        List<int> GetIds(string word);
        List<int> GetPositions(int id, string word);
        void Remove(int id);
    }

    public class Indexer : IIndexer
    {
        private readonly Dictionary<string, Dictionary<int, List<int>>> index = new Dictionary<string, Dictionary<int, List<int>>>();
        private readonly HashSet<int> documentIds = new HashSet<int>();

        public void Add(int id, string documentText)
        {
            if (documentText == null)
                throw new ArgumentNullException(nameof(documentText));
            if (documentIds.Contains(id))
                return; // Игнорируем добавление, если документ уже существует

            documentIds.Add(id);
            var words = Regex.Split(documentText.ToLower(), @"[\s.,!?-:]+");

            for (int position = 0; position < words.Length; position++)
            {
                var word = words[position];
                if (string.IsNullOrEmpty(word)) continue;

                if (!index.ContainsKey(word))
                {
                    index[word] = new Dictionary<int, List<int>>();
                }

                if (!index[word].ContainsKey(id))
                {
                    index[word][id] = new List<int>();
                }

                index[word][id].Add(position);
            }
        }

        public List<int> GetIds(string word)
        {
            word = word.ToLower();
            if (index.ContainsKey(word))
            {
                return index[word].Keys.ToList();
            }

            return new List<int>(); // Возвращаем пустой список, если слово не найдено
        }

        public List<int> GetPositions(int id, string word)
        {
            word = word.ToLower();
            if (index.ContainsKey(word) && index[word].ContainsKey(id))
            {
                return index[word][id];
            }

            return new List<int>(); // Возвращаем пустой список, если документ или слово не найдено
        }

        public void Remove(int id)
        {
            foreach (var word in index.Keys.ToList())
            {
                if (index[word].ContainsKey(id))
                {
                    index[word].Remove(id);
                }

                // Если больше нет документов для слова, удаляем его из индекса
                if (index[word].Count == 0)
                {
                    index.Remove(word);
                }
            }

            documentIds.Remove(id);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Indexer indexer = new Indexer();

            try
            {
                indexer.Add(1, "Hello world! This is a test document.");
                indexer.Add(2, "Hello again, world! Another test.");

                Console.WriteLine("IDs for 'hello': " + string.Join(", ", indexer.GetIds("hello")));
                Console.WriteLine("Positions for 'test' in document 1: " + string.Join(", ", indexer.GetPositions(1, "test")));
                indexer.Remove(1);
                Console.WriteLine("IDs for 'hello' after removal: " + string.Join(", ", indexer.GetIds("hello")));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Argument error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
