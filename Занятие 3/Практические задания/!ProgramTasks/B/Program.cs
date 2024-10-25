namespace B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RemoveStartSpaces("a"));
            Console.WriteLine(RemoveStartSpaces(" b"));
            Console.WriteLine(RemoveStartSpaces(" cd"));
            Console.WriteLine(RemoveStartSpaces(" efg"));
            Console.WriteLine(RemoveStartSpaces(" text"));
            Console.WriteLine(RemoveStartSpaces(" two words"));
            Console.WriteLine(RemoveStartSpaces("  two spaces"));
            Console.WriteLine(RemoveStartSpaces("	tabs"));
            Console.WriteLine(RemoveStartSpaces("		two	tabs"));
            Console.WriteLine(RemoveStartSpaces("                             many spaces"));
            Console.WriteLine(RemoveStartSpaces("               "));
            Console.WriteLine(RemoveStartSpaces("\n\r line breaks are spaces too"));
        }

        public static string RemoveStartSpaces(string text)
        {
            int counter = 0;
            if (char.IsWhiteSpace(text[counter]))
            {
                counter++;
                while (char.IsWhiteSpace(text[counter]))
                    counter++;
                return text.Substring(counter);
            }
            else
                return text;
        }
        public static string RemoveStartSpaces2(string text)
        {
            if (char.IsWhiteSpace(text[0])) return RemoveStartSpaces2(text.Substring(1));
            else return text;
        }
    }
}
