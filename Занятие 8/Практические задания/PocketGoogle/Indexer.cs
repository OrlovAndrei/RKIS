using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle;

public class Indexer : IIndexer
{
	private Dictionary<int, string> indexes = new();
	public void Add(int id, string documentText)
	{
		indexes[id] = documentText;
	}

	public List<int> GetIds(string word)
	{
		List<int> ids = new();
		foreach (int id in indexes.Keys) 
		{
			foreach (string w in indexes[id].Split(new char[] { ' ', '.', ',', '!', '?', ':', '-', '\r', '\n' }).ToList())
			{
				if (w == word) 
				{
					ids.Add(id);
					break;
				}
			}
		}
		return ids;
	}

	public List<int> GetPositions(int id, string word)
	{
		List<int> positions = new();
		positions.Add(indexes[id].IndexOf(word));
		return positions;
	}

	public void Remove(int id)
	{
		indexes.Remove(id);
	}
}