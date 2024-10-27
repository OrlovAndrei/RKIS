namespace Mazes;

public static class DiagonalMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
         var dir1 = ChooseDir(width, height);
        var dir2 = ChangeDir(dir1);
        var steps1 = StepsOver(width, height);

        while (true)
        {
            DirGo(robot, dir1, steps1);
            if (robot.Finished)
                break;
            DirGo(robot, dir2, 1);
        }
    }
    private static Direction ChangeDir(Direction dir)
    {
        if (dir == Direction.Down)
        {
            return Direction.Right;
        }
        else
        {
            return Direction.Down;
        }
    }
    private static Direction ChooseDir(int width, int height)
    {
        if (width > height)
        {
            return Direction.Right;
        }
        else
        {
            return Direction.Down;
        }
    }
    private static int StepsOver(int width, int height)
    {
        var a = width - 2;
        var b = height - 2;
        return Math.Max(a, b) / Math.Min(a, b);
    }
    private static void DirGo(Robot robot, Direction dir, int steps)
    {
        for (var i = 0; i < steps; i++)
        {
            robot.MoveTo(dir);
        }
    }
}