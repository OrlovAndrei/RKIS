using System;

namespace ReadOnlyVector
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadOnlyVector vector1 = new ReadOnlyVector(3.0, 4.0);
            ReadOnlyVector vector2 = new ReadOnlyVector(1.0, 2.0);

            ReadOnlyVector sum = vector1.Add(vector2);
            Console.WriteLine($"Sum: X = {sum.X}, Y = {sum.Y}"); // —ÛÏÏ‡: X = 4.0, Y = 6.0

            ReadOnlyVector modifiedX = vector1.WithX(10.0);
            Console.WriteLine($"Modified X: X = {modifiedX.X}, Y = {modifiedX.Y}"); // X = 10.0, Y = 4.0

            ReadOnlyVector modifiedY = vector1.WithY(20.0);
            Console.WriteLine($"Modified Y: X = {modifiedY.X}, Y = {modifiedY.Y}"); // X = 3.0, Y = 20.0
        }
    }
}