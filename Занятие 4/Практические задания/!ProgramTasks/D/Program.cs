using System;

namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindSubarrayStartIndex(new[] { 1, 2, 4, 1, 2 }, new[] { 1, 2 }));
            Console.WriteLine(FindSubarrayStartIndex(new[] { 1, 2, 3, 4, 3, 4 }, new[] { 3, 4 }));
            Console.WriteLine(FindSubarrayStartIndex(new[] { 1, 2, 3 }, new int[] { }));
            Console.WriteLine(FindSubarrayStartIndex(new[] { 1, 2, 3 }, new[] { 4 }));
        }

        public static int FindSubarrayStartIndex(int[] array, int[] subArray)
        {
            if (subArray.Length == 0)
                return 0;

            for (var i = 0; i <= array.Length - subArray.Length; i++)
                if (ContainsAtIndex(array, subArray, i))
                    return i;
            return -1;
        }

        public static bool ContainsAtIndex(int[] array, int[] subArray, int startIndex)
        {
            for (int i = 0; i < subArray.Length; i++)
            {
                if (array[startIndex + i] != subArray[i])
                    return false;
            }
            return true;
        }
    }
}