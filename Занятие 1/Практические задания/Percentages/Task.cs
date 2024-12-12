using System;

namespace Progra
{
  class Program
  {
    static void Main(string[] args)
      {
      Console.WriteLine(Calculate(Console.ReadLine()));
      Console.ReadLine();
      }
    public static string Calculate(string userInput)
    {
    var initialMoney = double.Parse(userInput.Split()[0]);
    var yearlyPercent = double.Parse(userInput.Split()[1]);
    var monthsCount = int.Parse(userInput.Split()[2]);
    return "\n"+Convert.ToString(initialMoney * Math.Pow((1 + yearlyPercent / 100), monthsCount));
    }
  }
}
