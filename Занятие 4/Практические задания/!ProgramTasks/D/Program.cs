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