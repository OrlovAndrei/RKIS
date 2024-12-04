namespace I
{
    internal class Program
    {
        static string GetLastHalf(string text)
        {
            text = text.Substring(text.Length / 2);
            string c = text.Replace(" ", "");
            return c;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetLastHalf("Hello Siharp"));
            Console.WriteLine(GetLastHalf("123456789"));
            Console.WriteLine(GetLastHalf("one two three"));
        }
    }
}