using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            const int minDay = 1;
            int maxDay = names.Max(nd => nd.BirthDate.Day);

            var days = Enumerable.Range(minDay, maxDay - minDay + 1).Select(day => day.ToString()).ToArray();

            var birthCounts = new double[maxDay - minDay + 1];

            foreach (var day in names)
            {
                if (day.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && day.BirthDate.Day > minDay)
                {
                    birthCounts[day.BirthDate.Day - minDay]++;
                }
            }

            return new HistogramData(string.Format("Рождаемость людей с именем '{0}'", name), days, birthCounts);
        }
    }
}
