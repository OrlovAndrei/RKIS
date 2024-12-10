namespace C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetElementCount(new[] {1, 1, 2, 1}, 2));
        }

        public static int GetElementCount(int[] items, int itemToCount)
        {
            var count = items.Count(num => num == itemToCount);
            return count;
        }
    }
}