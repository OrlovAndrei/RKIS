using System;
using System.Collections.Generic;

namespace Autocomplete;

public class LeftBorderTask
{
    /// <summary>
    /// Возвращает индекс левой границы.
    /// То есть индекс максимальной фразы, которая не начинается с prefix и меньше prefix.
    /// Если такой нет, то возвращает -1.
    /// Функция реализована рекурсивно.
    /// </summary>
    /// <param name="phrases">Список фраз, отсортированный в порядке StringComparison.InvariantCultureIgnoreCase.</param>
    /// <param name="prefix">Префикс для сравнения.</param>
    /// <param name="left">Левая граница текущего диапазона поиска.</param>
    /// <param name="right">Правая граница текущего диапазона поиска.</param>
    /// <returns>Индекс левой границы или -1, если такой нет.</returns>
    public static int GetLeftBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
    {
        // Базовый случай: если диапазон пустой, возвращаем левую границу
        if (left >= right)
            return left - 1;

        // Середина диапазона
        int middle = (left + right) / 2;

        // Сравниваем текущую фразу с префиксом
        if (string.Compare(phrases[middle], prefix, StringComparison.InvariantCultureIgnoreCase) < 0)
        {
            // Ищем дальше вправо
            return GetLeftBorderIndex(phrases, prefix, middle + 1, right);
        }
        else
        {
            // Ищем дальше влево
            return GetLeftBorderIndex(phrases, prefix, left, middle);
        }
    }
}