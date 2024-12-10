﻿using System.Drawing.Drawing2D;

namespace Mazes;

public static class SnakeMazeTask
{
    public static void MoveOut(Robot robot, int width, int height)
    {
        var s = width - 3;
        while (true)
        {
            MoveRight(robot, s);
            MoveDown(robot);
            MoveLeft(robot, s);   
            if (robot.Finished)
                break;
            MoveDown(robot);
        }
    }
    public static void MoveDown(Robot robot)
    {
        for (var i = 0; i < 2; i++)
            robot.MoveTo(Direction.Down);
    }
    public static void MoveLeft(Robot robot, int steps)
    {
        for (var i = 0; i < steps; i++)
            robot.MoveTo(Direction.Left);
    }
    public static void MoveRight(Robot robot, int steps)
    {
        for (var i = 0; i < steps; i++)
            robot.MoveTo(Direction.Right);
    }
}