namespace Pluralize;

public static class PluralizeTask
{
	public static string PluralizeRubles(int count)
	{
		// Напишите функцию склонения слова "рублей" в зависимости от предшествующего числительного count.
		return "руб.";
	}
}
 public static class PluralizeTask
    {
        public static string PluralizeRubles(int count)
        {
            if (count % 100 >= 11 && count % 100 <= 14)
                return "рублей";

            int lastDigit = count % 10;
            if (lastDigit == 1)
                return "рубль";
            else if (lastDigit >= 2 && lastDigit <= 4)
                return "рубля";
            else
                return "рублей";
        }
    }
}
