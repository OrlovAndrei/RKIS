using Avalonia.Input;
using Digger.Architecture;

namespace Digger;

class Player : ICreature
{
    public CreatureCommand Act(int x, int y)
    {
        var command = new CreatureCommand();
        var direction = Game.KeyPressed;

        if (direction == Key.Right && IsMoveValid(x + 1, y))
            command.DeltaX++;
        else if (direction == Key.Left && IsMoveValid(x - 1, y))
            command.DeltaX--;
        else if (direction == Key.Down && IsMoveValid(x, y + 1))
            command.DeltaY++;
        else if (direction == Key.Up && IsMoveValid(x, y - 1))
            command.DeltaY--;

        return command;
    }

    private static bool IsMoveValid(int targetX, int targetY)
    {
        return targetX >= 0 &&
               targetX < Game.MapWidth &&
               targetY >= 0 &&
               targetY < Game.MapHeight &&
               Game.Map[targetX, targetY] is not Sack;
    }

    public bool DeadInConflict(ICreature conflictedObject) => conflictedObject is Sack || conflictedObject is Monster;

    public int GetDrawingPriority() => 0;

    public string GetImageFileName() => "Digger.png";
}

class Terrain : ICreature
{
    public CreatureCommand Act(int x, int y) => new()
    {
        DeltaX = 0,
        DeltaY = 0,
        TransformTo = this
    };

    public bool DeadInConflict(ICreature conflictedObject) => conflictedObject is Player;

    public int GetDrawingPriority() => 100;

    public string GetImageFileName() => "Terrain.png";
}

class Sack : ICreature
{
    private int fallCount;
    private bool isFalling;
    public bool IsFalling => isFalling;

    public CreatureCommand Act(int x, int y)
    {
        var command = new CreatureCommand
        {
            DeltaX = 0,
            DeltaY = 1,
            TransformTo = this
        };

        bool canFall = CanFallTo(x + command.DeltaX, y + command.DeltaY);

        if (canFall)
        {
            fallCount++;
            isFalling = true;
            return CreateMovementCommand(0, 1);
        }

        if (fallCount > 1)
        {
            return CreateTransformToGoldCommand();
        }

        ResetFallState();
        return CreateMovementCommand(0, 0);
    }

    private CreatureCommand CreateMovementCommand(int deltaX, int deltaY)
    {
        return new CreatureCommand
        {
            DeltaX = deltaX,
            DeltaY = deltaY
        };
    }

    private CreatureCommand CreateTransformToGoldCommand()
    {
        return new CreatureCommand
        {
            DeltaX = 0,
            DeltaY = 0,
            TransformTo = new Gold()
        };
    }

    private void ResetFallState()
    {
        fallCount = 0;
        isFalling = false;
    }

    private bool CanFallTo(int x, int y)
    {
        if (x < 0 || y < 0 || x >= Game.MapWidth || y >= Game.MapHeight)
            return false;

        var cell = Game.Map.GetValue(x, y);

        return cell == null || (cell is Monster || cell is Player) && fallCount > 0;
    }

    public bool DeadInConflict(ICreature conflictedObject) => false;

    public int GetDrawingPriority() => 10;

    public string GetImageFileName() => "Sack.png";
}

class Gold : ICreature
{
    public CreatureCommand Act(int x, int y) => new();

    public bool DeadInConflict(ICreature conflictedObject)
    {
        if (conflictedObject is Player)
            Game.Scores += 10;
        return true;
    }

    public int GetDrawingPriority() => 10;

    public string GetImageFileName() => "Gold.png";
}

public class Monster : ICreature
{
    public string GetImageFileName() => "Monster.png";

    public int GetDrawingPriority() => 20;

    public CreatureCommand Act(int x, int y)
    {
        var command = new CreatureCommand
        {
            DeltaX = 0,
            DeltaY = 0,
            TransformTo = this
        };

        if (TryMoveTowardsPlayer(x, y, out var deltaX, out var deltaY))
        {
            command.DeltaX = deltaX;
            command.DeltaY = deltaY;
        }

        return command;
    }

    private bool TryMoveTowardsPlayer(int x, int y, out int deltaX, out int deltaY)
    {
        deltaX = 0;
        deltaY = 0;

        if (IsPlayerInSection(0, 0, x, Game.MapHeight) && CanMoveTo(x - 1, y))
        {
            deltaX = -1;
            return true;
        }

        if (IsPlayerInSection(x + 1, 0, Game.MapWidth, Game.MapHeight) && CanMoveTo(x + 1, y))
        {
            deltaX = 1;
            return true;
        }

        if (IsPlayerInSection(0, 0, Game.MapWidth, y) && CanMoveTo(x, y - 1))
        {
            deltaY = -1;
            return true;
        }

        if (IsPlayerInSection(0, y + 1, Game.MapWidth, Game.MapHeight) && CanMoveTo(x, y + 1))
        {
            deltaY = 1;
            return true;
        }

        return false;
    }

    private bool IsPlayerInSection(int x0, int y0, int x1, int y1)
    {
        for (var x = x0; x < x1; x++)
        {
            for (var y = y0; y < y1; y++)
            {
                if (Game.Map.GetValue(x, y) is ICreature creature && creature is Player)
                    return true;
            }
        }
        return false;
    }

    private bool CanMoveTo(int x, int y)
    {
        if (IsOutOfBounds(x, y)) return false;
        var cell = Game.Map.GetValue(x, y) as ICreature;
        return cell == null || IsMoveableCell(cell);
    }

    private bool IsOutOfBounds(int x, int y)
    {
        return x < 0 || y < 0 || x >= Game.MapWidth || y >= Game.MapHeight;
    }

    private bool IsMoveableCell(ICreature cell)
    {
        return !(cell is Sack || cell is Monster || cell is Terrain);
    }

    public bool DeadInConflict(ICreature conflictedObject)
    {
        return conflictedObject is Monster || (conflictedObject is Sack sack && sack.IsFalling);
    }
}