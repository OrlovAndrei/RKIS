namespace D;

internal class Program
{
    private static void Main(string[] args)
    {
        var filePath = "operations.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл {filePath} не найден.");
            return;
        }

        var commands = File.ReadAllLines(filePath);

        var result = DecodeOperations(commands);

        Console.WriteLine("Результат работы стека:");
        Console.WriteLine(result);
    }

    private static string DecodeOperations(string[] commands)
    {
        var stack = string.Empty;

        foreach (var command in commands)
            if (command.StartsWith("push "))
            {
                var textToPush = command.Substring(5);
                stack += textToPush;
            }
            else if (command.StartsWith("pop "))
            {
                if (int.TryParse(command.Substring(4), out var charsToPop) && charsToPop > 0)
                    stack = stack.Length > charsToPop
                        ? stack.Substring(0, stack.Length - charsToPop)
                        : string.Empty;
            }

        return stack;
    }
}