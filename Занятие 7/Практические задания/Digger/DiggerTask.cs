using System;
using Avalonia.Input;

namespace Digger;

{
    public class Terrain : ICreature
{
    public CreatureCommand Act(int x, int y) => new CreatureCommand();
    public bool DeadInConflict(ICreature conflictedObject) => true;
    public int GetDrawingPriority() => 1;
    public string GetImageFileName() => "Terrain.png";
}

public class Player : ICreature
{
    public CreatureCommand Act(int x, int y)
    {
        var result = new CreatureCommand();
        if (Game.KeyPressed == Key.Up && y > 0) result.DeltaY = -1;
        if (Game.KeyPressed == Key.Down && y < Game.MapHeight - 1) result.DeltaY = 1;
        if (Game.KeyPressed == Key.Left && x > 0) result.DeltaX = -1;
        if (Game.KeyPressed == Key.Right && x < Game.MapWidth - 1) result.DeltaX = 1;
        return result;
    }

    public bool DeadInConflict(ICreature conflictedObject) => conflictedObject is Sack or Monster;


    public int GetDrawingPriority() => 0;
    public string GetImageFileName() => "Digger.png";
}

public class Sack : ICreature
{
    int height = 0;
    public CreatureCommand Act(int x, int y)
    {
        var result = new CreatureCommand();
        if (y < Game.MapHeight - 1 && Game.Map[x, y + 1] == null)
        {
            result.DeltaY = 1;
            height++;
        }
        else if (height > 1 || y == Game.MapHeight) result.TransformTo = new Gold();
        else height = 0;
        return result;
    }

    public bool DeadInConflict(ICreature conflictedObject) => false;
    public int GetDrawingPriority() => 1;
    public string GetImageFileName() => "Sack.png";
}

public class Gold : ICreature
{
    public CreatureCommand Act(int x, int y) => new CreatureCommand();
    public bool DeadInConflict(ICreature conflictedObject)
    {
        if (conflictedObject is Player) Game.Scores += 10;
        return true;
    }

    public int GetDrawingPriority() => 1;

    public string GetImageFileName() => "Gold.png";
}

public class Monster : ICreature
{
    public Position GetDiggerPosition()
    {
        for (int i = 0; i < Game.MapWidth; i++)
            for (int j = 0; j < Game.MapHeight; j++)
                if (Game.Map[i, j] is Player) return new Position { X = i, Y = j };
        return null;
    }

    public CreatureCommand Act(int x, int y)
    {
        var result = new CreatureCommand();
        var pos = GetDiggerPosition();
        if (pos != null)
        {
            if (pos.X < x && CanMove(x - 1, y)) result.DeltaX = -1;
            if (pos.X > x && CanMove(x + 1, y)) result.DeltaX = 1;
            if (pos.Y < y && CanMove(x, y - 1)) result.DeltaY = -1;
            if (pos.Y > y && CanMove(x, y + 1)) result.DeltaY = 1;
        }
        return result;
    }

    public bool DeadInConflict(ICreature conflictedObject) => conflictedObject is Sack;
    public int GetDrawingPriority() => 1;
    public string GetImageFileName() => "Monster.png";

    private bool CanMove(int x, int y) =>
        Game.Map[x, y] == null || Game.Map[x, y] is Gold || Game.Map[x, y] is Player;
}

public class Position
{
    public int X, Y;
}
}
