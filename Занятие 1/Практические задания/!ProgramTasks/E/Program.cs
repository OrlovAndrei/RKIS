using System;
using System.Globalization;

namespace E
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string doubleNumber = "894376.243643";
            double number = double.Parse(doubleNumber, CultureInfo.InvariantCulture); // Сделано, но при изменении строки добавились первые две строчки, чтобы возможно было применить CultureInfo
            Console.WriteLine(number + 1);
        }
    }
}