namespace Pluralize;

public static class PluralizeTask
{
    public static string PluralizeRubles(int count)
    {
        int lastTwoDigit = count % 100;
        int lastDigit = count % 10;

        if (lastDigit == 1 && lastTwoDigit != 11) return "рубль";
        else if ((lastDigit >= 2 && lastDigit <= 4) && (lastTwoDigit < 12 || lastTwoDigit > 14)) return "рубля";
        else return "рублей";
    }
}