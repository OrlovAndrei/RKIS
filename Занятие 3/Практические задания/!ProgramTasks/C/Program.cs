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
                string top = null!;
                for (int i = 0; i < text.Length + 2; i++)
                {
                    top += "-";
                }
                Console.WriteLine($"+{top}+");
                Console.WriteLine($"| {text} |");
                Console.WriteLine($"+{top}+");
            
        }
    }
}