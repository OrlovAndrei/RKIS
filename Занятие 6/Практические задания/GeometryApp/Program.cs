using System;
using Geometry;

class Program
{
    static void Main()
    {
        Vector v1 = new Vector(2, 0);
        Vector v2 = new Vector(1, 6);
        Segment segment = new Segment(v1, v2);

        double segmentLength = segment.GetLength();
        Console.WriteLine($"Длина сегмента: {segmentLength}");

        Vector point = new Vector(1.5, 2);
        bool isInSegment = point.Belongs(segment);
        Console.WriteLine($"Точка ({point.X}, {point.Y}) находиться на сегменте: {isInSegment}");

        Vector v3 = new Vector(1, 3);
        Vector sum = v1.Add(v3);
        Console.WriteLine($"Сумма векторов: ({sum.X}, {sum.Y})");
    }
}
 