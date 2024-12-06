namespace A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (var num in GetFirstEvenNumbers(100))
                Console.WriteLine(num);
        }

        static int[] GetFirstEvenNumbers(int count)
    {
        int[] numbers = new int[count];
        for (int i = 0; i < count; i++)
        {
            numbers[i] = (i + 1) * 2;
        }
        return numbers;
    }

    }
}
