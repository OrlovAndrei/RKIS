using System;
using System.Linq;

namespace Names;

internal static class HeatmapTask
{
    public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
    {
        var xLabels = Enumerable.Range(2, 30).Select(day => day.ToString()).ToArray();
        var yLabels = Enumerable.Range(1, 12).Select(month => month.ToString()).ToArray();

        var birthsCounts = new double[30, 12];

        foreach (var person in names)
        {
            if (person.BirthDate.Day == 1)
                continue;

            int dayIndex = person.BirthDate.Day - 2;
            int monthIndex = person.BirthDate.Month - 1;

            birthsCounts[dayIndex, monthIndex]++;
        }

        return new HeatmapData(
            "Карта интенсивностей рождаемости",
            birthsCounts,
            xLabels,
            yLabels);
    }
}