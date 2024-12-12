using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete
{
    public class LeftBorderTask
    {
        /// <returns>
        /// Возвращает индекс левой границы.
        /// То есть индекс максимальной фразы, которая не начинается с prefix и меньшая prefix.
        /// Если такой нет, то возвращает -1
        /// </returns>
        /// <remarks>
        /// Функция должна быть итеративной
        /// и работать за O(log(items.Length)*L), где L — ограничение сверху на длину фразы
        /// </remarks>
        public static int GetLeftBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            int result = -1; // Инициализируем результат значением -1 (не найдено)

            while (left <= right)
            {
                int mid = left + ((right - left) >> 1); // Более эффективное вычисление середины

                int comparison = string.Compare(prefix, phrases[mid], StringComparison.InvariantCultureIgnoreCase);

                if (comparison < 0)
                {
                    // prefix < phrases[mid] => Левая граница находится левее
                    right = mid - 1;
                    result = right; // Обновляем потенциальную левую границу
                }
                else if (comparison == 0 || phrases[mid].StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
                {
                    // prefix == phrases[mid] || phrases[mid].StartsWith(prefix) => Левая граница находится правее
                    left = mid + 1;
                }
                else
                {
                    // prefix > phrases[mid] && !phrases[mid].StartsWith(prefix) => phrases[mid] - потенциальная левая граница
                    result = mid;
                    left = mid + 1;
                }
            }

            return result;
        }
    }
}
