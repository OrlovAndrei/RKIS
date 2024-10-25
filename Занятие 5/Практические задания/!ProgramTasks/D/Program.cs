using System.Text;


namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] commands = { "push Привет! Это снова я! Пока!", "pop 5", "push Как твои успехи? Плохо?", "push qwertyuiop", "push 1234567890", "pop 26" };
            Console.WriteLine(ApplyCommands(commands));
        }
        public static string ApplyCommands(string[] commands)
        {
            var result = new StringBuilder();

            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i].StartsWith("push"))
                    result.Append(commands[i].Substring(5));
                else if (commands[i].StartsWith("pop"))
                {
                    int pop = int.Parse(commands[i].Substring(4));
                    if (pop <= result.Length)
                        result.Remove(result.Length - pop, pop);
                    else
                        result.Clear();
                }
            }
            return Convert.ToString(result);
        }
    }
}