namespace Pluralize;

public static class PluralizeTask
{
	public static string PluralizeRubles(int count)
	{
        // Напишите функцию склонения слова "рублей" в зависимости от предшествующего числительного count.
        if (count / 10 % 10 != 1)
        {
            switch (count % 10)
            {
                case 1: return "рубль";
                case 2: case 3: case 4: return "рубля";
            }
        }
        return "рублей";
    }
}