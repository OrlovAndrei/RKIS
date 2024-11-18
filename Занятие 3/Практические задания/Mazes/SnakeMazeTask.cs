namespace Mazes;

public static class SnakeMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        bool moveRight = true;
        while (!robot.Finished)
        {
            MoveHorizontally(robot, width - 3, moveRight);
            if (!robot.Finished)
                MoveDown(robot, 2);
            moveRight = !moveRight; // Меняем направление для следующей линии
        }
    }

    private static void MoveHorizontally(Robot robot, int steps, bool toRight)
    {
        for (int i = 0; i < steps; i++)
            robot.MoveTo(toRight ? Direction.Right : Direction.Left);
    }

    private static void MoveDown(Robot robot, int steps)
    {
        for (int i = 0; i < steps; i++)
            robot.MoveTo(Direction.Down);
    }
}