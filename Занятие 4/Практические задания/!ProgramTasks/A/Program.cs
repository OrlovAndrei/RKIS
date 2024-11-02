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
            int[] evenNumbers = new int[count];
            for (int i = 0; i < count; i++)
                evenNumbers[i] = 2 * (i + 1);
            return evenNumbers;
        }
    }
}
