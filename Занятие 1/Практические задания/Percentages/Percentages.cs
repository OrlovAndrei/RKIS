using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите исходную сумму, процентную ставку и срок вклада через пробел:");
        string input = Console.ReadLine();
        double result = Calculate(input);
        Console.WriteLine($"Накопленная сумма: {result}");
    }

    public static double Calculate(string input)
    {
        string[] parts = input.Split(' ');
        double sum = double.Parse(parts[0]);
        double rate = double.Parse(parts[1]) / 100 / 12;
        int months = int.Parse(parts[2]);

        return sum * Math.Pow(1 + rate, months);
    }
}