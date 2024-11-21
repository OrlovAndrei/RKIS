namespace Mazes;

public static class DiagonalMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        if (width > height)
        {
            var steps = (width - 2) / (height - 2);
            MoveRightDownUntilFinish(robot, steps);
        }
        else
        {
            var steps = (height - 2) / (width - 2);
            MoveDownRightUntilFinish(robot, steps);
        }
    }

    private static void MoveDownRightUntilFinish(Robot robot, int steps)
    {
        while (!robot.Finished)
        {
            Move(robot, Direction.Down, steps);
            Move(robot, Direction.Right);
        }
    }

    private static void MoveRightDownUntilFinish(Robot robot, int steps)
    {
        while (!robot.Finished)
        {
            Move(robot, Direction.Right, steps);
            Move(robot, Direction.Down);
        }
    }

    private static void Move(Robot robot, Direction direction, int steps)
    {
        for (var robotStep = 0; robotStep < steps; robotStep++)
        {
            Move(robot, direction);
        }
    }

    private static void Move(Robot robot, Direction direction)
    {
        if (!robot.Finished)
        {
            robot.MoveTo(direction);
        }
    }
}
