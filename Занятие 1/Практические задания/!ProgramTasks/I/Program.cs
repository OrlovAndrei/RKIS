namespace I
{
    internal class Program
    {
        static string GetLastHalf(string text)
        {
           text = text.Substring(text.Length / 2);
            string c = text.Replace(" ", Empty);
            return c;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetLastHalf("I love CSharp!"));
            Console.WriteLine(GetLastHalf("1234567890"));
            Console.WriteLine(GetLastHalf("до ре ми фа соль ля си"));
        }
    }
}
