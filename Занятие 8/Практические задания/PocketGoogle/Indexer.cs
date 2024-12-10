using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle
{
public class Indexer : IIndexer
{
        private readonly Dictionary<string, Dictionary<int, List<int>>> index = new();

        public void Add(int id, string documentText)
        {
            var words = documentText.ToLower().Split(new[] { ' ', '.', ',', '!', '?', ':', '-', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                if (!index.ContainsKey(word))
                {
                    index[word] = new Dictionary<int, List<int>>();
                }

                if (!index[word].ContainsKey(id))
                {
                    index[word][id] = new List<int>();
                }

                index[word][id].Add(Array.IndexOf(words, word));
            }
        }

        public List<int> GetIds(string word)
        {
            word = word.ToLower();
            return index.ContainsKey(word) ? index[word].Keys.ToList() : new List<int>();
        }

        public List<int> GetPositions(int id, string word)
        {
            word = word.ToLower();
            if (index.ContainsKey(word) && index[word].ContainsKey(id))
            {
                return index[word][id];
            }
            return new List<int>();
        }

        public void Remove(int id)
        {
            foreach (var kvp in index.ToList())
            {
                if (kvp.Value.ContainsKey(id))
                {
                    kvp.Value.Remove(id);
                }
            }
        }
}