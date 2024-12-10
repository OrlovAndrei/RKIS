using System;

namespace C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pi = Math.PI;
            long tenThousand = 10000L;
            double tenThousandPi = pi * tenThousand;
            int roundedTenThousandPi = (int)Math.Round(tenThousandPi);
            int integerPartOfTenThousandPi = (int)tenThousandPi;
            Console.WriteLine(integerPartOfTenThousandPi);
            Console.WriteLine(roundedTenThousandPi);
        }
    }
}