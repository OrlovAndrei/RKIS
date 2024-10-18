using System;
using System.Collections.Generic;
using System.IO;

namespace EmailDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var entries = new List<string>(File.ReadAllLines('emails.txt'))

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
