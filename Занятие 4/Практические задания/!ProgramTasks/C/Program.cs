namespace C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetElementCount(new[] { 1, 1, 2, 1 }, 1));
        }

        public static int GetElementCount(int[] items, int itemToCount)
        {
            int count = 0; // Переменная для хранения количества вхождений
            foreach (var item in items) // Перебираю элементы массива
            {
                if (item == itemToCount) // Проверяю, совпадает ли элемент с искомым
                {
                    count++; // Увеличиваю счетчик
                }
            }
            return count; // Возвращаю количество вхождений
        }
    }
}
