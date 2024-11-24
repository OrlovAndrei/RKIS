namespace A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = "решИла нЕ Упрощать и зашифРОВАтЬ Все послаНИЕ дАже не Старайся нИЧЕГО у тЕбя нЕ получится с расшифРОВкой Сдавайся НЕ твоего ума Ты не споСОбЕн Но может быть если особенно упорно подойдешь к делу будет Трудно конечнО Код ведЬ не из простых очень ХОРОШИЙ код то у тебя все получится и я буДу Писать тЕбЕ еще чао";
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
                Console.WriteLine(word + " ");
            }
        }
    }
}