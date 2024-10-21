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
                new MenuItem {
                Caption = "File", HotKey = "F", Items = new MenuItem [] {
                new MenuItem {Caption = "New", HotKey = "N"},
                new MenuItem {Caption = "Save", HotKey = "S"}
                }},
                new MenuItem {
                Caption = "Edit", HotKey = "E", Items = new MenuItem [] {
                new MenuItem {Caption = "Copy", HotKey = "C"},
                new MenuItem {Caption = "Paste", HotKey = "V"}
                }}
            };
        }
    }

}