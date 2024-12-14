namespace A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (var num in GetFirstEvenNumbers(100))
                Console.WriteLine(num);
        }

        public static int[] GetFirstEvenNumbers(int count)
        {
            int[] nums = new int[count];
            for (int i = 0; i < count; i++)
            {
                nums[i] = (i + 1) * 2;
            }
            return nums;
        }

    }
}