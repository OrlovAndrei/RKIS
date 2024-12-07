namespace Passwords;

public class CaseAlternatorChecker
{
	static readonly Random random = new(123132);

	public static void Main()
	{
		try
		{
			Check("cat", 8);
			Check("", 1);
			Check("a", 2);
			Check("ab", 4);
			Check("ab!", 4);
			Check("!ab", 4);
			Check("!a!b!", 4);
			Check("a!b", 4);
			Check("3141592", 1);
			Check("42ndfloor");
			Check("при4вет", 1 << 6);
			Check(GenerateWord(3));
			Check(GenerateWord(4));
			Check(GenerateWord(5));
			Check(GenerateWord(10));
			Check(GenerateWord(15));
			Check("straße", 32); // see https://unicode.org/faq/casemap_charprop.html#11
			Check(GenerateStrangeWord(5));
			Check(GenerateStrangeWord(5));
			Check(GenerateStrangeWord(5));
			Check(GenerateStrangeWord(5));
			Check("ⅲ ⅳ ⅷ", 1); // see https://en.wikipedia.org/wiki/Numerals_in_Unicode#Roman_numerals
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
			return;
		}
	}

	private static string GenerateWord(int len)
	{
		var abc = "qwertyuiopasdfghjklzxcvbnm0987654321-!!@#$%^&*() ";
		var letters = Enumerable.Repeat(0, len).Select(i => abc[random.Next(abc.Length)]);
		return new string(letters.ToArray());
	}
        
	private static string GenerateStrangeWord(int len)
	{
		var abc = "אבגדהוזחטיךכלםמןנסעףפץצקרשת"; // see https://www.compart.com/en/unicode/block/U+0590
		var letters = Enumerable.Repeat(0, len).Select(i => abc[random.Next(abc.Length)]);
		return new string(letters.ToArray());
	}

	private static void Check(string password, int expectedCount = -1)
	{
		try
		{
			if (expectedCount == -1)
				expectedCount = 1 << password.Count(c => c >= 'a' && c <= 'z');
			var actual = CaseAlternatorTask.AlternateCharCases(password);
			var duplicateGroup = actual.GroupBy(a => a).FirstOrDefault(g => g.Count() > 1);
			if (duplicateGroup != null)
				throw new AssertionException("word {0} repeated {1} times in result", duplicateGroup.Key, duplicateGroup.Count());
			for (var i = 0; i < actual.Count-1; i++)
			{
				if (string.CompareOrdinal(actual[i], actual[i+1]) <= 0)
					throw new AssertionException("word {0} should be after {1} in result", actual[i], actual[i+1]);
			}
			if (actual.Count != expectedCount)
				throw new AssertionException("Expected {0} combinations, but found {1}", expectedCount, actual.Count);
		}
		catch (AssertionException e)
		{
			throw new AssertionException("Error on: {0} \n{1}", password.FormatIfEmpty(), e.Message);
		}
	}
}