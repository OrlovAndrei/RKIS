namespace Passwords;

public class CaseAlternatorTask
{
    public static List<string> AlternateCharCases(string lowercaseWord)
    {
        var result = new List<string>();
        AlternateCharCases(lowercaseWord.ToCharArray(), 0, result);
        return result;
    }

    static void AlternateCharCases(char[] word, int startIndex, List<string> result)
    {
        if (startIndex >= word.Length)
        {
            result.Add(new string(word));
            return;
        }
        char currentChar = word[startIndex];
        if (!char.IsLetter(currentChar))
        {
            AlternateCharCases(word, startIndex + 1, result);
            return;
        }
        word[startIndex] = char.ToUpper(currentChar);
        AlternateCharCases(word, startIndex + 1, result);
        word[startIndex] = char.ToLower(currentChar);
        AlternateCharCases(word, startIndex + 1, result);
    }
}