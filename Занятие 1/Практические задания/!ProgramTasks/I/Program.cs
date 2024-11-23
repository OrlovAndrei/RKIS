namespace I
{
    internal class Program
    {
        static string GetLastHalf(string text)
        {
            int str = text.Length / 2;
            return (text.Substring(str)).Replace(" ", string.Empty);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetLastHalf("I love CSharp!"));
            Console.WriteLine(GetLastHalf("1234567890"));
            Console.WriteLine(GetLastHalf("до ре ми фа соль ля си"));
        }
    }
}