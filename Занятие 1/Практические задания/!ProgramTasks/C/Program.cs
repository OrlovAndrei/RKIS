namespace C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pi = Math.PI;
            long tenThousand = 10000L;
            double tenThousandPi = pi * tenThousand;
            double roundedTenThousandPi = tenThousandPi;
            int integerPartOfTenThousandPi = tenThousandPi;
            Console.WriteLine(integerPartOfTenThousandPi);
            Console.WriteLine(roundedTenThousandPi);
        }
    }
}