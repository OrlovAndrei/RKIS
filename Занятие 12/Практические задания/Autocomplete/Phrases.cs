using System;
using System.Collections;
using System.Collections.Generic;

namespace Autocomplete;

public class Phrases : IReadOnlyList<string>
{
	private readonly string[] adjectives;
	private readonly string[] nouns;
	private readonly string[] verbs;

	public Phrases(string[] verbs, string[] adjectives, string[] nouns)
	{
		this.verbs = verbs;
		this.adjectives = adjectives;
		this.nouns = nouns;
	}

	public virtual int Length => verbs.Length * adjectives.Length * nouns.Length;

	
	public virtual string this[int index]
	{
		get
		{
			if (index < 0) throw new IndexOutOfRangeException("index = " + index);
			var ni = index % nouns.Length;
			var ai = index / nouns.Length % adjectives.Length;
			var vi = index / (nouns.Length * adjectives.Length) % verbs.Length;
			return verbs[vi] + " " + adjectives[ai] + " " + nouns[ni];
		}
	}

	public IEnumerator<string> GetEnumerator()
	{
		for (var i = 0; i < Length; i++)
			yield return this[i];
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public int Count => Length;

	public override string ToString()
	{
		return $"Size: {Length}. Verbs: {verbs.Length}, Adjectives: {adjectives.Length}, Nouns: {nouns.Length}";
	}
}