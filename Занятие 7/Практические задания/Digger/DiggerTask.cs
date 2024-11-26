using System;
using System.Collections.Generic;

namespace Digger
{
    // Интерфейс ICreature, который будет реализовывать каждый элемент игры
    public interface ICreature
    {
        string GetImageFileName();  // Метод для получения имени файла картинки
        int GetDrawPriority();      // Метод для получения приоритета отрисовки
        (int dx, int dy) GetMoveDirection();  // Метод для получения направления движения
        ICreature OnCollision(ICreature other); // Метод для обработки столкновения
    }

    // Класс Terrain (земля)
    public class Terrain : ICreature
    {
        public string GetImageFileName() => "Terrain.png"; // Изображение земли
        public int GetDrawPriority() => 0; // Земля рисуется в самом низу
        public (int dx, int dy) GetMoveDirection() => (0, 0); // Земля не двигается
        public ICreature OnCollision(ICreature other) => this; // Столкновение с землёй не меняет её состояние
    }

    // Класс Player (игрок)
    public class Player : ICreature
    {
        public int X { get; set; }  // Позиция игрока по оси X
        public int Y { get; set; }  // Позиция игрока по оси Y

        public string GetImageFileName() => "Player.png";  // Изображение игрока
        public int GetDrawPriority() => 1;  // Игрок рисуется поверх земли
        public (int dx, int dy) GetMoveDirection() => (0, 0);  // Игрок не двигается автоматически, мы будем изменять его положение вручную

        public ICreature OnCollision(ICreature other)
        {
            // Игрок может собирать золото
            if (other is Gold)
            {
                Game.Scores += 10;  // Игрок получает 10 очков
                return null; // Золото исчезает
            }

            // Если игрок сталкивается с мешком с золотом, он умирает
            if (other is Sack)
            {
                return null; // Игрок умирает
            }

            return this;
        }

        // Метод для перемещения игрока в зависимости от нажатой клавиши
        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }

    // Класс Sack (Мешок с золотом)
    public class Sack : ICreature
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsFalling { get; private set; }
        public bool IsGold { get; private set; }
        private int fallDistance;

        public Sack(int x, int y)
        {
            X = x;
            Y = y;
            IsFalling = true;
            fallDistance = 0;
            IsGold = false;
        }

        public string GetImageFileName() => IsGold ? "Gold.png" : "Sack.png";
        public int GetDrawPriority() => 1; // Мешок рисуется поверх земли
        public (int dx, int dy) GetMoveDirection() => (0, 1); // Мешок падает вниз

        public ICreature OnCollision(ICreature other)
        {
            if (other is Terrain || other is Sack || other is Gold || other is Edge)
            {
                if (fallDistance > 1)  // Мешок превращается в золото, если падал более одной клетки
                {
                    IsGold = true;
                }
                IsFalling = false; // Мешок останавливается
                return this;
            }

            if (other is Player)
            {
                // Если мешок падает на игрока, он умирает
                return null;
            }

            return this;
        }

        public void Fall()
        {
            if (IsFalling)
            {
                Y++;
                fallDistance++;
            }
        }
    }

    // Класс Gold (Золото)
    public class Gold : ICreature
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Gold(int x, int y)
        {
            X = x;
            Y = y;
        }

        public string GetImageFileName() => "Gold.png";
        public int GetDrawPriority() => 2; // Золото рисуется поверх мешков
        public (int dx, int dy) GetMoveDirection() => (0, 0); // Золото не двигается

        public ICreature OnCollision(ICreature other)
        {
            if (other is Player)
            {
                Game.Scores += 10; // Игрок получает 10 очков
                return null;  // Золото исчезает
            }

            return this; // Если другие объекты, золото остаётся
        }
    }

    // Класс Edge (Край карты)
    public class Edge : ICreature
    {
        public string GetImageFileName() => "Edge.png";
        public int GetDrawPriority() => 3; // Край карты рисуется сверху
        public (int dx, int dy) GetMoveDirection() => (0, 0);
        public ICreature OnCollision(ICreature other) => this;
    }

    // Класс Monster (Монстр)
    public class Monster : ICreature
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsDead { get; private set; }

        public Monster(int x, int y)
        {
            X = x;
            Y = y;
            IsDead = false;
        }

        public string GetImageFileName() => "Monster.png";
        public int GetDrawPriority() => 2; // Монстр рисуется поверх земли, но под золотом
        public (int dx, int dy) GetMoveDirection() => (0, 0); // Для движения будет использоваться другой алгоритм

        public ICreature OnCollision(ICreature other)
        {
            // Если монстр сталкивается с игроком (диггером), он умирает
            if (other is Player)
            {
                return null; // Игрок умирает
            }

            // Если монстр сталкивается с золотом, оно исчезает
            if (other is Gold)
            {
                return null; // Золото исчезает
            }

            // Мешок может лежать на монстре, он не двигается
            if (other is Sack)
            {
                return this; // Монстр не двигается
            }

            // Если монстр сталкивается с другим монстром, оба умирают
            if (other is Monster)
            {
                return null; // Оба монстра умирают
            }

            return this;
        }

        public void MoveTowardsPlayer(Player player)
        {
            // Если игрок существует, монстр двигается к нему по горизонтали или вертикали
            if (player != null && !IsDead)
            {
                int dx = player.X - X;
                int dy = player.Y - Y;

                // Двигаемся по вертикали или горизонтали в сторону игрока
                if (Math.Abs(dx) > Math.Abs(dy))
                {
                    X += Math.Sign(dx); // Двигаемся по горизонтали
                }
                else
                {
                    Y += Math.Sign(dy); // Двигаемся по вертикали
                }
            }
        }
    }

    // Основной класс игры
    public class Game
    {
        private static Player player;
        private static List<ICreature> creatures = new List<ICreature>();  // Список всех объектов игры
        public static int Scores { get; set; } = 0;

        public static void CreateMap()
        {
            // Добавляем на карту объекты (земля, игрок, монстр, мешок и золото)
            player = new Player { X = 1, Y = 1 };
            creatures.Add(player);

            // Добавляем монстра
            var monster = new Monster(5, 5);
            creatures.Add(monster);

            // Добавляем мешок с золотом и золото
            var sack = new Sack(3, 3);
            creatures.Add(sack);
            var gold = new Gold(4, 4);
            creatures.Add(gold);

            // Заполняем карту землёй
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i != player.X || j != player.Y)
                    {
                        creatures.Add(new Terrain());
                    }
                }
            }
        }

        public static void KeyPressed(ConsoleKey key)
        {
            int dx = 0, dy = 0;

            // Определяем направление движения в зависимости от нажатой клавиши
            switch (key)
            {
                case ConsoleKey.UpArrow: dy = -1; break;
                case ConsoleKey.DownArrow: dy = 1; break;
                case ConsoleKey.LeftArrow: dx = -1; break;
                case ConsoleKey.RightArrow: dx = 1; break;
            }

            // Пробуем переместить игрока
            player.Move(dx, dy);
        }

        public static void Update()
        {
            // Обновление положения всех объектов
            foreach (var creature in creatures)
            {
                if (creature is Monster monster && !monster.IsDead)
                {
                    monster.MoveTowardsPlayer(player);
                }

                if (creature is Sack sack)
                {
                    sack.Fall();  // Мешок будет падать, если нужно
                }
            }
        }

        public static void PrintMap()
        {
            // Выводим карту
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var creature = creatures.Find(c => c is Terrain);
                    if (creature != null)
                    {
                        Console.Write(".");
                    }
                }
            }

            Console.WriteLine("Scores: " + Scores);
        }
    }

    // Класс для запуска игры
    public class Program
    {
        public static void Main(string[] args)
        {
            Game.CreateMap();
            bool gameIsRunning = true;
            while (gameIsRunning)
            {
                Console.Clear();
                Game.Update();
                Game.PrintMap();

                var key = Console.ReadKey(true).Key;
                Game.KeyPressed(key);
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
