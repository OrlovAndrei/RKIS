using System;

namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindSubarrayStartIndex(new[] { 1, 2, 4, 1, 2 }, new[] { 1, 2 }));
        }

        public static bool ContainsAtIndex(int[] array, int[] subArray, int index)
        {
            foreach (int element in subArray)
                if (array[index] != element) return false;
                else index++;
            return true;
        }
    }
}