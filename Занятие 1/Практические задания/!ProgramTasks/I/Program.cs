namespace I
{
    internal class Program
    {
        int mid = text.Length / 2;
        string lastHalf = text.Substring(mid).Replace(" ", "");
        return lastHalf;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetLastHalf("I love CSharp!"));
            Console.WriteLine(GetLastHalf("1234567890"));
            Console.WriteLine(GetLastHalf("до ре ми фа соль ля си"));
        }
    }
}
