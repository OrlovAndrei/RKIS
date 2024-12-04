using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите исходную сумму, процентную ставку и срок вклада в месяцах через пробел:");
        string input = Console.ReadLine();

        decimal finalAmount = Calculate(input);
        Console.WriteLine($"Накопившаяся сумма: {Math.Round(finalAmount)}");
    }

    static decimal Calculate(string input)
    {
        string[] parts = input.Split(' ');
        decimal principal = decimal.Parse(parts[0]);
        decimal annualRate = decimal.Parse(parts[1]);
        int months = int.Parse(parts[2]);

        decimal monthlyRate = annualRate / 12 / 100;

        return CalculateAmount(principal, monthlyRate, months);
    }

    static decimal CalculateAmount(decimal amount, decimal monthlyRate, int months)
    {
        if (months == 0)
        {
            return amount;
        }

        amount += amount * monthlyRate;

        return CalculateAmount(amount, monthlyRate, months - 1);
    }
}
