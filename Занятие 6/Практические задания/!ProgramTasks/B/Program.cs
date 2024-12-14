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
            var menu = GenerateMenu();
            // Здесь можно добавить код для отображения меню, если необходимо
        }

        public static MenuItem[] GenerateMenu()
        {
            return new[]
            {
                new MenuItem
                {
                    Caption = "File",
                    HotKey = "F",
                    Items = new[]
                    {
                        new MenuItem { Caption = "New", HotKey = "N", Items = null },
                        new MenuItem { Caption = "Save", HotKey = "S", Items = null }
                    }
                },
                new MenuItem
                {
                    Caption = "Edit",
                    HotKey = "E",
                    Items = new[]
                    {
                        new MenuItem { Caption = "Copy", HotKey = "C", Items = null },
                        new MenuItem { Caption = "Paste", HotKey = "V", Items = null }
                    }
                }
            };
        }
    }
}
