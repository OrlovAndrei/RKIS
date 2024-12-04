using System;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        Console.WriteLine(Calculate(input));
    }

    static decimal Calculate(string input)
    {
        var parts = input.Split();
        decimal principal = decimal.Parse(parts[0]);
        decimal annualRate = decimal.Parse(parts[1]);
        int months = int.Parse(parts[2]);

        decimal monthlyRate = annualRate / 12 / 100;
        decimal result = principal * (decimal)Math.Pow((double)(1 + monthlyRate), months);

        return Math.Round(result, 0);
    }
}
