using System;
using System.Collections.Generic;
using System.Linq;

namespace Autocomplete;

 public class RightBorderTask
    {
        /// <returns>
        /// Возвращает индекс правой границы.
        /// То есть индекс минимального элемента, который не начинается с prefix и большего prefix.
        /// Если такого нет, то возвращает items.Length
        /// </returns>
        /// <remarks>
        /// Функция должна быть НЕ рекурсивной
        /// и работать за O(log(items.Length)*L), где L — ограничение сверху на длину фразы
        /// </remarks>
        public static int GetRightBorderIndex(IReadOnlyList<string> phrases, string prefix, int left, int right)
        {
            int result = phrases.Count; // Инициализируем результат значением phrases.Count (не найдено)

            while (left <= right)
            {
                int mid = left + ((right - left) >> 1); // Более эффективное вычисление середины

                int comparison = string.Compare(prefix, phrases[mid], StringComparison.InvariantCultureIgnoreCase);

                if (comparison <= 0 && !phrases[mid].StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
                {
                    // prefix <= phrases[mid] && !phrases[mid].StartsWith(prefix) => Правая граница находится левее
                    result = mid;
                    right = mid - 1;

                }
                else if (comparison > 0 || phrases[mid].StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase))
                {
                    // prefix > phrases[mid] || phrases[mid].StartsWith(prefix) => Правая граница находится правее
                    left = mid + 1;
                } else {
                    left = mid + 1;
                }
            }

            return result;
        }
    }
}
