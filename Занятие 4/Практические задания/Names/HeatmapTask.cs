namespace Names;

internal static class HeatmapTask
{
    public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
    {
        int i = 2;
        string[] days = new string[30];
        string[] months = new string[12];
        while (i <= 31)
        {
            days[i - 2] = i.ToString();
            i++;
        }
        i = 1;
        while (i <= 12)
        {
            months[i - 1] = i.ToString();
            i++;
        }
        double[,] heat = new double[30, 12];
        i = 0;
        while (i < 30)
        {
            double[] c = new double[12];
            foreach (var name in names)
                if (name.BirthDate.Day == i + 2)
                    c[name.BirthDate.Month - 1] = c[name.BirthDate.Month - 1] + 1;
            int j = 0;
            while (j < 12)
            {
                heat[i, j] = c[j];
                j++;
            }
            i++;
        }
        return new HeatmapData("Пример карты интенсивностей", heat, days, months);
    }
}
