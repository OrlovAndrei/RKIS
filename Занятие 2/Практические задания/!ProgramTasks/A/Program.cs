namespace A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsLeapYear(2014)); //false
            Console.WriteLine(IsLeapYear(1999)); //false
            Console.WriteLine(IsLeapYear(8992)); //true
            Console.WriteLine(IsLeapYear(1)); //flase
            Console.WriteLine(IsLeapYear(14)); //false
            Console.WriteLine(IsLeapYear(400)); //true
            Console.WriteLine(IsLeapYear(600)); //false
            Console.WriteLine(IsLeapYear(3200)); //true
        }

        public static bool IsLeapYear(int year)
        {
            return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
        }
    }
}