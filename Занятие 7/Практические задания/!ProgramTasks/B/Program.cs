namespace B
{
    internal class Program
    {
        public static void Main()
        {
            var ints = new[] { 1, 2 };
            var strings = new[] { "A", "B" };

            Print(Combine(ints, ints));
            Print(Combine(ints, ints, ints));
            Print(Combine(ints));
            Print(Combine());
            Print(Combine(strings, strings));
            Print(Combine(ints, strings));
        }

        static Array Combine(params Array[] arrays) {
            if (arrays.Length == 0) return null;

            Type elementType = arrays[0].GetType().GetElementType();

            foreach (var array in arrays) {
                if (array.GetType().GetElementType() != elementType) {
                    return null;
                }
            }

            int totalLength = 0;

            foreach (var array in arrays) {
                totalLength += array.Length;
            }

            Array resultArray = Array.CreateInstance(elementType, totalLength);
            int offset = 0;

            foreach (var array in arrays) {
                array.CopyTo(resultArray, offset);
                offset += array.Length;
            }
            return resultArray;
        }

        static void Print(Array array)
        {
            if (array == null)
            {
                Console.WriteLine("null");
                return;
            }
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0} ", array.GetValue(i));
            Console.WriteLine();
        }
    }
}