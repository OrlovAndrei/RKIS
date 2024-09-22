namespace Names;

internal static class HeatmapTask
{
    public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
    {
        return new HeatmapData(
            "Пример карты интенсивностей",
            new double[,] { { 1, 2, 3 }, { 2, 3, 4 }, { 3, 4, 4 }, { 4, 4, 4 } }, 
            new[] { "a", "b", "c", "d" }, 
            new[] { "X", "Y", "Z" });
    }
}