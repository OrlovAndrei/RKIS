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
            var max = double.MinValue;
            foreach (var item in array)
                if (item > max) max = item;

            int index = -1;
            if (array.Length == 0)
                return index;

            index = Array.IndexOf(array, max);
            return index;
        }
    }
}