namespace B
  public class MenuItem
    {
        public string Caption { get; set; }
        public string HotKey { get; set; }
        public MenuItem[] Items { get; set; }
    }

    internal class Program
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
