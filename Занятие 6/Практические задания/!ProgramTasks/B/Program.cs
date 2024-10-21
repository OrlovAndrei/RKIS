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
            foreach (var menuItem in menu)
            {
                System.Console.WriteLine($"{menuItem.Caption} ({menuItem.HotKey})");
                if (menuItem.Items != null)
                {
                    foreach (var subItem in menuItem.Items)
                    {
                        System.Console.WriteLine($"    {subItem.Caption} ({subItem.HotKey})");
                    }
                }
            }
            
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
}