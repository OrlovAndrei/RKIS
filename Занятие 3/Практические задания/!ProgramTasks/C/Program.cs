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
            string middleFrame = "| " + text + " |";
            string topFrame = "";
            for (int i = 0; i < middleFrame.Length; i++)
            {
                if (i == 0 || i == middleFrame.Length - 1) topFrame += "+";
                else topFrame += "-";
            }
            string bottomFrame = topFrame;
            Console.WriteLine(topFrame + "\n" + middleFrame + "\n" + bottomFrame);
        }
    }
}
