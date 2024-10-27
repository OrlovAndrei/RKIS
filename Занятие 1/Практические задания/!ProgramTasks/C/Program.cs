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
            int tenThousand = 10000;
            float tenThousandPi =(float)(pi * tenThousand);
            int roundedTenThousandPi = (int)Math.round(tenThousandPi);
            int integerPartOfTenThousandPi = (int)tenThousandPi;
            Console.WriteLine(integerPartOfTenThousandPi);
            Console.WriteLine(roundedTenThousandPi);
        }
    }
}
