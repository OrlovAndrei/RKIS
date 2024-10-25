namespace B
{
    internal class Program
    {
        static void Main(string[] args)
        {   num1 = +5.5e-2;
            num2 = 7.8f;
            num3 = 0;
            num4 = 2000000000000L;
            double num1 = +5.5e-2;
            float num2 = 7.8f;
            int num3 = 0;
            long num4 = 2000000000000L;
        {
            Console.WriteLine("{0}-{1} {2}", from, to, IsCorrectMove(from, to));
        }

        public static bool IsCorrectMove(string from, string to)
        {
            var dx = Math.Abs(to[0] - from[0]); //смещение фигуры по горизонтали
            var dy = Math.Abs(to[1] - from[1]); //смещение фигуры по вертикали
            ...
        }
    }
}