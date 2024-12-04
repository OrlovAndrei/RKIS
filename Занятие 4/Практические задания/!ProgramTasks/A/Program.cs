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
            var array = new int[count]; //создание массивва

            for (int i = 0; i < count; i++)
                array[i] = (i + 1) * 2; // перебор четных чисел
            return array;
        }

    }
}