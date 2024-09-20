namespace C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pi = Math.PI;
            double tenThousand = 10000L;
            double tenThousandPi = pi * tenThousand;
            int roundedTenThousandPi = (int)tenThousand * (int)pi;
            int integerPartOfTenThousandPi = (int)((double)tenThousand * (double)pi);
            Console.WriteLine(integerPartOfTenThousandPi);
            Console.WriteLine(roundedTenThousandPi);
        }
    }
}