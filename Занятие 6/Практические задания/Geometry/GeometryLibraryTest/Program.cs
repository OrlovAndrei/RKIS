using GeometryLibrary;
using System;

class Program
{
    static void Main()
    {
        Vector v1 = new Vector(3, 4);
        Vector v2 = new Vector(1, 2);

        double length = v1.GetLength();
        Console.WriteLine($"Length of v1: {length}");

        Vector result = v1.Add(v2);   
        Console.WriteLine($"Sum of v1 and v2: ({result.X}, {result.Y})");

        Segment segment = new Segment(new Vector(0, 0), new Vector(4, 3));

        double segmentLength = segment.GetLength();   
        Console.WriteLine($"Length of the segment: {segmentLength}");

        Vector point1 = new Vector(2, 1.5);   
        Vector point2 = new Vector(5, 4);     

        Console.WriteLine($"Is point (2, 1.5) in segment: {segment.Contains(point1)}");
        Console.WriteLine($"Is point (5, 4) in segment: {segment.Contains(point2)}");

        Console.ReadKey();
    }
}