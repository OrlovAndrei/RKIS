using System;
using Avalonia.Input;
using Digger.Architecture;

namespace Digger;
    public static class GameHelpers
    {
        public static bool IsInsideMap(int x, int y) =>
            x >= 0 && x < Game.MapWidth && y >= 0 && y < Game.MapHeight;

        public static ICreature GetCreatureAt(int x, int y) =>
            IsInsideMap(x, y) ? Game.Map[x, y] : null;

        public static bool IsBlocked(ICreature creature) =>
            creature is Terrain || creature is Sack || creature is Monster;
    }

    public class Terrain : ICreature
    {
        public CreatureCommand Act(int positionX, int positionY) => new() { DeltaX = 0, DeltaY = 0 };

        public bool DeadInConflict(ICreature conflictingObject) => true;

        public int GetDrawingPriority() => 2;

        public string GetImageFileName() => "Terrain.png";
    }

    public class Player : ICreature
    {
        public static int PositionX;
        public static int PositionY;
        private static int deltaX, deltaY;

        public CreatureCommand Act(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;

            HandleInput();

            if (!GameHelpers.IsInsideMap(positionX + deltaX, positionY + deltaY) ||
                GameHelpers.IsBlocked(GameHelpers.GetCreatureAt(positionX + deltaX, positionY + deltaY)))
                Stay();

            return new CreatureCommand { DeltaX = deltaX, DeltaY = deltaY };
        }

        private void HandleInput()
        {
            deltaX = deltaY = 0;
            switch (Game.KeyPressed)
            {
                case Key.Left: deltaX = -1; break;
                case Key.Up: deltaY = -1; break;
                case Key.Right: deltaX = 1; break;
                case Key.Down: deltaY = 1; break;
                default: Stay(); break;
            }
        }

        private void Stay()
        {
            deltaX = 0;
            deltaY = 0;
        }

        public bool DeadInConflict(ICreature conflictingObject)
        {
            if (conflictingObject is Gold) Game.Scores += 10;
            return conflictingObject is Sack || conflictingObject is Monster;
        }

        public int GetDrawingPriority() => 1;

        public string GetImageFileName() => "Digger.png";
    }

    public class Sack : ICreature
    {
        private int fallCounter;

        public CreatureCommand Act(int positionX, int positionY)
        {
            var belowCreature = GameHelpers.GetCreatureAt(positionX, positionY + 1);

            if (belowCreature == null || (fallCounter > 0 && belowCreature is Player))
            {
                fallCounter++;
                return new CreatureCommand { DeltaX = 0, DeltaY = 1 };
            }

            if (fallCounter > 1)
            {
                fallCounter = 0;
                return new CreatureCommand { DeltaX = 0, DeltaY = 0, TransformTo = new Gold() };
            }

            fallCounter = 0;
            return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
        }

        public bool DeadInConflict(ICreature conflictingObject) => false;

        public int GetDrawingPriority() => 5;

        public string GetImageFileName() => "Sack.png";
    }

    public class Gold : ICreature
    {
        public CreatureCommand Act(int positionX, int positionY) =>
            new() { DeltaX = 0, DeltaY = 0 };

        public bool DeadInConflict(ICreature conflictingObject) =>
            conflictingObject is Player || conflictingObject is Monster;

        public int GetDrawingPriority() => 3;

        public string GetImageFileName() => "Gold.png";
    }

    public class Monster : ICreature
    {
        public CreatureCommand Act(int positionX, int positionY)
        {
            if (!IsPlayerAlive(out var targetX, out var targetY))
                return Stay();

            var deltaX = Math.Sign(targetX - positionX);
            var deltaY = Math.Sign(targetY - positionY);

            if (!GameHelpers.IsInsideMap(positionX + deltaX, positionY + deltaY) ||
                GameHelpers.IsBlocked(GameHelpers.GetCreatureAt(positionX + deltaX, positionY + deltaY)))
                return Stay();

            return new CreatureCommand { DeltaX = deltaX, DeltaY = deltaY };
        }

        public bool DeadInConflict(ICreature conflictingObject) =>
            conflictingObject is Sack || conflictingObject is Monster;

        public int GetDrawingPriority() => 0;

        public string GetImageFileName() => "Monster.png";

        private CreatureCommand Stay() => new() { DeltaX = 0, DeltaY = 0 };

        private bool IsPlayerAlive(out int playerX, out int playerY)
        {
            for (int x = 0; x < Game.MapWidth; x++)
                for (int y = 0; y < Game.MapHeight; y++)
                    if (Game.Map[x, y] is Player)
                    {
                        playerX = x;
                        playerY = y;
                        return true;
                    }
            playerX = playerY = 0;
            return false;
        }
}
