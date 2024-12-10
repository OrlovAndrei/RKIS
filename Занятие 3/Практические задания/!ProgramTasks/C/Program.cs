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
            int length = text.Length + 2;

            string border = new string('-', length);

            string formattedText = $"| {text} |";

            Console.WriteLine($"+{border}+");
            Console.WriteLine(formattedText);
            Console.WriteLine($"+{border}+");
        }
    }
}