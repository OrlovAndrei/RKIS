namespace A
﻿using System;
using System.Collections.Generic;
namespace A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var records = new List<string>
            {
                "Alex:alex99@mail.ru",
                "Shurik:shurik2020@google.com",
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
        {
        }
