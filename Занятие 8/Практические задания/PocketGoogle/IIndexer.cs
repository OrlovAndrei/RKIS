using System.Collections.Generic;

namespace PocketGoogle;
{

		public interface IIndexer
	{
		void Add(int id, string documentText);
		List<int> GetIds(string word);
		List<int> GetPositions(int id, string word);
		void Remove(int id);
	}
}