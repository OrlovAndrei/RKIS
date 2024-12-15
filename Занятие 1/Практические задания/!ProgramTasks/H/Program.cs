namespace H
{
    internal class Program
    {
        // Метод для вычисления квадрата числа
        private static int GetSquare(int number)
        {
            return number * number;
        }

        // Метод для вывода числа на экран
        private static void Print(int number)
        {
            Console.WriteLine(number);
        }

        static void Main(string[] args)
        {
            // Вызываем методы для получения квадрата и вывода на экран
            Print(GetSquare(42)); // Выводит 1764
        }
    }
}