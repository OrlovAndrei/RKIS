namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteBoard(8);
            WriteBoard(1);
            WriteBoard(2);
            WriteBoard(3);
            WriteBoard(10);
        }

        private static void WriteBoard(int size)
        {
		for(int row=1; row<=size; row++) 
		{
				for (int i=1; i<=size;i++) 
					Console.Write((row+i)%2==0?"#":".");
				Console.WriteLine();
		}
	Console.WriteLine();
        }
    }
}
