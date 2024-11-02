using System;

namespace I
{
    internal class Program
    {
        static string GetLastHalf(string text)
        {
            int middle = text.Length / 2;
            string secHalf = text.Substring(middle);
            string konec = secHalf.Replace(" ", "");
            return konec;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetLastHalf("I love CSharp!"));
            Console.WriteLine(GetLastHalf("1234567890"));
            Console.WriteLine(GetLastHalf("до ре ми фа соль ля си"));
        }
    }
}