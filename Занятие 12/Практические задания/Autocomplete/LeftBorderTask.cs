using System;
using System.Collections.Generic;
using System.Linq;

master
namespace Autocomplete
{
    public class LeftBorderTask
    {
        public static int GetLeftBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            if (right - left <= 1) return left;
            var middle = left + (right - left) / 2;
            return (string.Compare(prefix, phrases[middle], StringComparison.OrdinalIgnoreCase) > 0) ?
                GetLeftBorderIndex(phrases, prefix, middle, right) :
                GetLeftBorderIndex(phrases, prefix, left, middle);
        }
    }
}

namespace Autocomplete;

// Внимание!
// Есть одна распространенная ловушка при сравнении строк: строки можно сравнивать по-разному:
// с учетом регистра, без учета, зависеть от кодировки и т.п.
// В файле словаря все слова отсортированы методом StringComparison.InvariantCultureIgnoreCase.
// Во всех функциях сравнения строк в C# можно передать способ сравнения.
public class LeftBorderTask
{
	/// <returns>
	/// Возвращает индекс левой границы.
	/// То есть индекс максимальной фразы, которая не начинается с prefix и меньшая prefix.
	/// Если такой нет, то возвращает -1
	/// </returns>
	/// <remarks>
	/// Функция должна быть рекурсивной
	/// и работать за O(log(items.Length)*L), где L — ограничение сверху на длину фразы
	/// </remarks>
	public static int GetLeftBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
	{
		// IReadOnlyList похож на List, но у него нет методов модификации списка.
		// Этот код решает задачу, но слишком неэффективно. Замените его на бинарный поиск!
		for (int i = 0; i < phrases.Count; i++)
		{
			if (string.Compare(prefix, phrases[i], StringComparison.InvariantCultureIgnoreCase) < 0
			    || phrases[i].StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
				return i - 1;
		}
		return phrases.Count-1;
	}
}
master
