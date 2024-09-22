using System;
using System.Collections.Generic;
using System.Linq;
using AngryBirds.TestCases;
using Avalonia.Media;

namespace AngryBirds.UI;

public class AngryBirdsTestCase : TestCase
{
    private readonly double distance;
    private readonly bool hasSolution;
    private readonly IList<Tuple<double, double>> trajectory = new List<Tuple<double, double>>();
    private readonly double v;
    private double angle;
    private double time;

    public AngryBirdsTestCase(double v, double distance, bool hasSolution = true) : base("Artillery")
    {
        this.v = v;
        this.distance = distance;
        this.hasSolution = hasSolution;
    }

    protected override void InternalVisualize(TestCaseUI ui)
    {
        ui.Log("D = " + distance);
        ui.Log("V = " + v);
        // Горизонт
        ui.Line(-100, 0, 100, 0, new Pen(Brushes.Black, 3));
        // Цель
        ui.Circle(50, 0, 2, new Pen(Brushes.Blue));
        if (LastException == null)
        {
            //Траектория
            foreach (var dot in trajectory.Where((_, i) => i % 10 == 0))
                ui.Dot(-50 + dot.Item1 * 100 / distance, -dot.Item2 * 100 / distance, Brushes.Red);
            ui.Circle(-50, 0, 1.7, new Pen(Brushes.Black, 4));

            if (trajectory.Any())
            {
                // Пушка
                ui.Line(-50, 0, -50 + 10 * Math.Cos(angle), -10 * Math.Sin(angle), new Pen(Brushes.Black, 3));
                ui.Log("Угол прицеливания: " + 180 * angle / Math.PI + "°");
                ui.Log("Высота над целью = " + trajectory.Last().Item2);
                ui.Log("Время снаряда в полете = " + time);
            }
        }
    }

    protected override bool InternalRun()
    {
        time = 0;
        trajectory.Clear();
        angle = AngryBirdsTask.FindSightAngle(v, distance);
        if (double.IsInfinity(angle)) return false;
        if (double.IsNaN(angle)) return !hasSolution;
        double x = 0;
        double y = 0;
        trajectory.Add(Tuple.Create(x, y));
        var vx = v * Math.Cos(angle);
        var dt = distance / v / 1000;
        var g = 9.8;
        var vy = v * Math.Sin(angle);
        if (vx < 0.00001) return false;
        while (x < distance)
        {
            time += dt;
            vy -= g * dt;
            x += vx * dt;
            y += vy * dt;
            trajectory.Add(Tuple.Create(x, y));
        }

        return Math.Abs(y) <= distance / 100;
    }
}