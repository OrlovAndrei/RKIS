 
namespace B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contacts = new List<string>
            {
                "Sasha: sasha1995 @sasha.ru",
                "Alexey: alex99 @mail.ru",
                "Shurik: shurik2020 @google.com",
                "Sergey: serg_prog @code.com",
                "Anna: anna123 @sunnyday.ru",
                "Anastasia: ana_star @dreamworld.com",
                "Anton: anton_dev @techmail.com",
                "Aleksei: aleksei_prog @coderz.net",
                "Semen: sem_prog @backend.ru",
                "Sveta: sveta.design @creations.com",
            };
                var emailDictionary = new Dictionary<string, List<string>>();

                foreach (var contact in contacts)
                {
                    var parts = contact.Split(':');
                    var name = parts[0];
                    var email = parts[1];

                     
                    var key = name.Substring(0, 2);

                     
                    if (!emailDictionary.ContainsKey(key))
                    {
                        emailDictionary[key] = new List<string>();
                    }
                    emailDictionary[key].Add(email);
                }

                 
                foreach (var key in emailDictionary.Keys)
                {
                    Console.WriteLine($"Key: {key} -> Value: {string.Join(", ", emailDictionary[key])}");
                }

        }
    }
}