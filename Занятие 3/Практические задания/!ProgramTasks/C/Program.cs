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
            // +-------------+
            // | Hello world |
            // +-------------+
            string leaders = new String('-', text.Length + 2);
            Console.WriteLine($"+{leaders}+");
            Console.WriteLine($"| {text} |");
            Console.WriteLine($"+{leaders}+");
        }
    }
}