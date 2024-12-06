namespace Mazes;

public static class EmptyMazeTask
{
	public static void MoveOut(Robot robot, int width, int height)
        {
            
           for(int i = 0; i < width-3; i++) 
            {
		   robot.MoveTo(Direction.Right);
	    }
            for (int i = 0; i < height - 3; i++)
            {
		    robot.MoveTo(Direction.Down); 
	    }
	}
}
