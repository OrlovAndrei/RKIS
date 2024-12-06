using System;

namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindSubarrayStartIndex(new[] { 1, 2, 4, 1, 2 }, new[] { 1, 2 }));
        }

        static bool ContainsAtIndex(int[] array, int[] subArray, int index)
    {
        for (int j = 0; j < subArray.Length; j++)
        {
            if (array[index + j] != subArray[j])
            {
                return false;
            }
        }
        return true;
    }

    public static int FindSubarrayStartIndex(int[] array, int[] subArray)
    {
        if (subArray.Length == 0)
        {
            return 0;
        }

        for (int i = 0; i <= array.Length - subArray.Length; i++)
        {
            if (ContainsAtIndex(array, subArray, i))
            {
                return i;
            }
        }
        return -1;
    }
    }
}
