using System;
using System.Collections.Generic;

namespace B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var records = new List<string>
            {
                "Sasha:sasha1995@sasha.ru",
                "Alex:alex99@mail.ru",
                "Shurik:shurik2020@google.com",
                "Sergey:sergey@example.com"
            };

            var emailDictionary = new Dictionary<string, HashSet<string>>();

            foreach (var record in records)
            {
                var parts = record.Split(':');
                var name = parts[0];
                var email = parts[1];

                var key = name.Substring(0, 2).ToUpper();

                if (!emailDictionary.ContainsKey(key))
                {
                    emailDictionary[key] = new HashSet<string>();
                }
                emailDictionary[key].Add(email);
            }

            foreach (var kvp in emailDictionary)
            {
                Console.WriteLine($"Key: {kvp.Key} -> Values: {string.Join(", ", kvp.Value)}");
            }
        }
    }
}
