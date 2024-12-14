namespace Passwords;

public class CaseAlternatorTask
{
    public static List<string> AlternateCharCases(string lowercaseWord)
    {
        var result = new List<string>();
        var permutation = new char[lowercaseWord.Length];
        var combination = new bool[lowercaseWord.Length];
        for (int i = 0; i < lowercaseWord.Length; i++)
            combination[i] = false;
        AlternateCharCases(lowercaseWord.ToCharArray(), 0, result, combination);
        return result;
    }

    static void AlternateCharCases(char[] word, int startIndex, List<string> result, bool[] combination)
    {
        if (startIndex == word.Length)
        {
            var s = new StringBuilder();
            bool cantUp = false;
            for (int i = 0; i < word.Length; i++)
                if (combination[i])
                {
                    char up = char.ToUpper(word[i]);
                    s.Append(up);
                    if (up == word[i]) cantUp = true;
                }
                else s.Append(word[i]);
            if (!cantUp) result.Add(s.ToString());
            return;
        }
        combination[startIndex] = false;
        AlternateCharCases(word, startIndex + 1, result, combination);
        if (char.IsLetter(word[startIndex]))
        {
            combination[startIndex] = true;
            AlternateCharCases(word, startIndex + 1, result, combination);
        }
    }
}