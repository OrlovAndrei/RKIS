namespace Names;

internal static class HistogramTask
{
    public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)        
    {
        var numberOfDays = 31;            
        var daysNumbers = new string[numberOfDays];
        for (int i = 0; i < numberOfDays; i++)
            daysNumbers[i] = (i + 1).ToString();
        var birthsCounts = new double[numberOfDays];
        foreach (var person in names)            {
            if (person.Name == name && person.BirthDate.Day != 1)
                birthsCounts[person.BirthDate.Day - 1]++;
        }
        return new HistogramData(string.Format("Рождаемость людей с именем '{0}'", name),
                                 daysNumbers, birthsCounts);
    }    
}
