namespace E
{
    internal class Program
    {
       static void Main(string[] args)
            if (suit == Suits.Wands) return "жезлов";
            else if (suit == Suits.Coins) return "монет";
            else if (suit == Suits.Cups) return "кубков";
            else return "мечей";
            return new string[] { "жезлов", "монет", "кубков", "мечей" }[(int)suit];
        }
    }
}
