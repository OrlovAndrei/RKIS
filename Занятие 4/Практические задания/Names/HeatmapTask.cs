using System;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            const int minimumDay = 2;
            const int maximumDay = 31;
            const int minimumMonth = 1;
            const int maximumMonth = 12;

            // Подготовка подписей по оси X (дни месяца от 2 до 31)
            var days = new string[maximumDay - minimumDay + 1];
            for (var i = 0; i < days.Length; i++)
            {
                days[i] = (i + minimumDay).ToString();
            }

            // Подготовка подписей по оси Y (месяцы от 1 до 12)
            var months = new string[maximumMonth];
            for (var i = 0; i < months.Length; i++)
            {
                months[i] = (i + minimumMonth).ToString();
            }

            // Инициализация двумерного массива для подсчета рождения в зависимости от дня и месяца
            var birthCounts = new double[days.Length, months.Length];

            // Подсчет количества рождений
            foreach (var name in names)
            {
                // Учитываются только дни, начиная с 2-го
                if (name.BirthDate.Day >= minimumDay)
                {
                    birthCounts[name.BirthDate.Day - minimumDay, name.BirthDate.Month - minimumMonth]++;
                }
            }

            return new HeatmapData("Карта интенсивностей рождаемости", birthCounts, days, months);
        }
    }
}
