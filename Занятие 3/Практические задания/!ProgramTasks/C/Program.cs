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
            int textLength = text.Length;
            string border = "+" + new string('-', textLength + 2) + "+";
            Console.WriteLine(border);
            Console.WriteLine($"| {text} |");
            Console.WriteLine(border);
        }
    }
}