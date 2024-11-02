namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            // Инициализируем массив дней от 1 до 31
            var days = new string[31];
            for (int i = 0; i < days.Length; i++)
            {
                days[i] = (i + 1).ToString(); // Корректный подход к заполнению дней
            }

            var birthsCounts = new double[31];

            // Проходим по каждому имени
            foreach (var man in names)
            {
                // Учитываем только тех, кто не родился 1 числа
                if (man.Name == name && man.BirthDate.Day != 1)
                {
                    birthsCounts[man.BirthDate.Day - 1]++; // Увеличиваем счетчик для соответствующего дня
                }
            }

            // Создаем и возвращаем объект гистограммы
            return new HistogramData(
                string.Format("Рождаемость людей с именем '{0}'", name),
                days,
                birthsCounts);
        }
    }
}
