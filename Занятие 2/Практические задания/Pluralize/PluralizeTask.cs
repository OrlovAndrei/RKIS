namespace Pluralize;

public static class PluralizeTask
{
    public static string PluralizeRubles(int count)
    {
        int numberRemainders10 = count % 10;
        int numberRemainders100 = count % 100;
        if (numberRemainders10 == 1 && numberRemainders100 != 11) return "рубль";
        else if (numberRemainders10 >= 2 && numberRemainders10 <= 4 && numberRemainders100 != 12 && numberRemainders100 != 13 && numberRemainders100 != 14) return "руб.";
        return "руб.";
        else return "рублей";

    }
}