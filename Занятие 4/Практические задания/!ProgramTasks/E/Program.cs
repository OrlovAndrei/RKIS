﻿namespace E
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

        private static string GetSuit(Suits suit)
        {
            string[] suitNames = { "жезлов", "монет", "кубков", "мечей"}
            return suitNames[(int)suit]
        }
    }
}
