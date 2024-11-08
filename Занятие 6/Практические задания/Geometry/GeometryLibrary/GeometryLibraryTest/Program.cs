using GeometryLibrary;
using System;

class Program
{
    static void Main()
    {
        // Создаем два вектора
        Vector v1 = new Vector(3, 4);
        Vector v2 = new Vector(1, 2);

        // Вычисляем длину первого вектора
        double length = Geometry.GetLength(v1);
        Console.WriteLine($"Length of v1: {length}");

        // Складываем два вектора
        Vector result = Geometry.Add(v1, v2);
        Console.WriteLine($"Sum of v1 and v2: ({result.X}, {result.Y})");

        // Ожидаем нажатия клавиши для завершения
        Console.ReadKey();
    }
}


