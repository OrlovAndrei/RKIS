using System;

namespace BankInterestCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ввод данных от пользователя
            Console.WriteLine("Введите исходную сумму, процентную ставку и срок вклада в месяцах через пробел:");
            string input = Console.ReadLine();
            
            // Вычисление накопившейся суммы
            double finalAmount = Calculate(input);
            
            // Вывод результата
            Console.WriteLine($"Накопившаяся сумма: {finalAmount:F2}"); // Форматируем вывод до 2 знаков после запятой
        }

        /// <summary>
        /// Метод для расчета накопившейся суммы по введенной строке.
        /// </summary>
        /// <param name="input">Строка с исходной суммой, процентной ставкой и сроком вклада.</param>
        /// <returns>Накопившаяся сумма на момент окончания вклада.</returns>
        public static double Calculate(string input)
        {
            // Разделяем входные данные на части
            string[] parts = input.Split(' ');
            double principal = double.Parse(parts[0]); // Исходная сумма
            double annualRate = double.Parse(parts[1]); // Процентная ставка
            int months = int.Parse(parts[2]); // Срок вклада в месяцах

            // Рассчитываем месячную процентную ставку
            double monthlyRate = annualRate / 12 / 100; // Годовая ставка в месячную

            // Рассчитываем накопившуюся сумму без использования циклов
            double finalAmount = principal * Math.Pow(1 + monthlyRate, months);

            return finalAmount;
        }
    }
}