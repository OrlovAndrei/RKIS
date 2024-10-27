using System;
using System.Collections.Generic;

namespace A
{
    internal class Program
    {
        static void Main(string[] args)
        {
                        string message = "решИла нЕ Упрощать и зашифРОВАтЬ Все послаНИЕдАже не Старайся нИЧЕГО у тЕбя нЕ получится с расшифРОВкойСдавайся НЕ твоего ума Ты не споСОбЕн Но может бытьесли особенно упорно подойдешь к делубудет Трудно конечнОКод ведЬ не из простыхочень ХОРОШИЙ кодто у тебя все получитсяи я буДу Писать тЕбЕ ещечао";
            List<string> capitalWords = new List<string>();
            string[] words = message.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = words.Length - 1; i >= 0; i--)
            {
                if (char.IsUpper(words[i][0]))
                {
                    capitalWords.Add(words[i]);
                }
            }
            Console.WriteLine("Результат:");
            foreach (string word in capitalWords)
            {
                Console.Write(word + " ");
            }
        }
    }
}