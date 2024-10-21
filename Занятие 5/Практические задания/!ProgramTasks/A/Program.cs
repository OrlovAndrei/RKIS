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

            чао"

            string[] words = message.Split(new[], {' ', '\n', '\r', '\t'}, StringSplitOptions.RemoveEmptyEntries)
            var capitalizedWords = new List<string>();

            foreach (var word in words) {
                if (char.isUpper(word[0])) {
                    capitalizedWords.Add(word);
                }
            }

            for (int i = capitalizedWords.Count - 1; i >= 0; i--) {
                Console.WriteLine(capitalizedWords[i] + " ") // Писать буДу я тЕбЕ Код ХОРОШИЙ Код Трудно Ты НЕ Сдавайся Все Упрощать
            }
        }
    }
}