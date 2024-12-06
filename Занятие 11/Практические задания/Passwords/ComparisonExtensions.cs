namespace Passwords;

public static class ComparisonExtensions
{
	public static string FormatIfEmpty(this string s)
	{
		if (!string.IsNullOrWhiteSpace(s) && s.Trim() == s) return s;
		return s switch
		{
			null => "<null>",
			"" => "<empty string>",
			_ => "[" + s + "]"
		};
	}
}