using System.Collections.Generic;
using System.Linq;
using Avalonia;

namespace Mazes;

public class Maze
{
    private readonly bool[][] walls;

    public Maze(string[] lines)
    {
        Robot = ParsePoint(lines[0]);
        Exit = ParsePoint(lines[1]);
        walls = ParseWalls(lines.Skip(2));
        Size = new Size(walls.Max(row => row.Length), walls.Length);
    }

    public Point Robot { get; }
    public Point Exit { get; }
    public Size Size { get; }

    private static Point ParsePoint(string s)
    {
        var coords = s.Split(' ').Select(int.Parse).ToArray();
        return new Point(coords[0], coords[1]);
    }

    public bool IsWall(Point pos)
    {
        return walls[(int)pos.Y][(int)pos.X];
    }

    private static bool[][] ParseWalls(IEnumerable<string> lines)
    {
        return lines
            .Select(line => line
                .Select(c => c == '#')
                .ToArray())
            .ToArray();
    }
}