using System;
using System.Collections.Generic;

namespace B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var entries = {
                "Sasha: sasha1995@sasha.ru",
                "Alexey: alex99@mail.ru",
                "Shurik: shurik2020@google.com",
                "Sergey: serg_prog@code.com",
                "Anna: anna123@sunnyday.ru",
                "Anastasia: ana_star@dreamworld.com",
                "Anton: anton_dev@techmail.com",
                "Aleksei: aleksei_prog@coderz.net",
                "Semen: sem_prog@backend.ru",
                "Sveta: sveta.design@creations.com",
                "Alina: alina123@dreams.org",
                "Sergei: sergei_cool@netdev.com",
                "Semenov: semenov_art@artvision.io",
                "Svetlana: svetlana_art@artisticworld.com",
                "Andrey: andrey_code@developers.org",
                "Alyona: alyona.music@melodies.ru",
                "Stepan: stepan_programmer@logicmail.net",
                "Stas: stas_artist@visualizer.com",
                "Anya: anya_star@wonder.net",
                "Sofiya: sofiya_dev@creatives.ru",
                "Svyatoslav: svyat_prog@technoworld.io",
                "Arkady: arkady_hacker@cyber.net",
                "Slava: slava.dev@webmasters.com",
                "Aleksey: aleksey.design@visioners.com",
                "Sergii: sergii_front@frontendmail.com",
                "Sveta: sveta_prog@codevision.com",
                "Alek: alek_coder@tech.io",
                "Stanislav: stanislav_tech@brainstorm.com",
                "Sasha: sasha_new@cloudworld.org",
                "Anatoliy: anatoliy.web@digital.org"
            }

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
