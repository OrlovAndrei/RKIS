namespace C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pi = Math.PI;
            long tenThousand = 10000L;
            float tenThousandPi = (float)pi * tenThousand;
            int roundedTenThousandPi = Math.Round(tenThousandPi);
            int integerPartOfTenThousandPi = (int)Math.Floor(tenThousandPi);
            Console.WriteLine(integerPartOfTenThousandPi);
            Console.WriteLine(roundedTenThousandPi);
        }
    }
}
