using System;

namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindSubarrayStartIndex(new[] { 1, 2, 4, 1, 2 }, new[] { 1, 2 }));
        }

        public static int FindSubarrayStartIndex(int[] array, int[] subArray)
        {
            for (var i = 0; i < array.Length - subArray.Length + 1; i++)
                if (ContainsAtIndex(array, subArray, i) == true)
                    return i;
            return -1;


        }

        private static bool ContainsAtIndex(int[] array, int[] subArray, int index)
        {
            foreach (var item in subArray)
            {
                if (array[index] != item) return false;
                else index++;
            }
            return true;
        }
    }
}