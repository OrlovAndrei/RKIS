using System;
namespace Names
{

    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            double[,] intensity = new double[30, 12];

            foreach (var name in names)
            {
                int month = name.BirthDate.Month - 1; 
                int day = name.BirthDate.Day;

                if (day > 1)
                {
                    intensity[day - 2, month]++;
                }
            }

            string[] xLabels = new string[30];
            for (int i = 0; i < xLabels.Length; i++)
            {
                xLabels[i] = (i + 2).ToString(); 
            }

            string[] yLabels = new string[12];
            for (int i = 0; i < yLabels.Length; i++)
            {
                yLabels[i] = (i + 1).ToString(); 
            }

            return new HeatmapData(
                "Тепловая карта рождаемости",
                intensity,
                xLabels,
                yLabels);
        }
    }
}