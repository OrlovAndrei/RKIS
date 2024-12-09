using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using RoutePlanning.TestCases;

namespace RoutePlanning.UI;

internal class RouteTestCase : TestCase
{
	private readonly Point[] checkpoints;
	private readonly double expectedAnswer;
	private readonly string testName;
	private readonly bool mustMatch;

	private int[] order;
	private bool isPassed;
	private Stopwatch sw;


	public RouteTestCase(Point[] checkpoints, double expectedAnswer, string testName, bool mustMatch) : base(testName)
	{
		this.checkpoints = checkpoints;
		this.expectedAnswer = expectedAnswer;
		this.testName = testName;
		this.mustMatch = mustMatch;
	}

	protected override void InternalVisualize(TestCaseUI ui)
	{
		var minX = checkpoints.Min(p => p.X);
		var maxX = checkpoints.Max(p => p.X);
		var minY = checkpoints.Min(p => p.Y);
		var maxY = checkpoints.Max(p => p.Y);
		const int margin = 10;
		var scaleX = (400 - 2f * margin) / (maxX - minX + 1f);
		var scaleY = (400 - 2f * margin) / (maxY - minY + 1f);
		var scale = Math.Min(scaleX, scaleY);

		var pts = order.Select(i => checkpoints[i])
			.Select(p => new PointF(margin + (p.X - minX) * scale, margin + (p.Y - minY) * scale)).ToArray();

		var startPoint = pts.First();
		var darkRedPen = new Avalonia.Media.Pen(Avalonia.Media.Brushes.DarkRed);
		var redPen = new Avalonia.Media.Pen(Avalonia.Media.Brushes.Red);
		foreach (var endPoint in pts.Skip(1))
		{
			ui.Line(startPoint.X, startPoint.Y, endPoint.X, endPoint.Y, darkRedPen);
			startPoint = endPoint;
		}

		foreach (var p in pts)
			ui.Circle(p.X, p.Y, 2, darkRedPen);
		ui.Circle(pts[0].X, pts[0].Y, 4, redPen);

		var len = checkpoints.GetPathLength(order);
		LogTest(ui, testName, checkpoints.Length, len, sw.Elapsed, expectedAnswer, isPassed);

		//Тут можно что-нибудь делать с checkopoints и order
	}

	private static void LogTest(
		TestCaseUI ui,
		string testName,
		int size,
		double pathLen,
		TimeSpan timeSpent,
		double expectedLen,
		bool isPassed)
	{
		var verdict = isPassed ? "success" : "FAILED";
		ui.Log($"{verdict} test {testName} of size {size}");
		ui.Log($"found path len: {pathLen}. Expected len: {expectedLen}");
		if (timeSpent.TotalSeconds > 1)
			ui.Log($"time: {timeSpent.TotalSeconds}");
	}

	protected override bool InternalRun()
	{
		sw = Stopwatch.StartNew();
		order = PathFinderTask.FindBestCheckpointsOrder(checkpoints);
		sw.Stop();
		var len = checkpoints.GetPathLength(order);
		isPassed = IsPassed(len, order, expectedAnswer, checkpoints.Length, mustMatch);
		return isPassed;
	}

	private static bool IsPassed(double len, int[] order, double expectedLen, int size, bool pathsMustMatch)
	{
		return len < expectedLen + 1e-6
		       && (!pathsMustMatch || order.Distinct().OrderBy(x => x).SequenceEqual(Enumerable.Range(0, size)));
	}
}