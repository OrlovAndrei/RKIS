using System;

class Percentages
{
    public static double Calculate(string userInput)
    {
        double InitialAmount = double.Parse(userInput.Split(' ')[0]);
        double Bet = double.Parse(userInput.Split(' ')[1]) / 100;
        int Months = int.Parse(userInput.Split(' ')[2]);

        for (int i = 1; i <= Months; i++)
        {
            InitialAmount += InitialAmount * Bet / 12;
        }
        return InitialAmount;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("¬ведите исходную сумму, процентную ставку (в процентах) и срок вклада в мес€цах (через пробел): ");
        string UserInput = Console.ReadLine();
        Console.WriteLine(Calculate(UserInput));

    }
}