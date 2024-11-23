namespace F
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CheckFirstElement(null));           // False
            Console.WriteLine(CheckFirstElement(new int[0]));    // False
            Console.WriteLine(CheckFirstElement(new[] { 1 }));    // False
            Console.WriteLine(CheckFirstElement(new[] { 0 }));    // True
        }

        public static bool CheckFirstElement(int[] array)
        {
            return array != null && array.Length != 0 && array[0] == 0;
        }
    }
}
