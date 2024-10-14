namespace B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxIndex(new[] { 1.0, .2, 100, 2e+10 }));
            Console.WriteLine(MaxIndex(new double[] { })); // Выводит -1 для пустого массива
        }

        static double Min(double[] array)
        {
            var min = double.MaxValue;
            foreach (var item in array)
                if (item < min) min = item;
            return min;
        }

        public static int MaxIndex(double[] array)
        {
            if (array.Length == 0) return -1; // Проверка на пустоту
            double max = double.MinValue; // Инициализируем минимально возможным значением
            int maxIndex = -1; // Изначально индекс не определён

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max) // Условие нахождения нового максимума
                {
                    max = array[i];
                    maxIndex = i; // Обновляем индекс максимума
                }
            }
            return maxIndex; // Возвращаем индекс наибольшего элемента
        }
    }
}
