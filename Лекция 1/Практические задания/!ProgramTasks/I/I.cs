using System.Text;

namespace I
{
    internal class Program
    {
        static string GetLastHalf(string text)
        {
            text = text.Replace(" ", String.Empty);
            string c = text.Substring(text.Length / 2);
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