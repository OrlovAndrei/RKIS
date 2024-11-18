public static int GetElementCount(int[] items, int itemToCount)
        {
            int count = 0;
            foreach (var item in items)
            {
                if (item == itemToCount) count++;
            }
            return count;
        }
    }
}
