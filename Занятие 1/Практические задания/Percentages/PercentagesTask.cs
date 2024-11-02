using System;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        double result = Calculate(input);

        Console.WriteLine($"{result}");
    }

    private static double Calculate(string input)
    {

        string[] values = input.Split(' ');
        double initialAmount = double.Parse(values[0]);
        double interestRate = double.Parse(values[1]) / 100.0;
        int termInMonths = int.Parse(values[2]);

        return InitialAmount * Math.Pow((1 + InterestRate / 12.0), TermInMonths);
    }
}