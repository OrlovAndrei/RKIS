using System;
namespace B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestMove("a1", "d4");
            TestMove("f4", "e7");
            TestMove("a1", "a4");
        }

        public static void TestMove(string from, string to)
        {
            Console.WriteLine("{0}-{1} {2}", from, to, IsCorrectMove(from, to));
        }

        public static bool IsCorrectMove(string from, string to)
        {
            var dx = Math.Abs(to[0] - from[0]); //смещение фигуры по горизонтали
            var dy = Math.Abs(to[1] - from[1]); //смещение фигуры по вертикали
            return (dx == 0 || dy == 0 || dx == dy);
        }
    }
}