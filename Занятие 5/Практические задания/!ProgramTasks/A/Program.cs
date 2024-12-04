using System;
using System.Collections.Generic;
using System.Linq;

namespace A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = @"решИла нЕ Упрощать и зашифРОВАтЬ Все послаНИЕ
                            дАже не Старайся нИЧЕГО у тЕбя нЕ получится с расшифРОВкой
                            Сдавайся НЕ твоего ума Ты не споСОбЕн Но может быть
                            если особенно упорно подойдешь к делу

                            будет Трудно конечнО
                            Код ведЬ не из простых
                            очень ХОРОШИЙ код
                            то у тебя все получится
                            и я буДу Писать тЕбЕ еще

                            чао";

            var words = text.Split(new char[] { ' ', '\n', '\r', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            var capitalWords = words.Where(word => char.IsUpper(word[0])).ToList();

            capitalWords.Reverse();

            foreach (var word in capitalWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
