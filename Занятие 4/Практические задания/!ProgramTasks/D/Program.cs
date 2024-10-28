using System;
}
        public static int FindSubarrayStartIndex(int[] array, int[] subArray)
        public static bool ContainsAtIndex(int[] array, int[] subArray, int index)
        {
            for (var i = 0; i < array.Length - subArray.Length + 1; i++)
                if (ContainsAtIndex(array, subArray, i))
                    return i;
            return -1;
            foreach (int element in subArray)
                if (array[index] != element) return false;
                else index++;
            return true;
        }
    }
}
