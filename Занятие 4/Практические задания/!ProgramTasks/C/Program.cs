namespace C
 {
        static void Main(string[] args)
        {
            Console.WriteLine(GetElementCount(new[] {1, 1, 2, 1}, 1));
            Console.WriteLine(GetElementCount(new[] { 1, 1, 2, 1 }, 1));
        }

        public static int GetElementCount(int[] items, int itemToCount)
        {
            ...
            int count = 0;
            foreach (var e in items)
                if (e == itemToFind) count++;
            return count;
        }
    }
}
