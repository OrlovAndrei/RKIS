using System.Linq;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            const int minDay = 2;
            const int maxDay = 31;
            var days = Enumerable.Range(minDay, maxDay - minDay + 1).Select(day => day.ToString()).ToArray();

            const int minMonth = 1;
            const int maxMonth = 12;
            var months = Enumerable.Range(minMonth, maxMonth - minMonth + 1).Select(month => month.ToString()).ToArray();

            var birthCounts = new double[days.Length, months.Length];

            foreach (var name in names)
            {
                if (name.BirthDate.Day >= minDay)
                {
                    birthCounts[name.BirthDate.Day - minDay, name.BirthDate.Month - minMonth]++;
                }
            }

            return new HeatmapData("Карта интенсивностей рождаемости", birthCounts, days, months);
        }
    }
}
