namespace E
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string doubleNumber = "894376.243643";
            // Преобразуем строку в double, а затем в int
            double parsedDouble = double.Parse(doubleNumber); // Преобразуем строку в double
            int number = (int)parsedDouble; // Приводим double к int (это приведет к потере дробной части)

            Console.WriteLine(number + 1); // Выводим результат
        }
    }
}