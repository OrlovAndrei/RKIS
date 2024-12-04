namespace Names;

internal static class HistogramTask
{
    public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
    {
        var amountDays = 31;
        var daysNumbers = new string[amountDays];
        for (int i = 0; i < amountDays; i++)
            daysNumbers[i] = (i + 1).ToString();

        var birthsCounts = new double[amountDays];
        foreach (var character in names)
        {
            if (character.Name == name && character.BirthDate.Day != 1)
                birthsCounts[character.BirthDate.Day - 1]++;
        }

        return new HistogramData(string.Format("Рождаемость людей с именем '{0}'", name),
            daysNumbers, birthsCounts);
    }
}