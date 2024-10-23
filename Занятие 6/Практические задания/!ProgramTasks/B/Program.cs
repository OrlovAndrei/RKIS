namespace B
{
    public class MenuItem
    {
        public string Caption;
        public string HotKey;
        public MenuItem[] Items;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            GenerateMenu();
        }

        public static MenuItem[] GenerateMenu()
        {
            return new[] {
            ...
            };
        }
}
    }
}