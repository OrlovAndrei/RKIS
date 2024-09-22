namespace Names;

internal static class HistogramTask
{
    public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
    {
        return new HistogramData(
            $"Рождаемость людей с именем '{name}'", 
            new [] {"1"}, 
            new[] {0d});
    }
}