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
            string formattedText = $" {text} ";
            int width = formattedText.Length + 2; // 2 for the border spaces

            Console.WriteLine("+" + new string('-', width - 2) + "+");
            Console.WriteLine("|" + formattedText + "|");
            Console.WriteLine("+" + new string('-', width - 2) + "+");
        }
    }
}