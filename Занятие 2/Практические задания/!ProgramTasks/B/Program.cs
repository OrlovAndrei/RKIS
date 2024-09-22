using System.ComponentModel.Design;

namespace B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestMove("a1", "d4"); 
            TestMove("f4", "e7"); 
            TestMove("a1", "a4"); 
            TestMove("a1", "a1"); 
            TestMove("a1", "b2"); 
            TestMove("a1", "h8"); 
            TestMove("e1", "h8"); 
            TestMove("g1", "a7"); 
            TestMove("b1", "a3"); 
            TestMove("f1", "a4");
        }            //{0}-{1} - значения для вывода

        public static void TestMove(string from, string to) 
        {
            Console.WriteLine("{0}-{1} => {2}", from, to, IsCorrectMove(from, to)); //{2} - значение TRUE или FALSE берётся из метода IsCorrectMove
        }                              //{0} - from ; {1} - to

        public static bool IsCorrectMove(string from, string to)
        {
            var dx = Math.Abs(to[0] - from[0]); //смещение фигуры по горизонтали
            var dy = Math.Abs(to[1] - from[1]); //смещение фигуры по вертикали
            return ((dx == 0) || (dy == 0)) ^ (dx == dy); //возвращает TRUE если первое значение TRUE не проверяя второе или(^) возвращает равенство значений
        } //при равенстве ход не был совершён поэтому возвращает FALSE
    }
}