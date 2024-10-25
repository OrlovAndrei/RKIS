namespace A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] mesage =
            {
                "решИла нЕ Упрощать и зашифРОВАтЬ Все послаНИЕ ",
                "дАже не Старайся нИЧЕГО у тЕбя нЕ получится с расшифРОВкой ",
                "Сдавайся НЕ твоего ума Ты не споСОбЕн Но может быть ",
                "если особенно упорно подойдешь к делу",
                " ",
                "будет Трудно конечнО ",
                "Код ведЬ не из простых ",
                "очень ХОРОШИЙ код",
                "то у тебя все получится",
                "и я буДу Писать тЕбЕ еще ",
                " ",
                "чао"
            };
            Console.WriteLine(DecodeMessage(mesage));
        }
        private static string DecodeMessage(string[] lines)
        {
            string message = "";
            foreach (var line in lines.Reverse())
            {
                foreach (var word in line.Split(' ').Reverse())
                {
                    if (word.Length != 0)
                    {
                        if (char.IsUpper(word[0]))
                        {
                            message += word + " ";
                        }
                    }
                }
            }
            return message.Trim();
        }
    }
}