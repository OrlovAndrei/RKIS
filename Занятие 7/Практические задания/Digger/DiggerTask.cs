using System;
using Avalonia.Input;

namespace Digger;
{
    // Класс Terrain, который просто существует в игре и ничего не делает
    public class Terrain : ICreature
    {
        public string GetImageFileName() => "Terrain.png";
        public int GetDrawingPriority() => 0;
        public CreatureCommand Act(int x, int y) => new CreatureCommand { DeltaX = 0, DeltaY = 0 };
        public bool DeadInConflict(ICreature conflictedObject) => false;
    }

    // Класс Player, который двигается по карте в зависимости от нажатия клавиш
    public class Player : ICreature
    {
        public string GetImageFileName() => "Player.png";
        public int GetDrawingPriority() => 1;

        public CreatureCommand Act(int x, int y)
        {
            int deltaX = 0, deltaY = 0;

            switch (Game.KeyPressed)
            {
                case Key.Up:
                    deltaY = -1;
                    break;
                case Key.Down:
                    deltaY = 1;
                    break;
                case Key.Left:
                    deltaX = -1;
                    break;
                case Key.Right:
                    deltaX = 1;
                    break;
            }

            if (x + deltaX < 0 || x + deltaX >= Game.MapWidth || y + deltaY < 0 || y + deltaY >= Game.MapHeight)
                return new CreatureCommand { DeltaX = 0, DeltaY = 0 };

            return new CreatureCommand { DeltaX = deltaX, DeltaY = deltaY };
        }

        public bool DeadInConflict(ICreature conflictedObject) => conflictedObject is Terrain;
    }

    // Класс Sack, который падает и превращается в золото, если падал больше одной клетки
    public class Sack : ICreature
    {
        private int fallDistance = 0;

        public string GetImageFileName() => "Sack.png";
        public int GetDrawingPriority() => 2;

        public CreatureCommand Act(int x, int y)
        {
            if (y + 1 < Game.MapHeight && Game.Map[x, y + 1] == null)
            {
                fallDistance++;
                return new CreatureCommand { DeltaX = 0, DeltaY = 1 };
            }
            else
            {
                if (fallDistance > 1)
                    return new CreatureCommand { DeltaX = 0, DeltaY = 0, TransformTo = new Gold() };

                fallDistance = 0;
                return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
            }
        }

        public bool DeadInConflict(ICreature conflictedObject) => conflictedObject is Player;
    }

    // Класс Gold, который статичен и может быть собран диггером для получения очков
    public class Gold : ICreature
    {
        public string GetImageFileName() => "Gold.png";
        public int GetDrawingPriority() => 3;

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
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

    // Класс Monster, который движется к диггеру и взаимодействует с другими объектами
    public class Monster : ICreature
    {
        public string GetImageFileName() => "Monster.png";
        public int GetDrawingPriority() => 4;

        public CreatureCommand Act(int x, int y)
        {
            var playerPosition = FindPlayerPosition();
            if (playerPosition == null)
                return new CreatureCommand { DeltaX = 0, DeltaY = 0 };

            int deltaX = 0, deltaY = 0;

            // Двигаемся в сторону игрока, если он существует на карте
            if (playerPosition.Value.X > x) deltaX = 1;
            else if (playerPosition.Value.X < x) deltaX = -1;
            else if (playerPosition.Value.Y > y) deltaY = 1;
            else if (playerPosition.Value.Y < y) deltaY = -1;

            // Проверяем, что цельное место не занято другим монстром или мешком
            if (IsCellFreeForMonster(x + deltaX, y + deltaY))
                return new CreatureCommand { DeltaX = deltaX, DeltaY = deltaY };

            return new CreatureCommand { DeltaX = 0, DeltaY = 0 };
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            // Монстр умирает, если в одной клетке оказался мешок или другой монстр
            return conflictedObject is Sack || conflictedObject is Monster;
        }

        private (int X, int Y)? FindPlayerPosition()
        {
            // Поиск позиции игрока (диггера) на карте
            for (int i = 0; i < Game.MapWidth; i++)
                for (int j = 0; j < Game.MapHeight; j++)
                    if (Game.Map[i, j] is Player)
                        return (i, j);
            return null;
        }

        private bool IsCellFreeForMonster(int x, int y)
        {
            // Проверка, свободна ли клетка для передвижения монстра
            if (x < 0 || x >= Game.MapWidth || y < 0 || y >= Game.MapHeight)
                return false;

            var cellContent = Game.Map[x, y];
            return !(cellContent is Monster || cellContent is Sack || cellContent is Terrain);
        }
    }
}