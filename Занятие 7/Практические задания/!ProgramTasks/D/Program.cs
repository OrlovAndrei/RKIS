namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Min(new[] { 3, 6, 2, 4 }));
            Console.WriteLine(Min(new[] { "B", "A", "C", "D" }));
            Console.WriteLine(Min(new[] { '4', '2', '7' }));
        }

        static T Min<T>(T[] array) where T : IComparable<T> {
            T min = array[0];
            foreach (T t in array) {
                if (t.CompareTo(min) < 0)
                    min = t;
            }
            return min;
        }
    } 
}