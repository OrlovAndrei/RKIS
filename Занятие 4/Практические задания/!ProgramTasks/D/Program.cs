using System;

namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindSubarrayStartIndex(new[] { 1, 2, 4, 1, 2 }, new[] { 1, 2 }));
            Console.WriteLine(FindSubarrayStartIndex(new[] { 1, 2, 3, 4, 3, 4 }, new[] { 3, 4 }));  
            Console.WriteLine(FindSubarrayStartIndex(new[] { 1, 2, 3 }, new[] { 4 }));  
            Console.WriteLine(FindSubarrayStartIndex(new[] { 1, 2, 3 }, new int[0]));
        }

        public static int FindSubarrayStartIndex(int[] array, int[] subArray)
        {
            for (var i = 0; i <= array.Length - subArray.Length; i++)
            {
                if (ContainsAtIndex(array, subArray, i))
                    return i;
            }
            return -1;
        }
        public static bool ContainsAtIndex(int[] array, int[] subArray, int startindex)
        {
            if (subArray.Length == 0)
                return true;

            for (int j = 0; j < subArray.Length; j++)
            {
                
                    if (array[startindex + j] != subArray[j])
                    return false;  
                
            }
            return true;  
        }
    }
}