using System;
using System.Collections.Generic;

namespace DiggerGame
{
    public interface IGameEntity
    {
        string GetImage();
        int GetRenderPriority();
        (int dx, int dy) GetMovement();
        IGameEntity HandleCollision(IGameEntity other);
        int X { get; set; }
        int Y { get; set; }
    }

    public class Ground : IGameEntity
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string GetImage() => "Ground.png";
        public int GetRenderPriority() => 0;
        public (int dx, int dy) GetMovement() => (0, 0);
        public IGameEntity HandleCollision(IGameEntity other) => this;
    }

    public class Character : IGameEntity
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string GetImage() => "Character.png";
        public int GetRenderPriority() => 1;
        public (int dx, int dy) GetMovement() => (0, 0);

        public IGameEntity HandleCollision(IGameEntity other)
        {
            if (other is Treasure)
            {
                Game.UpdateScore(10);
                return null;
            }

            if (other is Bag)
            {
                return null;
            }

            return this;
        }

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }

    public class Bag : IGameEntity
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsFalling { get; private set; }
        public bool ContainsGold { get; private set; }
        private int fallDistance;

        public Bag(int x, int y)
        {
            X = x;
            Y = y;
            IsFalling = true;
            fallDistance = 0;
            ContainsGold = false;
        }

        public string GetImage() => ContainsGold ? "Gold.png" : "Bag.png";
        public int GetRenderPriority() => 1;
        public (int dx, int dy) GetMovement() => (0, 1);

        public IGameEntity HandleCollision(IGameEntity other)
        {
            if (other is Ground || other is Bag || other is Treasure || other is Border)
            {
                if (fallDistance > 1)
                {
                    ContainsGold = true;
                }
                IsFalling = false;
                return this;
            }

            if (other is Character)
            {
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

    public class Treasure : IGameEntity
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Treasure(int x, int y)
        {
            X = x;
            Y = y;
        }

        public string GetImage() => "Gold.png";
        public int GetRenderPriority() => 2;
        public (int dx, int dy) GetMovement() => (0, 0);

        public IGameEntity HandleCollision(IGameEntity other)
        {
            if (other is Character)
            {
                Game.UpdateScore(10);
                return null;
            }

            return this;
        }
    }

    public class Border : IGameEntity
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string GetImage() => "Border.png";
        public int GetRenderPriority() => 3;
        public (int dx, int dy) GetMovement() => (0, 0);
        public IGameEntity HandleCollision(IGameEntity other) => this;
    }

    public class Monster : IGameEntity
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

        public string GetImage() => "Monster.png";
        public int GetRenderPriority() => 2;
        public (int dx, int dy) GetMovement() => (0, 0);

        public IGameEntity HandleCollision(IGameEntity other)
        {
            if (other is Character)
            {
                return null;
            }

            if (other is Treasure)
            {
                return null;
            }

            if (other is Bag)
            {
                return this;
            }

            if (other is Monster)
            {
                return null;
            }

            return this;
        }

        public void MoveTowardsCharacter(Character character)
        {
            if (character != null && !IsDead)
            {
                int dx = character.X - X;
                int dy = character.Y - Y;

                if (Math.Abs(dx) > Math.Abs(dy))
                {
                    X += Math.Sign(dx);
                }
                else
                {
                    Y += Math.Sign(dy);
                }
            }
        }
    }

    public static class Game
    {
        private static Character character;
        private static List<IGameEntity> gameEntities = new List<IGameEntity>();
        public static int Score { get; private set; } = 0;

        public static void InitializeMap()
        {
            character = new Character { X = 1, Y = 1 };
            gameEntities.Add(character);

            var monster = new Monster(5, 5);
            gameEntities.Add(monster);

            var bag = new Bag(3, 3);
            gameEntities.Add(bag);
            var treasure = new Treasure(4, 4);
            gameEntities.Add(treasure);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    gameEntities.Add(new Ground { X = i, Y = j });
                }
            }
        }

        public static void OnKeyPress(ConsoleKey key)
        {
            int dx = 0, dy = 0;

            switch (key)
            {
                case ConsoleKey.UpArrow: dy = -1; break;
                case ConsoleKey.DownArrow: dy = 1; break;
                case ConsoleKey.LeftArrow: dx = -1; break;
                case ConsoleKey.RightArrow: dx = 1; break;
            }

            character.Move(dx, dy);
        }

        public static void UpdateGame()
        {
            foreach (var entity in gameEntities)
            {
                if (entity is Monster monster && !monster.IsDead)
                {
                    monster.MoveTowardsCharacter(character);
                }

                if (entity is Bag bag)
                {
                    bag.Fall();
                }
            }
        }

        public static void RenderMap()
        {
            var map = new char[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    map[i, j] = '.';
                }
            }

            foreach (var entity in gameEntities)
            {
                int x = entity.X;
                int y = entity.Y;

                if (x >= 0 && x < 10 && y >= 0 && y < 10)
                {
                    map[x, y] = entity.GetImage()[0];
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Score: {Score}");
        }

        public static void UpdateScore(int points)
        {
            Score += points;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Game.InitializeMap();
            bool gameRunning = true;
            while (gameRunning)
            {
                Console.Clear();
                Game.UpdateGame();
                Game.RenderMap();

                var key = Console.ReadKey(true).Key;
                Game.OnKeyPress(key);
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
