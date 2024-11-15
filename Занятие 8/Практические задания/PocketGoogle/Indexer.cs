using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketGoogle;

public class Indexer : IIndexer
{
	public void Add(int id, string documentText)
	{
		throw new NotImplementedException();
	}

	public List<int> GetIds(string word)
	{
		throw new NotImplementedException();
	}

	public List<int> GetPositions(int id, string word)
	{
		throw new NotImplementedException();
	}

	public void Remove(int id)
	{
		throw new NotImplementedException();
	}
}