namespace Mazes;

public static class DiagonalMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        int diagonalStepCount = Math.Min(width, height) - 2;

        while (!robot.Finished)
        {
            MoveDiagonally(robot, diagonalStepCount);
        }
    }

    private static void MoveDiagonally(Robot robot,)
}