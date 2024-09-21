namespace C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pi = Math.PI;
            int tenThousand = 10000L;
            float tenThousandPi = pi * tenThousand;
            int roundedTenThousandPi = tenThousandPi;
            int integerPartOfTenThousandPi = tenThousandPi;
            Console.WriteLine(integerPartOfTenThousandPi);
            Console.WriteLine(roundedTenThousandPi);
        }
    }
}