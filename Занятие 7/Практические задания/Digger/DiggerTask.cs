using System;
using Avalonia.Input;
using global::Digger.Architecture;

namespace Digger
{
    public class Terrain : ICreature
    {
        public CreatureCommand Act(int x, int y) => CreatureCommand.Stay();

        public bool DeadInConflict(ICreature other) => true; // Уничтожается при столкновении

        public int GetDrawingPriority() => 2;

        public string GetImageFileName() => "Terrain.png";
    }

    public class Player : ICreature
    {
        public static int posX = 0, posY = 0; // Положение Digger на карте

        public CreatureCommand Act(int x, int y)
        {
            UpdatePosition(x, y);

            switch (Game.KeyPressed)
            {
                case Key.A: return TryMove(-1, 0); // Движение влево
                case Key.W: return TryMove(0, -1); // Движение вверх
                case Key.D: return TryMove(1, 0); // Движение вправо
                case Key.S: return TryMove(0, 1); // Движение вниз
                default: return CreatureCommand.Stay(); // Остается на месте
            }
        }

        private void UpdatePosition(int x, int y)
        {
            posX = x;
            posY = y;
        }

        private CreatureCommand TryMove(int deltaX, int deltaY)
        {
            if (IsMoveValid(posX + deltaX, posY + deltaY))
            {
                var nextCell = Game.Map[posX + deltaX, posY + deltaY];
                if (nextCell is Sack)
                {
                    return CreatureCommand.Stay(); // Останавливается, если впереди Sack
                }

                return new CreatureCommand { DeltaX = deltaX, DeltaY = deltaY };
            }
            return CreatureCommand.Stay(); // Если движение невозможно, остаётся на месте
        }

        private bool IsMoveValid(int x, int y)
        {
            return x >= 0 && x < Game.MapWidth && y >= 0 && y < Game.MapHeight;
        }

        public bool DeadInConflict(ICreature other)
        {
            if (other is Gold)
            {
                Game.Scores += 10; // За золото
                return false; // Digger не погибает
            }
            return other is Sack || other is Monster; // Digger погибает при столкновении с Sack или Monster
        }

        public int GetDrawingPriority() => 1;

        public string GetImageFileName() => "Digger.png";
    }

    public class Sack : ICreature
    {
        private int fallSteps = 0;

        public CreatureCommand Act(int x, int y)
        {
            if (CanFall(x, y))
            {
                fallSteps++;
                return CreatureCommand.Fall(); // Падает вниз
            }

            if (fallSteps > 1)
            {
                fallSteps = 0;
                return new CreatureCommand { TransformTo = new Gold() }; // Превращается в золото
            }

            return CreatureCommand.Stay(); // Остается на месте
        }

        private bool CanFall(int x, int y)
        {
            return (y < Game.MapHeight - 1 && Game.Map[x, y + 1] == null);
        }

        public bool DeadInConflict(ICreature other) => false;

        public int GetDrawingPriority() => 5;

        public string GetImageFileName() => "Sack.png";
    }

    public class Gold : ICreature
    {
        public CreatureCommand Act(int x, int y) => CreatureCommand.Stay();

        public bool DeadInConflict(ICreature other) => other is Player || other is Monster;

        public int GetDrawingPriority() => 3;

        public string GetImageFileName() => "Gold.png";
    }

    public class Monster : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            if (IsPlayerAlive(out int playerX, out int playerY))
            {
                return MoveTowardsPlayer(x, y, playerX, playerY);
            }
            return CreatureCommand.Stay();
        }

        private CreatureCommand MoveTowardsPlayer(int x, int y, int playerX, int playerY)
        {
            int deltaX = (playerX > x) ? 1 : -1;
            int deltaY = (playerY > y) ? 1 : -1;

            if (CanMove(x + deltaX, y))
                return new CreatureCommand { DeltaX = deltaX, DeltaY = 0 };
            if (CanMove(x, y + deltaY))
                return new CreatureCommand { DeltaX = 0, DeltaY = deltaY };

            return CreatureCommand.Stay(); // Если ни одно из направлений невозможно, остаётся на месте
        }

        private bool CanMove(int x, int y)
        {
            return (x >= 0 && x < Game.MapWidth && y >= 0 && y < Game.MapHeight
                && !(Game.Map[x, y] is Terrain || Game.Map[x, y] is Sack || Game.Map[x, y] is Monster));
        }

        public bool DeadInConflict(ICreature other) => other is Sack || other is Monster;

        public int GetDrawingPriority() => 0;

        public string GetImageFileName() => "Monster.png";

        private static bool IsPlayerAlive(out int playerX, out int playerY)
        {
            for (int i = 0; i < Game.MapWidth; i++)
            {
                for (int j = 0; j < Game.MapHeight; j++)
                {
                    ICreature cell = Game.Map[i, j];
                    if (cell is Player)
                    {
                        playerX = i;
                        playerY = j;
                        return true; // Digger найден
                    }
                }
            }
            playerX = playerY = -1; // Указываем, что Digger не найден
            return false;
        }
    }

    public class CreatureCommand
    {
        public int DeltaX { get; set; } = 0;
        public int DeltaY { get; set; } = 0;
        public ICreature TransformTo { get; set; } = null;

        public static CreatureCommand Stay() => new CreatureCommand { DeltaX = 0, DeltaY = 0 };
        public static CreatureCommand Fall() => new CreatureCommand { DeltaX = 0, DeltaY = 1 };
    }
}