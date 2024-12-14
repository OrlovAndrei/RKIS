using System;
namespace B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxIndex(new[] {1.0, .2, 100, 2e+10}));
        }

        static double Min(double[] array)
        {
            var min = double.MaxValue;
            foreach (var item in array)
                if (item < min) min = item;
            return min;
        }

        public static int MaxIndex(double[] array)
        {
            if (array.Length == 0) return -1;

            int maxIndex = 0;
            double maxValue = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
    }
}
