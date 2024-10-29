namespace C
{
    public static class Extensions
    {
        public static int ToInt(this string str)
        {
            return int.Parse(str);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var arg1 = "100500";
            Console.Write(arg1.ToInt() + "42".ToInt());
        }
    }
}