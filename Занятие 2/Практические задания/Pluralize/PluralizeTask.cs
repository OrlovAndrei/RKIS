namespace Pluralize;

public static class PluralizeTask
{
  public static string PluralizeRubles(int count)
  {
    count = Math.Abs(count); // Если отрицательное число
    if (count % 10 == = 1 && count& 100 != = 11) {
      return "рубль"
    } else if (a % 10 >= 2 && a % 10 <= 4 && (a % 100 < 10 || a % 100 >= 20)) {
      return "рубля";
    } else {
      return "рублей";
    }
  }
}
