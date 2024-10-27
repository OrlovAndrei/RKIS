namespace Pluralize;

public static class PluralizeTask
{
	public static string PluralizeRubles(int count)
	{
        if ((count % 100 > 10 && count % 100 < 20) || (count % 10 > 4 && count % 10 < 10) || count % 10 == 0)
            return "рублей";
        return count % 10 == 1 ? "рубль" : "рубля";
    }
}
