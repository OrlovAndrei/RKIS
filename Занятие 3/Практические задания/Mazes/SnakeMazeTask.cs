namespace Mazes;

public static class SnakeMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        var stepsToHorizont = width - 3;
        while (true)
        {
            GoToRight(robot, stepsToHorizont);
            GoToDown(robot);
            GoToLeft(robot, stepsToHorizont);
            if (robot.Finished)
                break;
            GoToDown(robot);
        }
    }

    private static void GoToRight(Robot robot, int steps)
    {
        for (var i = 0; i < steps; i++)
            robot.MoveTo(Direction.Right);
    }

    private static void GoToDown(Robot robot)
    {
        for (var i = 0; i < 2; i++)
            robot.MoveTo(Direction.Down);
    }

    private static void GoToLeft(Robot robot, int steps)
    {
        for (var i = 0; i < steps; i++)
            robot.MoveTo(Direction.Left);
    }
}
