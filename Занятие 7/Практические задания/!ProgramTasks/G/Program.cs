namespace G
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var triangle = new Triangle
            {
                A = new Point { X = 0, Y = 0 },
                B = new Point { X = 1, Y = 2 },
                C = new Point { X = 3, Y = 2 }
            };
            Console.WriteLine(triangle.ToString());
            //(0 1) (1 2) (3 2)
        }
    }
}