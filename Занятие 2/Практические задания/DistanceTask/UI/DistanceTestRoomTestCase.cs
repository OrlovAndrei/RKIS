using System;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using DistanceTask.TestCases;
using Pen = Avalonia.Media.Pen;

namespace DistanceTask.UI;

internal class DistanceTestRoomTestCase : TestCase
{
    private readonly Point a, b, x;
    private readonly double distance;
    private double answer;

    public DistanceTestRoomTestCase(Point a, Point b, Point x, double distance) : base($"d(x, AB) = {distance:0.00}")
    {
        this.a = a;
        this.b = b;
        this.x = x;
        this.distance = distance;
    }

    protected override void InternalVisualize(TestCaseUI ui)
    {
        var neutralPen = new Pen(Brushes.Black);
        var neutralPenThick = new Pen(Brushes.Black)
        {
            Thickness = 2
        };
        var actualAnswerPen = new Pen(Brushes.Red);

        //axis
         ui.Line(-100, 0, 100, 0, neutralPen);
         ui.Line(0, -100, 0, 100, neutralPen);

        ui.Line(a.X, a.Y, b.X, b.Y, neutralPenThick);
        ui.Circle(a.X, a.Y, 2, neutralPenThick);
        ui.Circle(b.X, b.Y, 2, neutralPenThick);
        
        ui.Circle(x.X, x.Y, 5, neutralPenThick);
        ui.Circle(x.X, x.Y, answer, actualAnswerPen, new AvaloniaList<double> { 4, 4 });
        ui.Log("A = " + a);
        ui.Log("B = " + b);
        ui.Log("X = " + x);
        ui.Log("Expected distance " + distance);
        ui.Log($"Calculated distance: {answer}");
    }

    protected override bool InternalRun()
    {
        answer = DistanceTask.GetDistanceToSegment(a.X, a.Y, b.X, b.Y, x.X, x.Y);
        return Math.Abs(answer - distance) < 1e-3;
    }

    public DistanceTestRoomTestCase Rotate(double angle)
    {
        return new DistanceTestRoomTestCase(Rotate(a, angle), Rotate(b, angle), Rotate(x, angle), distance);
    }

    private static Point Rotate(Point p, double a)
    {
        return new Point((float) (Math.Cos(a) * p.X - Math.Sin(a) * p.Y),
            (float) (Math.Sin(a) * p.X + Math.Cos(a) * p.Y));
    }

    public DistanceTestRoomTestCase Shift(Size shift)
    {
        return new DistanceTestRoomTestCase(a + shift, b + shift, x + shift, distance);
    }
}