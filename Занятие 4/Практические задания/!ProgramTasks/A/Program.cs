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
            var array = new int[count];
            for (int i = 0; i < array.Length; i++)
                array[i] = 2 * i + 2;
        }

    }
}