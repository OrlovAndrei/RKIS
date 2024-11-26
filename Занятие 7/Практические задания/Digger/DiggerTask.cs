using Avalonia.Input;
using Digger.Architecture;

namespace Digger;
// ЗАДАНИЕ 1
// класс терраин
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

// класс плейер 
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
