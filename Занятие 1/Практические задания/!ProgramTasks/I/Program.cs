namespace I
{
    internal class Program
    {
        static string GetLastHalf(string text)
        {
            int textHalf = text.Length / 2;

            string half = text.Substring(textHalf).Replace(" ", "");
            return half;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetLastHalf("I love CSharp!"));
            Console.WriteLine(GetLastHalf("1234567890"));
            Console.WriteLine(GetLastHalf("до ре ми фа соль ля си"));
        }
    }
}