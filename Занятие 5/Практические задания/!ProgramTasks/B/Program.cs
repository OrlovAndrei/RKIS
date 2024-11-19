namespace B;

internal class Program
{
    private static void Main(string[] args)
    {
        var filePath = "emails.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл {filePath} не найден.");
            return;
        }

        var records = File.ReadAllLines(filePath);

        var emailDictionary = BuildEmailDictionary(records);

        foreach (var key in emailDictionary.Keys)
            Console.WriteLine($"{key}: {string.Join(", ", emailDictionary[key])}");
    }

    private static Dictionary<string, List<string>> BuildEmailDictionary(string[] records)
    {
        var dictionary = new Dictionary<string, List<string>>();

        foreach (var record in records)
        {
            var parts = record.Split(':');
            if (parts.Length < 2) continue;

            var name = parts[0].Trim();
            var email = parts[1].Trim();

            if (name.Length >= 2)
            {
                var key = name.Substring(0, 2);

                if (!dictionary.ContainsKey(key))
                    dictionary[key] = new List<string>();

                dictionary[key].Add(email);
            }
        }

        return dictionary;
    }
}