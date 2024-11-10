using System;
using Avalonia.Input;

namespace Digger
{
    public class Terrain : ICreature
    {
        public string GetImageFileName()
        {
            return "Terrain.png";
        }

        public int GetDrawingPriority()
        {
            return 1; 
        }

        public (Direction, ICreature) DoAction()
        {
            return (Direction.None, this); 
        }

        public bool ResolveCollision(ICreature creature)
        {
            return true;
        }
    }
 public class Player : ICreature
    {
        public string GetImageFileName()
        {
            return "Player.png";
        }

        public int GetDrawingPriority()
        {
            return 2; // Выше, чем у Terrain
        }

        public (Direction, ICreature) DoAction()
        {
            // Получаем направление движения
            Direction direction = Direction.None;
            if (Game.KeyPressed == Key.Up)
            {
                direction = Direction.Up;
            }
            else if (Game.KeyPressed == Key.Down)
            {
                direction = Direction.Down;
            }
            else if (Game.KeyPressed == Key.Left)
            {
                direction = Direction.Left;
            }
            else if (Game.KeyPressed == Key.Right)
            {
                direction = Direction.Right;
            }

            // Проверяем границы поля
            if (direction != Direction.None && IsMoveValid(direction))
            {
                return (direction, new Terrain()); // Превращаем Terrain в пустоту 
            }

            return (Direction.None, this); // Остаемся на месте
        }

        public bool ResolveCollision(ICreature creature)
        {
            return creature is Terrain; // Пропускаем только Terrain
        }

        private bool IsMoveValid(Direction direction)
        {
            int newX = Game.Map.GetLength(0);
            int newY = Game.Map.GetLength(1);

            switch (direction)
            {
                case Direction.Up:
                    newY = Game.Map.GetLength(1) - 1;
                    break;
                case Direction.Down:
                    newY = 0;
                    break;
                case Direction.Left:
                    newX = Game.Map.GetLength(0) - 1;
                    break;
                case Direction.Right:
                    newX = 0;
                    break;
            }

            return newX >= 0 && newX < Game.MapWidth && newY >= 0 && newY < Game.MapHeight;
        }
    }
}
