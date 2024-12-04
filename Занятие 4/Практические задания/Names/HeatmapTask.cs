using System.Xml.Linq;
using System;

namespace Names;

internal static class HeatmapTask
{
    public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
    {
        var minDay = 2;
        var maxDay = 31;
        var minMonth = 1;
        var maxMonth = 12;

        var days = new string[maxDay - minDay + 1];
        for (var x = 0; x < days.Length; x++)
            days[x] = (x + minDay).ToString();
        var months = new string[maxMonth - minMonth + 1];
        for (var y = 0; y < months.Length; y++)
            months[y] = (y + minMonth).ToString();
        var birthsCounts = new double[days.Length, months.Length];
        foreach (var name in names)
            if (name.BirthDate.Day >= minDay)
                birthsCounts[name.BirthDate.Day - minDay, name.BirthDate.Month - minMonth]++;

        return new HeatmapData(
            "Пример карты интенсивностей",
            birthsCounts,
            days,
            months);
    }
}