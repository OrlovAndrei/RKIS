using System;
using System.Linq;

namespace Names;

internal static class HistogramTask
{
    public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
    {
        var labels = Enumerable.Range(1, 31).Select(day => day.ToString()).ToArray();

        var birthsCounts = new double[31];

        foreach (var person in names)
        {
            if (person.Name == name && person.BirthDate.Day != 1)
            {
                birthsCounts[person.BirthDate.Day - 1]++;
            }
        }

        return new HistogramData($"Рождаемость людей с именем '{name}'", labels, birthsCounts);
    }
}