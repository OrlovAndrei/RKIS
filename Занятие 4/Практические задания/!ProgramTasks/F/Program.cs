namespace F
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CheckFirstElement(null));
            Console.WriteLine(CheckFirstElement(new int[0]));
            Console.WriteLine(CheckFirstElement(new[] { 1 }));
            Console.WriteLine(CheckFirstElement(new[] { 0 }));
        }

        public static bool CheckFirstElement(int[] array)
        {
            return array != null && array.Length != 0 && array[0] == 0;
        }
    }
}
