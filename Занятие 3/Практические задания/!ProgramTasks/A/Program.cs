namespace A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetMinPowerOfTwoLargerThan(2) == 4);
            Console.WriteLine(GetMinPowerOfTwoLargerThan(15) == 16);
            Console.WriteLine(GetMinPowerOfTwoLargerThan(-2) == 1);
            Console.WriteLine(GetMinPowerOfTwoLargerThan(-100) == 1);
            Console.WriteLine(GetMinPowerOfTwoLargerThan(100) == 128);
        }

        private static int GetMinPowerOfTwoLargerThan(int number)
        {
            if (number < 0)
                return 1;
 
            int power = (int)Math.Ceiling(Math.Log(number) / Math.Log(2));
            int tempResult = 1 << power;
            return (tempResult == number) ? tempResult << 1 : tempResult;
        }
    }
}
