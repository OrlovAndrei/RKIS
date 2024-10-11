namespace C
{
    static void Main(string[] args)
        {
            double pi = Math.PI;
            int tenThousand = 10000L;
            float tenThousandPi = pi * tenThousand;
            int roundedTenThousandPi = tenThousandPi;
            int integerPartOfTenThousandPi = tenThousandPi;
            int tenThousand =(int)10000L;
            float tenThousandPi =(float)(pi * tenThousand);
            int roundedTenThousandPi =(int)Math.Round(tenThousandPi);
            int integerPartOfTenThousandPi =(int)tenThousandPi;
            Console.WriteLine(integerPartOfTenThousandPi);
            Console.WriteLine(roundedTenThousandPi);
        }
    }
}
