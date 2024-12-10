using System.ComponentModel.Design;

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
            double maxindex = double.MinValue;
            int index = -1;
            {
                for (var i = 0; i < array.Length; i++)
                {
                    if (array[i] > maxindex) 
                    {
                        maxindex = array[i];
                        index = i;
                    }
                }
                return index;
            }

        }

    }
}