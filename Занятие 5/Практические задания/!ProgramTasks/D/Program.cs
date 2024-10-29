namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] commands = {
                "push Привет! Это снова я! Пока!",
                "pop 5",
                "push Как твои успехи? Плохо?",
                "push qwertyuiop",
                "push 1234567890",
                "pop 26"
            };

            Stack<string> stack = new Stack<string>();
            string text = "";

            foreach (var command in commands)
            {
                if (command.StartsWith("push"))
                {
                    string toPush = command.Substring(5);
                    stack.Push(toPush);
                    text += toPush;
                }
                else if (command.StartsWith("pop"))
                {
                    int count = int.Parse(command.Substring(4));
                    if (text.Length >= count)
                    {
                        text = text.Substring(0, text.Length - count);
                    }
                }

            }

            Console.WriteLine("Результат:");
            Console.WriteLine(text);

        }
    }
}