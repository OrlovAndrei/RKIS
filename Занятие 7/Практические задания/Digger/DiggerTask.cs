using System;

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

    // Основной класс игры
    public class Game
    {
        private static Player player;
        private static ICreature[,] map;  // Массив для хранения объектов на карте
        public static int Scores { get; set; } = 0;

        public static void CreateMap()
        {
            map = new ICreature[10, 10];  // Создаём карту размером 10x10

            // Заполняем карту землёй
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    map[x, y] = new Terrain();
                }
            }

            // Создаём игрока на позиции (1, 1)
            player = new Player { X = 1, Y = 1 };
            map[1, 1] = player;

            // Добавляем объекты на карту (мешки и золото)
            map[3, 3] = new Sack(3, 3);
            map[4, 4] = new Sack(4, 4);
            map[5, 5] = new Gold(5, 5);
            map[9, 9] = new Edge(); // Край карты
        }

        public static void KeyPressed(ConsoleKey key)
        {
            int dx = 0, dy = 0;

            // Определяем направление движения в зависимости от нажатой клавиши
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    dy = -1;
                    break;
                case ConsoleKey.DownArrow:
                    dy = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    dx = -1;
                    break;
                case ConsoleKey.RightArrow:
                    dx = 1;
                    break;
            }

            // Пробуем переместить игрока
            int newX = player.X + dx;
            int newY = player.Y + dy;

            // Проверяем, что игрок не выходит за пределы карты
            if (newX >= 0 && newX < 10 && newY >= 0 && newY < 10)
            {
                ICreature target = map[newX, newY];
                ICreature newTile = target.OnCollision(player);

                if (newTile == null)
                {
                    map[newX, newY] = newTile;  // Если взаимодействие прошло успешно
                }

                // Перемещаем игрока
                player.X = newX;
                player.Y = newY;
            }
        }

        public static void Update()
        {
            // Обновление состояния объектов на карте (падение мешков)
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    var creature = map[x, y];
                    if (creature is Sack)
                    {
                        var sack = (Sack)creature; // Явно кастуем мешок
                        sack.Fall();  // Мешок падает
                    }
                }
            }
        }

        public static void PrintMap()
        {
            // Метод для вывода карты в консоль
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Console.Write(map[x, y] is Terrain ? "." :
                                  map[x, y] is Player ? "P" :
                                  map[x, y] is Sack ? "S" :
                                  map[x, y] is Gold ? "G" : "E");
                }
                Console.WriteLine();
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

            // Основной цикл игры
            bool gameIsRunning = true;
            while (gameIsRunning)
            {
                Console.Clear();
                Game.Update();  // Обновляем состояние объектов
                Game.PrintMap();  // Отображаем текущую карту

                // Получаем ввод от пользователя
                var key = Console.ReadKey(true).Key;

                // Обрабатываем нажатую клавишу
                Game.KeyPressed(key);

                // Пауза между итерациями
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
