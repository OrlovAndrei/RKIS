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
        public string GetImageFileName()
        {
            return "Terrain.png"; // Изображение земли
        }

        public int GetDrawPriority()
        {
            return 0; // Земля рисуется в самом низу
        }

        public (int dx, int dy) GetMoveDirection()
        {
            return (0, 0); // Земля не двигается
        }

        public ICreature OnCollision(ICreature other)
        {
            return this; // Столкновение с землёй не меняет её состояние
        }
    }

    // Класс Player (игрок)
    public class Player : ICreature
    {
        public int X { get; set; }  // Позиция игрока по оси X
        public int Y { get; set; }  // Позиция игрока по оси Y

        public string GetImageFileName()
        {
            return "Player.png";  // Изображение игрока
        }

        public int GetDrawPriority()
        {
            return 1;  // Игрок рисуется поверх земли
        }

        public (int dx, int dy) GetMoveDirection()
        {
            return (0, 0);  // Игрок не двигается автоматически, мы будем изменять его положение вручную
        }

        public ICreature OnCollision(ICreature other)
        {
            // Игрок может менять землю на пути своего движения
            if (other is Terrain)
            {
                // Если игрок сталкивается с землёй, земля исчезает (например, можно заменить её на какой-то другой объект)
                return null;  // После того как игрок пройдёт, земля исчезает
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

    // Основной класс игры
    public class Game
    {
        private static Player player;
        private static Terrain[,] map;

        public static void CreateMap()
        {
            // Создаём карту размером 10x10 клеток
            map = new Terrain[10, 10];

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
                // Если позиция свободна (там земля), обновляем карту
                ICreature target = map[newX, newY];
                ICreature newTile = target.OnCollision(player);

                if (newTile == null)
                {
                    // Земля исчезает
                    map[newX, newY] = new Terrain();
                }

                // Двигаем игрока
                player.Move(dx, dy);
            }
        }

        public static void PrintMap()
        {
            // Метод для вывода карты в консоль
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Console.Write(map[x, y] is Terrain ? "." : "P"); // "." — это земля, "P" — игрок
                }
                Console.WriteLine();
            }
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
                Game.PrintMap(); // Отображаем текущую карту

                // Получаем ввод от пользователя
                var key = Console.ReadKey(true).Key;

                // Обрабатываем нажатую клавишу
                Game.KeyPressed(key);

                // Пауза, чтобы игрок мог увидеть изменения
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
