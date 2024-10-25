using System;

namespace Names
{
    internal static class HeatmapTask
    {

        public static HeatmapData GetHistogramBirthsPerDate(NameData[] names)
        {
            var minimumDay = 2;
            var maximumDay = 31;
            var days = new string[maximumDay - minimumDay + 1];
            for (var i = 0; i < days.Length; i++)
                days[i] = (i + minimumDay).ToString();

            var minimumMonth = 1;
            var maximumMonth = 12;
            var months = new string[maximumMonth];
            for (var i = 0; i < months.Length; i++)
                months[i] = (i + minimumMonth).ToString();
            var birthCounts = new double[days.Length, months.Length];
            foreach (var name in names)
            {
                if (name.BirthDate.Day > 1)
                    birthCounts[(name.BirthDate.Day - minimumDay), (name.BirthDate.Month - minimumMonth)]++;
            }
            return new HeatmapData("Карта интенсивностей рождаемости", birthCounts, days, months);
        }
    }
}