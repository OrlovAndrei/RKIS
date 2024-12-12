using System;
using System.Collections.Generic;

namespace Autocomplete;

public class RightBorderTask
{
    /// <summary>
    /// Возвращает индекс правой границы.
    /// То есть индекс минимального элемента, который не начинается с prefix и больше prefix.
    /// Если такого нет, то возвращает items.Length.
    /// </summary>
    /// <param name="phrases">Список фраз, отсортированный в порядке StringComparison.InvariantCultureIgnoreCase.</param>
    /// <param name="prefix">Префикс для сравнения.</param>
    /// <param name="left">Левая граница текущего диапазона поиска.</param>
    /// <param name="right">Правая граница текущего диапазона поиска.</param>
    /// <returns>Индекс правой границы или items.Length, если такой нет.</returns>
    public static int GetRightBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
    {
        while (left < right)
        {
            // Находим середину текущего диапазона
            int middle = (left + right) / 2;

            // Сравниваем текущую фразу с префиксом
            if (string.Compare(phrases[middle], prefix, StringComparison.InvariantCultureIgnoreCase) <= 0 &&
                phrases[middle].StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
            {
                // Если фраза больше prefix или начинается с prefix, ищем дальше вправо
                left = middle + 1;
            }
            else
            {
                // Иначе ищем влево
                right = middle;
            }
        }

        return left;
    }
}