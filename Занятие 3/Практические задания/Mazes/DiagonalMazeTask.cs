namespace Mazes;

public static class DiagonalMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        if (height > width)
        {
            MoveY(robot, width, height);
        }
        else
            MoveX(robot, width, height);
    }

    public static void MoveY(Robot robot, int width, int height)
    {
        while (robot.Finished == false)
        {
            for (int i = 0; i < (height - 3) / (width - 3 + 1); i++)
            {
                robot.MoveTo(Direction.Down);
            }
            if (robot.Finished == false)
                robot.MoveTo(Direction.Right);
        }
    }

    public static void MoveX(Robot robot, int width, int height)
    {
        while (robot.Finished == false)
        {
            for (int i = 0; i < (width - 3) / (height - 3 + 1); i++)
            {
                robot.MoveTo(Direction.Right);
            }
            if (robot.Finished == false)
                robot.MoveTo(Direction.Down);
        }
    }
}