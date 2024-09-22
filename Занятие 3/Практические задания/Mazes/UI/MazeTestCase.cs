using System;
using System.IO;
using Avalonia;
using Avalonia.Media;
using Mazes.TestCases;
using Path = System.IO.Path;

namespace Mazes.UI;

internal class MazeTestCase : TestCase
{
    private readonly int cellSize;
    private readonly Maze maze;
    private readonly Action<Robot, int, int> solve;
    private Robot robot;

    private static readonly Pen ActualAnswerPen = new(Brushes.Red, 2f);

    private static readonly Pen ExpectedAnswerPen = new(Brushes.Green, 1f)
    {
        DashStyle = DashStyle.Dash
    };

    private static readonly Pen NeutralPen = new(Brushes.Black, 2f);

    public MazeTestCase(string name, Action<Robot, int, int> solve)
        : base(name)
    {
        maze = new Maze(File.ReadAllLines(Path.Combine("mazes", name + ".txt")));
        cellSize = 200 / Math.Max((int)maze.Size.Width, (int)maze.Size.Height);
        this.solve = solve;
    }

    protected override void InternalVisualize(TestCaseUI ui)
    {
        for (var x = 0; x < maze.Size.Width; x++)
        for (var y = 0; y < maze.Size.Height; y++)
            if (maze.IsWall(new Point(x, y)))
                DrawWall(ui, x, y);
        var last = maze.Robot;
        foreach (var cur in robot.Path)
        {
            ui.Line(Conv(last.X), Conv(last.Y), Conv(cur.X), Conv(cur.Y), ActualAnswerPen);
            last = cur;
        }

        ui.Circle(Conv(robot.X), Conv(robot.Y), cellSize / 3.1, ActualAnswerPen);
        ui.Circle(Conv(maze.Exit.X), Conv(maze.Exit.Y), cellSize / 2.5, ExpectedAnswerPen);
    }

    private double Conv(double coord)
    {
        return coord * cellSize - 100 + cellSize / 2.0;
    }

    private void DrawWall(TestCaseUI ui, int x, int y)
    {
        var x1 = x * cellSize - 100;
        var y1 = y * cellSize - 100;
        var x2 = (x + 1) * cellSize - 101;
        var y2 = (y + 1) * cellSize - 101;
        ui.Rect(new Point(x1, y1), new Size(cellSize, cellSize), NeutralPen);
        ui.Line(x1 + 1, y1 + 1, x2, y2, NeutralPen);
        ui.Line(x1 + 1, y2, x2, y1 + 1, NeutralPen);
    }

    protected override bool InternalRun()
    {
        robot = new Robot(maze);
        solve(robot, (int)maze.Size.Width, (int)maze.Size.Height);
        return robot.Finished;
    }
}