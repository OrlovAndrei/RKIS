using System;
namespace Pluralize
{

    public static class PluralizeTask
    {
        public static string PluralizeRubles(int count)
        {
            int lastDigit = count % 10;
            int lastTwoDigits = count % 100;
            if (lastTwoDigits >= 11 && lastTwoDigits <= 14)
            {
                return $"{count} рублей"; 
            }
            else if (lastDigit == 1)
            {
                return $"{count} рубль"; 
            }
            else if (lastDigit >= 2 && lastDigit <= 4)
            {
                return $"{count} рубля"; 
            }
            else
            {
                return $"{count} рублей";
            }
        }
    }
}