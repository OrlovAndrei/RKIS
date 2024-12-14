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
            int[] array = new int[count];

            for (int i = 0; i < count; i++)
            {
                array[i] = (i + 1) * 2;
            }
            return array;
        }

    }
}