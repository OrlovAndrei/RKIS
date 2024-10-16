using System;
using System.Collections.Generic;

namespace EmailDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] entries = {
                "Sasha:sasha1995@sasha.ru",
                "Alex:alex99@mail.ru",
                "Shurik:shurik2020@google.com",
                "Sergey:sergey1985@mail.ru",
                "Anna:anna_123@gmail.com",
                "Anastasia:anastasia2022@gmail.com"
            };

            Dictionary<string, HashSet<string>> emailDictionary = new Dictionary<string, HashSet<string>>(); // java

            foreach (var entry in entries)
            {
                var parts = entry.Split(':');
                if (parts.Length == 2)
                {
                    string name = parts[0].Trim();
                    string email = parts[1].Trim();

                    string key = name.Length >= 2 ? name.Substring(0, 2).ToUpper() : name.ToUpper();

                    if (!emailDictionary.ContainsKey(key))
                    {
                        emailDictionary[key] = new HashSet<string>();
                    }
                    emailDictionary[key].Add(email);
                }
            }

            foreach (var kvp in emailDictionary)
            {
                Console.WriteLine($"Key: {kvp.Key} -> Value: {{{string.Join(", ", kvp.Value)}}}");
            }
        }
    }
}
