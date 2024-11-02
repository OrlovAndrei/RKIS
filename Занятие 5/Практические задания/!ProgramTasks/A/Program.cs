using System;
using System.Collections.Generic;
using System.Linq;

namespace A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = @"решИла нЕ Упрощать и зашифРОВАтЬ Все послаНИЕ
дАже не Старайся нИЧЕГО у тЕбя нЕ получится с расшифРОВкой
Сдавайся НЕ твоего ума Ты не споСОбЕн Но может быть
если особенно упорно подойдешь к делу
будет Трудно конечнО
Код ведЬ не из простых
очень ХОРОШИЙ код
то у тебя все получится
и я буДу Писать тЕбЕ еще
чао";

            // Разбиваем текст на слова
            string[] words = message.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Выбираем слова, которые начинаются с заглавной буквы
            List<string> capitalizedWords = new List<string>();

            foreach (var word in words)
            {
                if (char.IsUpper(word[0]))
                {
                    capitalizedWords.Add(word);
                }
            }

            // Выводим слова в обратном порядке
            capitalizedWords.Reverse();
            Console.WriteLine(string.Join(" ", capitalizedWords));
        }
    }
}
