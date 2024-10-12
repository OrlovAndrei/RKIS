namespace I
{
    internal class Program
    {
        static string GetLastHalf(string text)
        {
            static void Print(int number) {
                Console.WriteLine(number);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetLastHalf("I love CSharp!"));
            Console.WriteLine(GetLastHalf("1234567890"));
            Console.WriteLine(GetLastHalf("до ре ми фа соль ля си"));
        }
    }
}