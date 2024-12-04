internal class Program
{
    static void Main(string[] args)
    {
        Print(GetSquare(42));
    }

    private static int GetSquare(int number) // load... 💥 █
    {
        return number * number;
    }

    private static void Print(int result)
    {
        Console.WriteLine(result);
    }
}