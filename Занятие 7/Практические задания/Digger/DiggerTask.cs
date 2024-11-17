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

    public bool DeadInConflict(ICreature conflictedObject) => conflictedObject is Sack;

    public int GetDrawingPriority() => 0;

    public string GetImageFileName() => "Digger.png";
}

class Terrain : ICreature
{
    public CreatureCommand Act(int x, int y) => new()
    {
        DeltaX = 0,
        DeltaY = 0
    };

    public bool DeadInConflict(ICreature conflictedObject) => true;

    public int GetDrawingPriority() => 5;

    public string GetImageFileName() => "Terrain.png";
}

class Sack : ICreature
{
    private int fallCount;
    private bool isFalling;

    public CreatureCommand Act(int x, int y)
    {
        bool canFall = y + 1 < Game.MapHeight &&
                       (Game.Map[x, y + 1] == null ||
                        (Game.Map[x, y + 1] is Player && isFalling));

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

    public bool DeadInConflict(ICreature conflictedObject) => false;

    public int GetDrawingPriority() => 3;

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

    public int GetDrawingPriority() => 3;

    public string GetImageFileName() => "Gold.png";
}