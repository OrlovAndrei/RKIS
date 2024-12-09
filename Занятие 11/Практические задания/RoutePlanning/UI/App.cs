using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using RoutePlanning.TestCases;

namespace RoutePlanning.UI;

public partial class App
{
	private IEnumerable<TestCase> TestCases => CreateTestCases();

	private static IEnumerable<TestCase> CreateTestCases()
	{
		for (var i = 1; i < 4; i++)
			foreach (var testCase in CreateTestCasesForDifficulty(i))
				yield return testCase;

		// Большие тесты. Реализуйте отсечение перебора, чтобы они проходили быстро
		// foreach (var testCase in CreateTestCasesForDifficulty(4, false))
		// 	yield return testCase;
	}

	private static IEnumerable<TestCase> CreateTestCasesForDifficulty(int difficulty, bool pathsMustMatch = true)
	{
		foreach (var testFile in Directory.GetFiles("tests", difficulty + "-*.txt"))
		{
			var lines = File.ReadAllLines(testFile);
			var answer = double.Parse(lines.First(), CultureInfo.InvariantCulture);
			var checkpoints = lines.Skip(1).Select(line => line.Split().Select(int.Parse).ToArray())
				.Select(cs => new Point(cs[0], cs[1])).ToArray();
			var testName = Path.GetFileNameWithoutExtension(testFile);

			yield return new RouteTestCase(checkpoints, answer, testName, pathsMustMatch);
		}
	}
}