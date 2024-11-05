namespace Names;

internal static class HeatmapTask
{
    public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
    {
        var daysInMonth = 30; // от 2 до 31
        var monthsInYear = 12; // от 1 до 12
        var heatmapCounts = new double[daysInMonth, monthsInYear];
        foreach (var person in names)
        {
            if (person.BirthDate.Day != 1)
            {
                int dayIndex = person.BirthDate.Day - 2; // от 2 до 31 
                int monthIndex = person.BirthDate.Month - 1; // от 1 до 12
                heatmapCounts[dayIndex, monthIndex]++;
            }
        }
        var daysLabels = new string[daysInMonth];
        for (int i = 0; i < daysInMonth; i++)
            daysLabels[i] = (i + 2).ToString(); // от 2 до 31 
        var monthsLabels = new string[monthsInYear];
        for (int i = 0; i < monthsInYear; i++)
            monthsLabels[i] = (i + 1).ToString(); // от 1 до 12
        return new HeatmapData("Тепловая карта рождаемости",
                               heatmapCounts, daysLabels, monthsLabels);
    }
}
