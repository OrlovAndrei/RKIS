namespace Mazes;

public static class SnakeMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        MoveRight(robot, width - 2);
        MoveDown(robot);
        for (int i = 1; i < height - 2; i++)
        {
            MoveHorizontally(robot, i % 2 == 0);
            MoveDown(robot);
        }
        MoveToExit(robot);
    }

    private static void MoveRight(Robot robot, int steps)
    {
        for (int i = 0; i < steps; i++)
        {
            robot.MoveTo(Direction.Right);
        }
    }

    private static void MoveDown(Robot robot)
    {
        robot.MoveTo(Direction.Down);
    }

    private static void MoveHorizontally(Robot robot, bool toRight)
    {
        int steps = robot.GetWidth() - 2; // Убедитесь, что Вы получаете ширину корректно
        for (int i = 0; i < steps; i++)
        {
            if (toRight)
                robot.MoveTo(Direction.Right);
            else
                robot.MoveTo(Direction.Left);
        }
    }

    private static void MoveToExit(Robot robot)
    {
        for (int i = 0; i < robot.GetHeight() - 2; i++)
            robot.MoveTo(Direction.Down);
    }
}
