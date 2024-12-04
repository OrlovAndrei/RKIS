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
            
            if (array.Length == 0) return -1; //проверка на пустой массив

            var max = double.MinValue;
            var num = 0;
            for (int i = 0; i < array.Length; i++) 
            {
                if (array[i] > max) 
                        max = array[i];         
                        num = i; 
            }
            return num;
        }
    }
}