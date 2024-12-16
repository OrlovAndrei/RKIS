using System;
using System.Linq;

namespace Names
{
	internal static class HistogramTask
	{

		public static HistogramData GetHistogramBirthsPerDay(NameData[] names, string name)
		{
            var minimunDay = 2;
            var maximumDay = int.MinValue;
            foreach (var day in names)
                maximumDay = Math.Max(maximumDay, day.BirthDate.Day);
            var days = new string[maximumDay - minimumDay + 1];
            for (var i = 0; i < days.Length; i++)
            {
                days[i] = (i + minimumDay).ToString();
            }
            var birthCounts = new double[maximumDay - minimumDay + 1];
            foreach (var day in names)
            {
                if (day.Name == name && day.BirthDate.Day > 1)
                    birthCounts[day.BirthDate.Day - minimumDay]++;
            }

			return new HistogramData(String.Format("Рождаемость людей с именем '{0}'", name), days, birthCounts);
		}
	}
}