using Avalonia.Input;
using Digger.Architecture;

namespace Digger;
// Задание 3
// террайн
class Terrain : ICreature
{
    public CreatureCommand Act(int x, int y) => new CreatureCommand
    {
        DeltaX = 0,
        DeltaY = 0,
        TransformTo = this
    };

    public bool DeadInConflict(ICreature conflictedObject) => conflictedObject is Player;

    public int GetDrawingPriority() => 100;

    public string GetImageFileName() => "Terrain.png";
}

// игрок
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

        if (Game.Map[x + command.DeltaX, y + command.DeltaY] is Terrain)
            Game.Map[x + command.DeltaX, y + command.DeltaY] = null;

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

// сак
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

// золото
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

// монстры
class Monster : ICreature
{
    public CreatureCommand Act(int x, int y)
    {
        var player = FindPlayer();
        if (player == null)
            return new CreatureCommand();

        var deltaX = Math.Sign(player.X - x);
        var deltaY = Math.Sign(player.Y - y);
        if (CanMove(x + deltaX, y))
            return new CreatureCommand { DeltaX = deltaX, DeltaY = 0 };
        if (CanMove(x, y + deltaY))
            return new CreatureCommand { DeltaX = 0, DeltaY = deltaY };

        return new CreatureCommand();
    }

    private static bool CanMove(int x, int y)
    {
        if (x < 0 || y < 0 || x >= Game.MapWidth || y >= Game.MapHeight)
            return false;

        var cell = Game.Map.GetValue(x, y);
        return cell == null || cell is Player || cell is Gold;
    }

    private static (int X, int Y)? FindPlayer()
    {
        for (var x = 0; x < Game.MapWidth; x++)
            for (var y = 0; y < Game.MapHeight; y++)
                if (Game.Map.GetValue(x, y) is Player)
                    return (x, y);
        return null;
    }

    public bool DeadInConflict(ICreature conflictedObject) => conflictedObject is Player || conflictedObject is Monster || conflictedObject is Sack;

    public int GetDrawingPriority() => 5;

    public string GetImageFileName() => "Monster.png";
}
