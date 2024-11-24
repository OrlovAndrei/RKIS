using NUnit.Framework;

namespace TableParser;

[TestFixture]
public class QuotedFieldTaskTests
{
	[TestCase("''", 0, "", 2)]
	[TestCase("'a'", 0, "a", 3)]
	public void Test(string line, int startIndex, string expectedValue, int expectedLength)
	{
		var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
		Assert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
	}

	// Добавьте свои тесты
}

class QuotedFieldTask
{
	public static Token ReadQuotedField(string line, int startIndex)
	{
		return new Token(line, startIndex, line.Length - startIndex);
	}
}