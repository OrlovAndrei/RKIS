namespace Pluralize;

public static class PluralizeTask
{
	public static string PluralizeRubles(int count)
	{
		int lastDigit = count % 10;
        int lastTwoDigits = count % 100;

        if (lastDigit == 1 && lastTwoDigits != 11)
        {
            return "рубль";
        }
        else if (lastDigit >= 2 && lastDigit <= 4 && (lastTwoDigits < 12 || lastTwoDigits > 14))
        {
            return "рубля";
        }
        else
        {
            return "рублей";
	}
}