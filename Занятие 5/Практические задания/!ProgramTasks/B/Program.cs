using System;
using System.Collections.Generic;

namespace B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contacts = new List<string>
            {
                "Sasha:sasha1995@sasha.ru",
                "Alex:alex99@mail.ru",
                "Shurik:shurik2020@google.com",
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
