using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using DistanceTask.TestCases;

namespace DistanceTask.UI;

public partial class App
{
    private IEnumerable<TestCase> TestCases => CreateTestCases();

    private static IEnumerable<TestCase> CreateTestCases()
    {
        var allCases = OutsideSegment(30).Concat(OnSegment(30)).ToList();

        var angles = new[] { 0, Math.PI / 3, Math.PI / 6 };


        var allCombinations =
            from i in Enumerable.Range(0, 3)
            from a in angles
            from shift in new[] { new Size(0, 0), new Size(50, 20), new Size(-20, 10) }
            from t in allCases
            select t.Shift(shift).Rotate(a + i * Math.PI / 2);
        return Dot(30).Concat(allCombinations);
    }

    private static IEnumerable<DistanceTestRoomTestCase> Dot(int d)
    {
        yield return new DistanceTestRoomTestCase(new Point(d, d), new Point(d, d), new Point(0, 0),
            d * Math.Sqrt(2));
        yield return new DistanceTestRoomTestCase(new Point(d, d), new Point(d, d), new Point(d, d), 0);
    }

    private static IEnumerable<DistanceTestRoomTestCase> OnSegment(int d)
    {
        yield return new DistanceTestRoomTestCase(new Point(-d, 0), new Point(d, 0), new Point(-d, 0), 0);
        yield return new DistanceTestRoomTestCase(new Point(-d, 0), new Point(d, 0), new Point(-d / 2, 0), 0);
        yield return new DistanceTestRoomTestCase(new Point(-d, 0), new Point(d, 0), new Point(d / 2, 0), 0);
        yield return new DistanceTestRoomTestCase(new Point(-d, 0), new Point(d, 0), new Point(d, 0), 0);
    }

    private static IEnumerable<DistanceTestRoomTestCase> OutsideSegment(int d)
    {
        yield return new DistanceTestRoomTestCase(new Point(-d, 0), new Point(d, 0), new Point(-d, d), d);
        yield return new DistanceTestRoomTestCase(new Point(-d, 0), new Point(d, 0), new Point(0, d), d);
        yield return new DistanceTestRoomTestCase(new Point(-d, 0), new Point(d, 0), new Point(d, d), d);
        yield return new DistanceTestRoomTestCase(new Point(-d, 0), new Point(d, 0), new Point(2 * d, d),
            d * Math.Sqrt(2));
        yield return new DistanceTestRoomTestCase(new Point(-d, 0), new Point(d, 0), new Point(2 * d, 0), d);
        yield return new DistanceTestRoomTestCase(new Point(-d, 0), new Point(d, 0), new Point(d, -d), d);
        yield return new DistanceTestRoomTestCase(new Point(-d, 0), new Point(d, 0), new Point(0, -d), d);
        yield return new DistanceTestRoomTestCase(new Point(-d, 0), new Point(d, 0), new Point(-d, -d), d);
        yield return new DistanceTestRoomTestCase(new Point(-d, 0), new Point(d, 0), new Point(-2 * d, 0), d);
        yield return new DistanceTestRoomTestCase(new Point(-d, 0), new Point(d, 0), new Point(-2 * d, d),
            d * Math.Sqrt(2));
    }
}