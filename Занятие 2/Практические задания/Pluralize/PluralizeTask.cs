namespace Pluralize;

public static string PluralizeRubles(int count)
    {     
        if (count % 100 > 10 && count % 100 < 20)
            return "рублей";
        if(count % 10 > 4 && count % 10 < 10)
            return "рублей";
        if(count == 0 || count % 10 == 0)
            return "рублей";
        return count % 10 == 1 ? "рубль" : "рубля";
