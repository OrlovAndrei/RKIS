namespace I
{
    internal class Program
    {
        static string GetLastHalf(string text)
        {
            int halfLength = text.Length / 2;
            return text.Substring(halfLength).Replace(" ", "");
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetLastHalf("I love CSharp!"));       // Вывод: "CSharp!"
            Console.WriteLine(GetLastHalf("1234567890"));           // Вывод: "67890"
            Console.WriteLine(GetLastHalf("до ре ми фа соль ля си")); // Вывод: "сольляси"
        }
    }
}
