namespace Pluralize;

public static class PluralizeTask
{
	public static string PluralizeRubles(int count)
	{
        // Напишите функцию склонения слова "рублей" в зависимости от предшествующего числительного count.
        //0 - рублЕЙ
        //1 - рублЬ
        //2-4 - рублЯ
        //5-20 - рублЕЙ

        //остаток 11-19 5-9 0 
        if ((count % 100 > 10 && count % 100 < 20) || (count % 10 > 4 && count % 10 < 10) || count % 10 == 0)
            return "рублей";

        return count % 10 == 1 ? "рубль" : "рубля"; 
        //если остаток равняется 1, тогда рубль, иначе возвращается значение рубля
	}
}