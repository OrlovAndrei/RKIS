namespace Names;

internal static class HeatmapTask
{
    public static HeatmapData GetBirthsPerDateHeatmap(NameData[] nameRecords)
    {
        const int startDay = 2;
        const int endDay = 31;
        var daysArray = Enumerable.Range(startDay, endDay - startDay + 1).Select(day => day.ToString()).ToArray();

        const int startMonth = 1;
        const int endMonth = 12;
        var monthsArray = Enumerable.Range(startMonth, endMonth - startMonth + 1).Select(month => month.ToString()).ToArray();

        var birthCountsMatrix = new double[daysArray.Length, monthsArray.Length];

        foreach (var record in nameRecords)
        {
            if (record.BirthDate.Day >= startDay)
            {
                birthCountsMatrix[record.BirthDate.Day - startDay, record.BirthDate.Month - startMonth]++;
            }
        }

        return new HeatmapData("Карта интенсивностей рождаемости", birthCountsMatrix, daysArray, monthsArray);
    }
}
