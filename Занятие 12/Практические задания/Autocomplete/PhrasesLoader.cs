using System;
using System.IO;
using System.Linq;

namespace Autocomplete;

public class PhrasesLoader
{
	public static Phrases CreateFromFiles(string directory)
	{
		var verbs = LoadDictionary(directory, "verbs.txt");
		var adjectives = LoadDictionary(directory, "adjectives.txt");
		var nouns = LoadDictionary(directory, "nouns.txt");
		return new Phrases(verbs, adjectives, nouns);
	}

	private static string[] LoadDictionary(string directory, string filename)
	{
		return File.ReadAllLines(Path.Combine(directory, filename))
			.Select(a => a.ToLower())
			.Distinct()
			.OrderBy(a => a, StringComparer.OrdinalIgnoreCase)
			.ToArray();
	}
}