namespace Passwords;

public class CaseAlternatorTask
{

    public static List<string> AlternateCharCases(string lowercaseWord)
    {
        var result = new List<string>();
        AlternateCharCases(lowercaseWord.ToCharArray(), 0, result);
        return result.OrderBy(s => s).Distinct().ToList();
    }

    static void AlternateCharCases(char[] word, int startIndex, List<string> result)
    {
        if (startIndex == word.Length)
        {
            result.Add(new string(word));
            return;
        }

        if (char.IsLetter(word[startIndex]))
        {
            AlternateCharCases(word, startIndex + 1, result);

            char originalChar = word[startIndex];
            word[startIndex] = char.ToUpper(originalChar);
            AlternateCharCases(word, startIndex + 1, result);
            word[startIndex] = originalChar;
        }
        else
        {
            AlternateCharCases(word, startIndex + 1, result);
        }
    }
}