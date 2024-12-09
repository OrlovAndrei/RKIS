namespace Passwords;

public class CaseAlternatorTask
{
	//Тесты будут вызывать этот метод
	public static List<string> AlternateCharCases(string lowercaseWord)
	{
		var result = new List<string>();
		AlternateCharCases(lowercaseWord.ToCharArray(), 0, result);
		return result;
	}

	static void AlternateCharCases(char[] word, int startIndex, List<string> result)
	{
		// TODO
		result.Add(new string (word));
	}
}