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

//В этом проекте вы создадите структуру данных индекса,
//который используется для быстрого поиска слов в документах.

//В файле Indexer.cs реализуйте предложенные методы

//- Add.Этот метод должен индексировать все слова в документе.
//  Разделители слов: { ' ', '.', ',', '!', '?', ':', '-','\r','\n' };

//- GetIds.Этот метод должен искать по слову все id документов, где оно встречается.

//- GetPositions.Этот метод по слову и id документа должен искать все позиции, 
//  в которых слово начинается.

//- Remove.Этот метод должен удалять документ из индекса,
//  после чего слова в нем искаться больше не должны.