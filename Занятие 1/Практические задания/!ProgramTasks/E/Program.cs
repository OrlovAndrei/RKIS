namespace E
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string doubleNumber = "894376.243643";
            double parsedDouble = double.Parse(doubleNumber); // Преобразуем строку в число с плавающей запятой
            int number = (int)Math.Floor(parsedDouble); // Преобразуем в целое число, отбросив дробную часть
            Console.WriteLine(number + 1);
        }
    }
}