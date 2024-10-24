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

        private static string GetSuit(Suits suit)
        {
            if (suit == Suits.Wands) return "жезлов";
            else if (suit == Suits.Coins) return "монет";
            else if (suit == Suits.Cups) return "кубков";
            else return "мечей";
            return new string[] { "жезлов", "монет", "кубков", "мечей" }[Convert.ToInt32(suit)];

        }
    }
}