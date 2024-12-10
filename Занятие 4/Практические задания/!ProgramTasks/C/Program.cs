namespace C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetElementCount(new[] {1, 1, 2, 1}, 1));
        }

        public static int GetElementCount(int[] items, int itemToCount)
        {
            return items.Count(x => x == itemToCount);
        }
    }
}