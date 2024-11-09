namespace C
{
    public static class StringExtensions
    {
        public static int ToInt(this string str)
        {
            return int.TryParse(str, out var result) ? result : 0;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
