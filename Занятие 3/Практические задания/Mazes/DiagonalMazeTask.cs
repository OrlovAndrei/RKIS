namespace Mazes;

public static class DiagonalMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        MoveDiagonally(robot, width - 2, height - 2);
    }

    private static void MoveDiagonally(Robot robot, int width, int height)
    {
        for (int i = 0; i < width; i++)
        {
            robot.MoveTo(Direction.Right);
            robot.MoveTo(Direction.Down);
        }

        // Если ширина больше высоты, переместить вниз оставшиеся
        for (int i = 0; i < height - width; i++)
        {
            robot.MoveTo(Direction.Down);
        }
    }
}
