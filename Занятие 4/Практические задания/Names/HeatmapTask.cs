using System;
 
namespace Names
{
    internal static class HeatmapTask
    {
        public static string[] NomerDayGet(NameData[] names)
        {
            var nomerDayArr = new string[30];
            for (int i = 0; i<30; i++)
                nomerDayArr[i] = (i+2).ToString();
            return nomerDayArr;
        }
        
        public static string[] NomerMounthGet(NameData[] names)
        {
            var nomerMounthArr = new string[12];
            for (int i = 0; i<12; i++)
                {nomerMounthArr[i] = (i+1).ToString();}        
            return nomerMounthArr;
        }
        
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            string[] mounth = NomerMounthGet(names);
            string[] day = NomerDayGet(names);
            double[,] mounthDay  = new double[30, 12];
            foreach (var mname in names)
                if (mname.BirthDate.Day !=1)
                    mounthDay[mname.BirthDate.Day-2, mname.BirthDate.Month-1]++;
            return new HeatmapData("Пример карты интенсивностей", mounthDay, day, mounth);
        }
    }
}
