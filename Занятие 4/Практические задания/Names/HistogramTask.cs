namespace Names;

internal static class HistogramTask
{
    public static HistogramData GetBirthsPerDayHistogram(NameData[] nameRecords, string name)
    {
        const int startingDay = 1;
        int endingDay = nameRecords.Max(nd => nd.BirthDate.Day);

        var daysArray = Enumerable.Range(startingDay, endingDay - startingDay + 1).Select(day => day.ToString()).ToArray();

        var birthCountArray = new double[endingDay - startingDay + 1];

        foreach (var record in nameRecords)
        {
            if (record.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && record.BirthDate.Day > startingDay)
            {
                birthCountArray[record.BirthDate.Day - startingDay]++;
            }
        }

        return new HistogramData(string.Format("Рождаемость людей с именем '{0}'", name), daysArray, birthCountArray);
    }
}
