using System;
using Avalonia.Media;
using Billiards.TestCases;

namespace Billiards.UI;

public class BilliardTestCase : TestCase
{
    private readonly double expectedFinalDirection;
    private readonly double initialDirection;
    private readonly double wallInclination;
    private double angle;

    public BilliardTestCase(double initialDirection, double wallInclination, double expectedFinalDirection)
        : base("")
    {
        this.wallInclination = wallInclination * Math.PI / 180;
        this.initialDirection = initialDirection * Math.PI / 180;
        this.expectedFinalDirection = expectedFinalDirection * Math.PI / 180;
    }

    protected override void InternalVisualize(TestCaseUI ui)
    {
        ui.Log("Wall inclination: " + ToGradus(wallInclination));
        ui.Log("Direction: " + ToGradus(initialDirection));
        ui.Line(-100 * Math.Cos(wallInclination), 100 * Math.Sin(wallInclination), 100 * Math.Cos(wallInclination),
            -100 * Math.Sin(wallInclination), new Pen(Brushes.Black));
        ui.Line(-50 * Math.Cos(initialDirection), 50 * Math.Sin(initialDirection), 0, 0, new Pen(Brushes.Red, 3));
        ui.Line(50 * Math.Cos(angle), -50 * Math.Sin(angle), 0, 0,
            new Pen(Brushes.Red, 3) {DashStyle = DashStyle.Dash});
        ui.Line(50 * Math.Cos(expectedFinalDirection), -50 * Math.Sin(expectedFinalDirection), 0, 0,
            new Pen(Brushes.Green) {DashStyle = DashStyle.Dash});
    }

    protected override bool InternalRun()
    {
        angle = BilliardsTask.BounceWall(initialDirection, wallInclination);
        var diff = angle - expectedFinalDirection;
        while (diff < -Math.PI) diff += 2 * Math.PI;
        while (diff > Math.PI) diff -= 2 * Math.PI;
        return Math.Abs(diff) < 0.001;
    }

    private static string ToGradus(double radians)
    {
        return radians * 180 / Math.PI + "°";
    }
}