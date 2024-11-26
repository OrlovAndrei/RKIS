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
                if (string.IsNullOrWhiteSpace(word)) continue;

                if (!index.TryGetValue(word, out var docList))
                {
                    docList = new Dictionary<int, List<int>>();
                    index[word] = docList;
                }

                if (!docList.TryGetValue(id, out var positions))
                {
                    positions = new List<int>();
                    docList[id] = positions;
                }

                positions.Add(position);
            }
        }

        public List<int> GetIds(string word)
        {
            word = word.ToLower();
            if (index.TryGetValue(word, out var docList))
            {
                return docList.Keys.ToList();
            }
            return new List<int>(); // Возвращаем пустой список, если слово не найдено
        }

        public List<int> GetPositions(int id, string word)
        {
            word = word.ToLower();
            if (index.TryGetValue(word, out var docList) && docList.TryGetValue(id, out var positions))
            {
                return positions;
            }
            return new List<int>(); // Возвращаем пустой список, если документ или слово не найдено
        }

        public void Remove(int id)
        {
            foreach (var word in index.Keys.ToList())
            {
                if (index[word].Remove(id) && index[word].Count == 0)
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
            var indexer = new Indexer();

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
