namespace E
{
    internal class Program
    {
        enum Suits
        {
            Wands,
            Coins,
            Cups,
            Swords
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetSuit(Suits.Wands));
            Console.WriteLine(GetSuit(Suits.Coins));
            Console.WriteLine(GetSuit(Suits.Cups));
            Console.WriteLine(GetSuit(Suits.Swords));
        }

         public enum Suits
    {
        Wands,
        Pentacles,
        Cups,
        Swords
    }

    private static string GetSuit(Suits suit)
    {
        return new[] { "жезлов", "монет", "кубков", "мечей" }[(int)suit];
    }
using System;

namespace F
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CheckFirstElement(null)); // Вывод: False
            Console.WriteLine(CheckFirstElement(new int[0])); // Вывод: False
            Console.WriteLine(CheckFirstElement(new[] { 1 })); // Вывод: False
            Console.WriteLine(CheckFirstElement(new[] { 0 })); // Вывод: True
        }
    }
}
