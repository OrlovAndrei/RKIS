namespace C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteTextWithBorder("Menu:");
            WriteTextWithBorder("");
            WriteTextWithBorder(" ");
            WriteTextWithBorder("Game Over!");
            WriteTextWithBorder("Select level:");
        }

        private static void WriteTextWithBorder(string text)
        {
            Console.WriteLine("+" + string.Join("", Enumerable.Repeat("-", text.Length + 2)) + "+");
            Console.WriteLine($"| {text} |");
            Console.WriteLine("+" + string.Join("", Enumerable.Repeat("-", text.Length + 2)) + "+");
        }
    }
}