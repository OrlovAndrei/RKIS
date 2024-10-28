namespace C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (a > b)
                if (b > c) return b;
                else if (a > c) return ...
            else
                ...
            if ((a >= b) && (b >= c) || (c >= b) && (b >= a)) // проверяем b по всем возможным сценариям
                return b;
            else if ((a >= c) && (c >= b) || (b >= c) && (c >= a)) // проверяем c по всем возможным сценариям
                return c;
            else // a можно не проверять так как он крайний вариант
                return a;


        }
    }
}
