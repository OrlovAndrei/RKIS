namespace B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>() { "key: Sа -> value: { sasha1995@sasha.ru, alex99@mail.ru, shurik2020@google.com }" };
            var dict = OptimizeContacts(list);

            foreach (var pair in dict)
            {
                Console.WriteLine($"Key: {pair.Key}");
                Console.Write("Value:");
                foreach (var email in pair.Value)
                {
                    Console.Write($"{email} ");
                }
            }
        }
        static Dictionary<string, List<string>> OptimizeContacts(List<string> contacts)
        {
            var dictionary = new Dictionary<string, List<string>>();
            for (int i = 0; i < contacts.Count; i++)
            {
                int tempNameIndex = contacts[i].IndexOf(":");
                int tempNameIndex2 = contacts[i].IndexOf("-");
                string name = "";
                for (int k = tempNameIndex; k < tempNameIndex2; k++)
                {
                    name += contacts[i][k];
                }
                name = name.Replace(" ", "").Replace(":", "");

                int tempEmailIndex = contacts[i].IndexOf("{");
                int tempEmailIndex2 = contacts[i].LastIndexOf("}");
                string emails = "";
                for (int k = tempEmailIndex; k < tempEmailIndex2; k++)
                {
                    emails += contacts[i][k];
                }
                //emails.Replace("{", "");
                var emailsArray = emails.Split(' ', ',', '{');
                var emailsList = emailsArray.ToList();
                dictionary.Add(name, emailsList);
            }
            return dictionary;
        }

    }
}