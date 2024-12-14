using System;

namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindSubarrayStartIndex(new[] { 1, 2, 4, 1, 2 }, new[] { 1, 2 }));
        }
        public static bool ContainsAtIndex(int[] array, int[] subArray, int startIndex)
        {

            for (var j = 0; j < subArray.Length; j++)
            {
                if (array[startIndex + j] != subArray[j])
                    return false;
            }
            return true;
        }
        public static int FindSubarrayStartIndex(int[] array, int[] subArray)
        {
            for (var i = 0; i < array.Length - subArray.Length + 1; i++)
                if (ContainsAtIndex(array, subArray, i))
                    return i;
            return -1;
        }
    }
}
