namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var commands = new List<string>
            {
                "push Привет! Это снова я! Пока!",
                "pop 5",
                "push Как твои успехи? Плохо?",
                "push qwertyuiop",
                "push 1234567890",
                "pop 26"
            };
            string text = ""

            foreach (var command in commands) {
                var parts = command.Split(' ', 2);

                if (parts[0] == "push" && parts.Length == 2)
                {
                    text += parts[1];
                }

                else if (parts[0] == "pop" && parts.Length == 2)
                {
                    int count = int.Parse(parts[1]);

                    if (count <= text.Length) {
                        text = text.Substring(0, text.Length - count);
                    } else {
                        text = "";
                    }
                }
            }

            Console.WriteLine(text);
        }
    }
}