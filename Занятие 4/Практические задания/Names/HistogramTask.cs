namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetHistogramBirthsPerDay(NameData[] names, string name)
        {
            // Определяем диапазон дней
            const int minimumDay = 2;
            int maximumDay = int.MinValue;

            // Находим максимальный день рождения
            foreach (var day in names)
            {
                maximumDay = Math.Max(maximumDay, day.BirthDate.Day);
            }

            // Создаем массив дней
            var days = new string[maximumDay - minimumDay + 1];
            for (var i = 0; i < days.Length; i++)
            {
                days[i] = (i + minimumDay).ToString();
            }

            // Создаем массив для подсчета рождений
            var birthCounts = new double[maximumDay - minimumDay + 1];

            // Подсчитываем рождения по дням для указанного имени
            foreach (var day in names)
            {
                if (day.Name == name && day.BirthDate.Day > 1)
                {
                    birthCounts[day.BirthDate.Day - minimumDay]++;
                }
            }

            // Возвращаем данные гистограммы
            return new HistogramData(
                string.Format("Рождаемость людей с именем '{0}'", name),
                days,
                birthCounts
            );
        }
    }
}