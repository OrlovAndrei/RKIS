using System.Collections.Generic;

namespace StructBenchmarking;

public static class Constants
{
	public const int ArraySize = 10000;
	public static IReadOnlyCollection<int> FieldCounts;

	static Constants()
	{
		var fc = new List<int>();
		for (var i = 16; i <= 512; i *= 2)
			fc.Add(i);
		FieldCounts = fc.AsReadOnly();
	}
}