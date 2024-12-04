namespace E
{
    internal class Program
    {
        enum Suits
        {
            Wands, // index: 0
            Coins, // index; 1
            Cups, // index: 2
            Swords // index: 3
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
            string[] suitNames = { "жезлов", "монет", "кубков", "мечей"};
            return suitNames[(int)suit]; // после тех задач, эта самая легкая

            // if (suit == Suits.Wands) return "жезлов";
            // else if (suit == Suits.Coins) return "монет";
            // else if (suit == Suits.Cups) return "кубков";
            // else return "мечей";
        }
    }
}
