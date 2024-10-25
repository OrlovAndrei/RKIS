namespace C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetElementCount(new[] { 1, 1, 2, 1 }, 1));
        }

        public static int GetElementCount(int[] items, int itemToCount)
        {
            var count = 0;

            foreach (var i in items)
            {
                if (i == itemToCount)
                {
                    count++;
                }
            }
            return count;
        }
    }
}