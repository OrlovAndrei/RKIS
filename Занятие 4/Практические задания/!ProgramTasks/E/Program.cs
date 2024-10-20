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
            return new string[] { "жезлов", "монет", "кубков", "мечей" }[(int)suit];
        }
    }
}
