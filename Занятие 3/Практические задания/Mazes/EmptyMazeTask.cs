namespace Mazes;

public static class EmptyMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        MoveRight(robot, width - 3);
        MoveDown(robot, height - 3);
    }

    private static void MoveRight(Robot robot, int steps)
    {
        for (int i = 0; i < steps; i++)
            robot.MoveTo(Direction.Right);
    }

    private static void MoveDown(Robot robot, int steps)
    {
        for (int i = 0; i < steps; i++)
            robot.MoveTo(Direction.Down);
    }
}