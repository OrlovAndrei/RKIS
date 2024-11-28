using System;

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

            string framedText = $"| {text} |";

            string border = new string('-', framedText.Length - 2);
           
            Console.WriteLine($"+{border}+");
            Console.WriteLine(framedText);
            Console.WriteLine($"+{border}+");    
        }
    }
}