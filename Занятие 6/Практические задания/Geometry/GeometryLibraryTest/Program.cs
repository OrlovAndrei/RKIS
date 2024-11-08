using GeometryLibrary;
using System;

class Program
{
    static void Main()
    {
        Vector v1 = new Vector(3, 4);
        Vector v2 = new Vector(1, 2);

        double length = Geometry.GetLength(v1);
        Console.WriteLine($"Length of v1: {length}");

        Vector result = Geometry.Add(v1, v2);
        Console.WriteLine($"Sum of v1 and v2: ({result.X}, {result.Y})");

        Segment segment = new Segment(new Vector(0, 0), new Vector(4, 3));

        // Вычисляем длину отрезка
        double segmentLength = Geometry.GetLength(segment);
        Console.WriteLine($"Length of the segment: {segmentLength}");

        // Проверяем, лежит ли точка на отрезке
        Vector point1 = new Vector(2, 1.5); // Точка, лежащая на отрезке
        Vector point2 = new Vector(5, 4);   // Точка, не лежащая на отрезке

        Console.WriteLine($"Is point (2, 1.5) in segment: {Geometry.IsVectorInSegment(point1, segment)}");
        Console.WriteLine($"Is point (5, 4) in segment: {Geometry.IsVectorInSegment(point2, segment)}");

        Console.ReadKey();
    }
}


