using System;
using Avalonia.Input;
using global::Digger.Architecture;


namespace Digger
{
    public class Terrain : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            // Terrain не двигается и остается на месте
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };
        }

        public bool DeadInConflict(ICreature other)
        {
            // Terrain всегда разрушается при любом конфликте с другим объектом
            return true;
        }

        public int GetDrawingPriority()
        {
            // Приоритет прорисовки Terrain, чем выше число, тем позже прорисовывается
            return 2;
        }

        public string GetImageFileName()
        {
            // Имя файла изображения для отображения Terrain
            return "Terrain.png";
        }
    }

    public class Player : ICreature
    {
        public static int posX, posY = 0; // Положение Digger на карте
        public static int moveX, moveY = 0; // Сдвиг Digger при движении

        public CreatureCommand Act(int x, int y)
        {
            posX = x;
            posY = y;

            // Определение направления движения Digger на основе нажатых клавиш WASD
            switch (Game.KeyPressed)
            {
                case Key.A: // Движение влево
                    moveX = -1;
                    moveY = 0;
                    break;
                case Key.W: // Движение вверх
                    moveX = 0;
                    moveY = -1;
                    break;
                case Key.D: // Движение вправо
                    moveX = 1;
                    moveY = 0;
                    break;
                case Key.S: // Движение вниз
                    moveX = 0;
                    moveY = 1;
                    break;
                default:
                    StayStill(); // Остается на месте, если нет нажатия
                    break;
            }

            // Проверка выхода Digger за границы карты
            if (!(x + moveX >= 0 && x + moveX < Game.MapWidth &&
                  y + moveY >= 0 && y + moveY < Game.MapHeight))
                StayStill();

            // Проверка на наличие мешка в следующей ячейке, мешок блокирует путь
            var nextCell = Game.Map[x + moveX, y + moveY];
            if (nextCell != null && nextCell.ToString() == "Digger.Sack")
                StayStill();

            // Возвращает команду с координатами сдвига
            return new CreatureCommand() { DeltaX = moveX, DeltaY = moveY };
        }

        public bool DeadInConflict(ICreature other)
        {
            // Digger получает очки при сборе золота
            var objType = other.ToString();
            if (objType == "Digger.Gold")
                Game.Scores += 10;

            // Digger погибает при столкновении с мешком или монстром
            return objType == "Digger.Sack" || objType == "Digger.Monster";
        }

        public int GetDrawingPriority()
        {
            // Приоритет прорисовки Digger
            return 1;
        }

        public string GetImageFileName()
        {
            return "Digger.png";
        }

        private static void StayStill()
        {
            // Остановка Digger, сброс координат сдвига
            moveX = 0;
            moveY = 0;
        }
    }

    public class Sack : ICreature
    {
        private int fallSteps = 0; // Счетчик шагов падения мешка

        public CreatureCommand Act(int x, int y)
        {
            // Проверка, может ли мешок падать вниз
            if (y < Game.MapHeight - 1)
            {
                var belowCell = Game.Map[x, y + 1];
                if (belowCell == null ||
                    (fallSteps > 0 && (belowCell.ToString() == "Digger.Player" ||
                                       belowCell.ToString() == "Digger.Monster")))
                {
                    fallSteps++;
                    return Fall(); // Мешок падает вниз
                }
            }

            // Если мешок падал больше одного шага, он превращается в золото
            if (fallSteps > 1)
            {
                fallSteps = 0;
                return new CreatureCommand() { DeltaX = 0, DeltaY = 0, TransformTo = new Gold() };
            }

            // Мешок остается на месте, если падение невозможно
            fallSteps = 0;
            return StayStill();
        }

        public bool DeadInConflict(ICreature other)
        {
            // Мешок не погибает при столкновении
            return false;
        }

        public int GetDrawingPriority()
        {
            // Приоритет прорисовки мешка
            return 5;
        }

        public string GetImageFileName()
        {
            return "Sack.png";
        }

        private CreatureCommand Fall()
        {
            // Возвращает команду для падения мешка на одну клетку вниз
            return new CreatureCommand() { DeltaX = 0, DeltaY = 1 };
        }

        private CreatureCommand StayStill()
        {
            // Мешок остается на месте
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };
        }
    }

    public class Gold : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            // Золото не двигается, остается на месте
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };
        }

        public bool DeadInConflict(ICreature other)
        {
            // Золото исчезает при контакте с Digger или монстром
            var objType = other.ToString();
            return objType == "Digger.Player" || objType == "Digger.Monster";
        }

        public int GetDrawingPriority()
        {
            // Приоритет прорисовки золота
            return 3;
        }

        public string GetImageFileName()
        {
            return "Gold.png";
        }
    }

    public class Monster : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            int deltaX = 0, deltaY = 0;

            // Проверка, жив ли Digger на карте
            if (IsPlayerAlive())
            {
                // Определение направления движения монстра в сторону Digger
                if (Player.posX == x)
                {
                    deltaY = Player.posY < y ? -1 : 1;
                }
                else if (Player.posY == y)
                {
                    deltaX = Player.posX < x ? -1 : 1;
                }
                else
                {
                    deltaX = Player.posX < x ? -1 : 1;
                }
            }
            else return Stay(); // Если Digger не найден, монстр остается на месте

            // Проверка выхода монстра за границы карты
            if (!(x + deltaX >= 0 && x + deltaX < Game.MapWidth &&
                  y + deltaY >= 0 && y + deltaY < Game.MapHeight))
                return Stay();

            // Проверка на наличие препятствий на пути монстра
            var nextCell = Game.Map[x + deltaX, y + deltaY];
            if (nextCell != null && (nextCell.ToString() == "Digger.Terrain" ||
                                     nextCell.ToString() == "Digger.Sack" ||
                                     nextCell.ToString() == "Digger.Monster"))
                return Stay();

            // Возвращает команду для движения монстра
            return new CreatureCommand() { DeltaX = deltaX, DeltaY = deltaY };
        }

        public bool DeadInConflict(ICreature other)
        {
            // Монстр погибает при столкновении с мешком или другим монстром
            var objType = other.ToString();
            return objType == "Digger.Sack" || objType == "Digger.Monster";
        }

        public int GetDrawingPriority()
        {
            // Приоритет прорисовки монстра
            return 0;
        }

        public string GetImageFileName()
        {
            return "Monster.png";
        }

        private static CreatureCommand Stay()
        {
            // Команда для остановки монстра
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };
        }

        private static bool IsPlayerAlive()
        {
            // Проверка, существует ли Digger на карте
            for (int i = 0; i < Game.MapWidth; i++)
                for (int j = 0; j < Game.MapHeight; j++)
                {
                    var cell = Game.Map[i, j];
                    if (cell != null && cell.ToString() == "Digger.Player")
                    {
                        Player.posX = i;
                        Player.posY = j;
                        return true;
                    }
                }
            return false;
        }
    }
}
