using System

namespace Names;
internal static class HistogramTask
{
    public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
    {
                var days = new string[31];
        int g = 1;
        for (int i = 0; i < days.Length; i++)
        {
            string f = Convert.ToString(g);
            days[i] = "" + f;
            g++;
        }
        var birthsCounts = new double[31];
        foreach (var man in names)
        {
            if (man.Name == name && man.BirthDate.Day != 1)
                birthsCounts[man.BirthDate.Day - 1]++;
        }
        return new HistogramData(
            $"Рождаемость людей с именем '{name}'", 
            new [] {"1"}, 
            new[] {0d});
    }
}