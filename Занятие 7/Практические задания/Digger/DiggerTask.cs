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
            {
    // Класс Sack
    public class Sack : ICreature
    {
        private bool _isFalling; // Флаг, указывающий, падает ли мешок
        private int _fallDistance; // Количество клеток, на которое мешок упал

        public string GetImageFileName()
        {
            return "Sack.png";
        }

        public int GetDrawingPriority()
        {
            return 3; // Выше, чем у Terrain
        }

        public (Direction, ICreature) DoAction()
        {
            if (_isFalling)
            {
                _fallDistance++;
                return (Direction.Down, this); // Падение вниз
            }
            else
            {
                // Проверяем, есть ли под мешком пустое место
                if (CanFall())
                {
                    _isFalling = true;
                    _fallDistance = 1;
                    return (Direction.Down, this); // Начало падения
                }
            }

            return (Direction.None, this); // Остаемся на месте
        }

        public bool ResolveCollision(ICreature creature)
        {
            if (_isFalling)
            {
                if (creature is Player)
                {
                    // Мешок убивает игрока
                    Game.IsOver = true;
                    return false; // Продолжаем падать
                }
                else if (creature is Terrain | |creature is Sack| | creature is Gold) //между || не должно быть пробелов, просто тг нормально их не пропускает :_) 
                {
                    // Превращаем в золото, если падали больше одной клетки
                    if (_fallDistance > 1)
                    {
                        return true; // Заменяемся на золото
                    }
                    else
                    {
                        return false; // Остаемся мешком
                    }
                }
                else
                {
                    return false; // Продолжаем падать
                }
            }
            else
            {
                return creature != Player; // Пропускаем только Player
            }
        }

        private bool CanFall()
        {
            int currentX = Array.IndexOf(Game.Map, this, 0);
            int currentY = Array.FindIndex(Game.Map, row => row[currentX] == this);
            if (currentY + 1 < Game.MapHeight)
            {
                return Game.Map[currentX, currentY + 1] is Terrain ||
                       Game.Map[currentX, currentY + 1] is Sack ||
                       Game.Map[currentX, currentY + 1] is Gold;
            }
            return true; // Падаем, если достигли нижней границы
        }
    }

    // Класс Gold
    public class Gold : ICreature
    {
        public string GetImageFileName()
        {
            return "Gold.png";
        }

        public int GetDrawingPriority()
        {
            return 4; // Выше, чем у Sack
        }

        public (Direction, ICreature) DoAction()
        {
            return (Direction.None, this); // Ничего не делаем
        }

        public bool ResolveCollision(ICreature creature)
        {
            if (creature is Player)
            {
                Game.Scores += 10;
                return true; // Удаляем золото
            }
            return false; // Не пропускаем
        }
    }
    {
    // Класс Monster
    public class Monster : ICreature
    {
        public string GetImageFileName()
        {
            return "Monster.png";
        }

        public int GetDrawingPriority()
        {
            return 5; // Выше, чем у Sack
        }

        public (Direction, ICreature) DoAction()
        {
            // Находим игрока
            var playerPosition = FindPlayer();
            if (playerPosition == null)
            {
                return (Direction.None, this); // Если игрок не найден, стоим на месте
            }

            // Определяем направление движения
            Direction direction = FindDirection(playerPosition.Value);
            if (direction == Direction.None)
            {
                return (Direction.None, this); // Если путь к игроку перекрыт, стоим на месте
            }

            // Проверяем, можно ли двигаться в выбранном направлении
            if (CanMove(direction))
            {
                return (direction, this); // Двигаемся в выбранном направлении
            }
            else
            {
                return (Direction.None, this); // Если движение невозможно, стоим на месте
            }
        }

        public bool ResolveCollision(ICreature creature)
        {
            if (creature is Player)
            {
                // Монстр убивает игрока
                Game.IsOver = true;
                return true; // Удаляем монстра
            }
            else if (creature is Gold)
            {
                // Золото исчезает
                return true; // Удаляем монстра
            }
            else if (creature is Sack && _isFallingOnMe)
            {
                // Монстр умирает от падающего мешка
                return true; // Удаляем монстра
            }
            else if (creature is Monster)
            {
                // Два монстра сталкиваются
                return true; // Удаляем обоих монстров
            }

            return false; // Не пропускаем
        }

        private (int, int)? FindPlayer()
        {
            for (int y = 0; y < Game.MapHeight; y++)
            {
                for (int x = 0; x < Game.MapWidth; x++)
                {
                    if (Game.Map[x, y] is Player)
                    {
                        return (x, y);
                    }
                }
            }

            return null;
        }

        private Direction FindDirection((int x, int y) playerPosition)
        {
            int currentX = Array.IndexOf(Game.Map, this, 0);
            int currentY = Array.FindIndex(Game.Map, row => row[currentX] == this);

            if (playerPosition.x < currentX)
            {
                return Direction.Left;
            }
            else if (playerPosition.x > currentX)
            {
                return Direction.Right;
            }
            else if (playerPosition.y < currentY)
            {
                return Direction.Up;
            }
            else if (playerPosition.y > currentY)
            {
                return Direction.Down;
            }

            return Direction.None;
        }

        private bool CanMove(Direction direction)
        {
            int currentX = Array.IndexOf(Game.Map, this, 0);
            int currentY = Array.FindIndex(Game.Map, row => row[currentX] == this);

            int newX = currentX;
            int newY = currentY;

            switch (direction)
            {
                case Direction.Up:
                    newY--;
                    break;
                case Direction.Down:
                    newY++;
                    break;
                case Direction.Left:
                    newX--;
                    break;
                case Direction.Right:
                    newX++;
                    break;
            }
if (newX >= 0 && newX < Game.MapWidth && newY >= 0 && newY < Game.MapHeight)
            {
                return !(Game.Map[newX, newY] is Terrain | | Game.Map[newX, newY] is Sack | | //та же самая проблема с ||
                         Game.Map[newX, newY] is Monster);
            }

            return false;
        }

        // Флаг, указывающий, падает ли мешок на монстра
        private bool _isFallingOnMe = false;

        public bool IsFallingOnMe
        {
            get { return _isFallingOnMe; }
            set { _isFallingOnMe = value; }
        }    
    }
}
