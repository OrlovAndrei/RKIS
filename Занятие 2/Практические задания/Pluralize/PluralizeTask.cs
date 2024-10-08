namespace Pluralize;

public static class PluralizeTask
{
	public static string PluralizeRubles(int count)
	{
    int n = int.Parse(Console.ReadLine());
    string s = "рублей";
    if (n % 10 == 1) s = "рубль";
    if (n % 10 >= 2 && n % 10 <= 4) s = "рубля";
    Console.WriteLine("{0} {1}", n, s);
    Console.ReadKey();
}
		return "руб.";
	}
}
