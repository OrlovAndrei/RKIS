using System.Globalization;

namespace E
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string doubleNumber = "894376.243643";
            double number = double.Parse(doubleNumber, CultureInfo.InvariantCulture); // ���� ������, ��� ������ ���-�� ���
            Console.WriteLine(number + 1);
        }
    }
}
