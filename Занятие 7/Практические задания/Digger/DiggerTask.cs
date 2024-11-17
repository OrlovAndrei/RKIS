using System;
using Avalonia.Input;
using Digger.Architecture;

namespace Digger;

class Player : ICreature
{
    public CreatureCommand Act(int x, int y)
    {
        var command = new CreatureCommand();
        var direction = Game.KeyPressed;

        if (direction == Key.Right && x + 1 < Game.MapWidth)
            command.DeltaX++;
        else if (direction == Key.Left && x - 1 >= 0)
            command.DeltaX--;
        else if (direction == Key.Down && y + 1 < Game.MapHeight)
            command.DeltaY++;
        else if (direction == Key.Up && y - 1 >= 0)
            command.DeltaY--;

        return command;
    }

    public bool DeadInConflict(ICreature conflictedObject) => false;

    public int GetDrawingPriority() => 0;

    public string GetImageFileName() => "Digger.png";
}

class Terrain : ICreature
{
    public CreatureCommand Act(int x, int y) => new();

    public bool DeadInConflict(ICreature conflictedObject) => true;

    public int GetDrawingPriority() => 1;

    public string GetImageFileName() => "Terrain.png";
}
