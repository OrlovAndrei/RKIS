namespace Pluralize;

public static class PluralizeTask
{
    public static string PluralizeRubles(int count)
    {
        int lastTwoDigits = count % 100;
        int lastDigit = count % 10;

        if (lastTwoDigits >= 11 && lastTwoDigits <= 14)
            return "рублей";

        if (lastDigit == 1)
            return "рубль";

        if (lastDigit >= 2 && lastDigit <= 4)
            return "рубля";

        return "рублей";
    }
}