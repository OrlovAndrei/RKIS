using System;
using System.Collections.Generic;

namespace A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = @"
                решИла нЕ Упрощать и зашифРОВАтЬ Все послаНИЕ
                дАже не Старайся нИЧЕГО у тЕбя нЕ получится с расшифРОВкой
                Сдавайся НЕ твоего ума Ты не споСОбЕн Но может быть
                если особенно упорно подойдешь к делу

                будет Трудно конечнО
                Код ведЬ не из простых
                очень ХОРОШИЙ код
                то у тебя все получится
                и я буДу Писать тЕбЕ еще

                чао
            ";

            string decryptedMessage = DecryptMessage(message);
            Console.WriteLine(decryptedMessage);
        }

        static string DecryptMessage(string message)
        {
            var words = message.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var capitalizedWords = new Stack<string>();

            foreach (var word in words)
            {
                if (char.IsUpper(word[0]))
                    capitalizedWords.Push(word);
            }

            return string.Join(" ", capitalizedWords);
        }
    }
}
