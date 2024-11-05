using System;
using System.Reflection.Emit;

namespace Names;

internal static class HistogramTask
{
    public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
    {
        var minDay = 2;
        var maxDay = 31;
        foreach (var day in names)
        {
            minDay = Math.Min(minDay, day.BirthDate.Day);
            maxDay = Math.Max(maxDay, day.BirthDate.Day);
        }

        var days = new string[maxDay - minDay + 1];

        for (var y = 0; y < days.Length; y++)
            days[y] = (y + minDay).ToString();

        var birthsCounts = new double[maxDay - minDay + 1];

        foreach (var day in names)
        {
            if (day.Name == name && day.BirthDate.Day > 1)
                birthsCounts[day.BirthDate.Day - minDay]++;
        }
        return new HistogramData(String.Format("Рождаемость людей с именем '{0}'", name), days, birthsCounts);
    }
}
