namespace B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dx = Math.Abs(to[0] - from[0]); //смещение фигуры по горизонтали
            var dy = Math.Abs(to[1] - from[1]); //смещение фигуры по вертикали
            ...
            return ((dx == 0) || (dy == 0)) ^ (dx == dy);
        }
    }
}
