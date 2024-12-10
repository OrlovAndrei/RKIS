using System;
using Avalonia.Input;

namespace Digger;

public class Terrain : ICreature
{
    public string GetImageFileName() => "Terrain.png";

    public int GetDrawingPriority() => 0;

    public CreatureCommand Act(int x, int y)
    {
        return new CreatureCommand { DeltaX = 0, DeltaY = 0, TransformTo = null };
    }

    public bool DeadInConflict(ICreature conflictedObject) => true;
}

public class Player : ICreature
{
    public string GetImageFileName() => "Digger.png";

    public int GetDrawingPriority() => 1;

    public CreatureCommand Act(int x, int y)
    {
        var command = new CreatureCommand { DeltaX = 0, DeltaY = 0, TransformTo = this };

        switch (Game.KeyPressed)
        {
            case System.Windows.Forms.Keys.Up:
                if (y > 0) command.DeltaY = -1;
                break;
            case System.Windows.Forms.Keys.Down:
                if (y < Game.MapHeight - 1) command.DeltaY = 1;
                break;
            case System.Windows.Forms.Keys.Left:
                if (x > 0) command.DeltaX = -1;
                break;
            case System.Windows.Forms.Keys.Right:
                if (x < Game.MapWidth - 1) command.DeltaX = 1;
                break;
        }

        return command;
    }

    public bool DeadInConflict(ICreature conflictedObject)
    {
        return conflictedObject is Monster;
    }
}

public class Sack : ICreature
{
    private int fallDistance = 0; 
    private bool isFalling = false;

    public string GetImageFileName() => "Sack.png";

    public int GetDrawingPriority() => 2;

    public CreatureCommand Act(int x, int y)
    {
        var command = new CreatureCommand { DeltaX = 0, DeltaY = 0, TransformTo = this };

        if (y < Game.MapHeight - 1 && Game.Map[x, y + 1] == null)
        {
            command.DeltaY = 1;
            isFalling = true;
            fallDistance++;
        }
        else
        {
            if (isFalling && fallDistance > 1)
            {
                command.TransformTo = new Gold();
            }
            isFalling = false;
            fallDistance = 0;
        }

        return command;
    }

    public bool DeadInConflict(ICreature conflictedObject)
    {
        return conflictedObject is Player && isFalling;
    }
}


public class Gold : ICreature
{
    public string GetImageFileName() => "Gold.png";

    public int GetDrawingPriority() => 3;

    public CreatureCommand Act(int x, int y)
    {
        return new CreatureCommand { DeltaX = 0, DeltaY = 0, TransformTo = this };
    }

    public bool DeadInConflict(ICreature conflictedObject)
    {
        if (conflictedObject is Player)
        {
            Game.Scores += 10; 
            return true;
        }
        return false;
    }
}

public class Monster : ICreature
{
    public string GetImageFileName() => "Monster.png";

    public int GetDrawingPriority() => 1;

    public CreatureCommand Act(int x, int y)
    {
        var diggerPosition = FindDiggerPosition();
        if (diggerPosition == null)
            return new CreatureCommand { DeltaX = 0, DeltaY = 0, TransformTo = this }; 

        var (diggerX, diggerY) = diggerPosition.Value;
        int deltaX = 0, deltaY = 0;

        if (diggerX > x) deltaX = 1;
        else if (diggerX < x) deltaX = -1;
        else if (diggerY > y) deltaY = 1;
        else if (diggerY < y) deltaY = -1;

        if (!CanMoveTo(x + deltaX, y + deltaY))
            return new CreatureCommand { DeltaX = 0, DeltaY = 0, TransformTo = this }; 

        return new CreatureCommand { DeltaX = deltaX, DeltaY = deltaY, TransformTo = this };
    }

    public bool DeadInConflict(ICreature conflictedObject)
    {
        if (conflictedObject is Sack sack && sack.isFalling)
            return true;

        if (conflictedObject is Monster || conflictedObject is Player)
            return true;

        if (conflictedObject is Gold)
            return true;

        return false;
    }

    private (int, int)? FindDiggerPosition()
    {
        for (int i = 0; i < Game.MapWidth; i++)
            for (int j = 0; j < Game.MapHeight; j++)
                if (Game.Map[i, j] is Player)
                    return (i, j);

        return null;
    }


    private bool CanMoveTo(int x, int y)
    {
        if (x < 0 || y < 0 || x >= Game.MapWidth || y >= Game.MapHeight)
            return false;

        var target = Game.Map[x, y];
        return !(target is Terrain || target is Sack || target is Monster);
    }
}

public static ICreature[,] CreateMap()
{
    return new ICreature[,]
    {
        { new Terrain(), new Terrain(), new Terrain() },
        { new Terrain(), new Player(), new Terrain() },
        { new Terrain(), new Terrain(), new Terrain() }
    };
}