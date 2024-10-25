namespace C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReplaceIncorrectSeparators("Hello, World!"));
        }
        public static string ReplaceIncorrectSeparators(string text)
        {
            return String.Join('\t', text.Split(new char[] { ' ', ':', '-', ',', ';' }));
        }
    }
}