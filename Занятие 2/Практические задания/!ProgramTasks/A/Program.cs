namespace A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]years=new int[8]{2014,1999,8992,1,14,400,600,3200}; 
            foreach (int year in years){
                System.Console.WriteLine(IsLeapYear(year));
            }
        }

        public static bool IsLeapYear(int year)
        {
            return year % 400 == 0 || (!(year % 100 == 0) && year % 4 == 0 );
        }
    }
}