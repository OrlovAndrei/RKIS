namespace E
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string doubleNumber = "894376.243643";
            double number = double.Parse(doubleNumber); // Вася уверен, что ошибка где-то тут
            Console.WriteLine(number + 1);
        }
    }
} 