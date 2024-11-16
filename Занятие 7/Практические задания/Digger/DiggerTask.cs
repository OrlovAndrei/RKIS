using System;
using System.Collections.Generic;

namespace Digger
{
    public interface ICreature
    {
        string GetImageFileName();
        int GetDrawPriority();
        (int dx, int dy) GetMoveDirection();
        ICreature OnCollision(ICreature other);
        int GetX();
        int GetY();
    }

    public class Terrain : ICreature
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string GetImageFileName() => "Terrain.png";
        public int GetDrawPriority() => 0;
        public (int dx, int dy) GetMoveDirection() => (0, 0);
        public ICreature OnCollision(ICreature other) => this;

        public int GetX() => X;
        public int GetY() => Y;
    }

    public class Player : ICreature
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string GetImageFileName() => "Player.png";
        public int GetDrawPriority() => 1;
        public (int dx, int dy) GetMoveDirection() => (0, 0);

        public ICreature OnCollision(ICreature other)
        {
            if (other is Gold)
            {
                Game.Scores += 10;
                return null;
            }

            if (other is Sack)
            {
                return null;
            }

            return this;
        }

        public int GetX() => X;
        public int GetY() => Y;

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }

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
        public int GetDrawPriority() => 1;
        public (int dx, int dy) GetMoveDirection() => (0, 1);

        public ICreature OnCollision(ICreature other)
        {
            if (other is Terrain || other is Sack || other is Gold || other is Edge)
            {
                if (fallDistance > 1)
                {
                    IsGold = true;
                }
                IsFalling = false;
                return this;
            }

            if (other is Player)
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

        public int GetX() => X;
        public int GetY() => Y;
    }

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
        public int GetDrawPriority() => 2;
        public (int dx, int dy) GetMoveDirection() => (0, 0);

        public ICreature OnCollision(ICreature other)
        {
            if (other is Player)
            {
                Game.Scores += 10;
                return null;
            }

            return this;
        }

        public int GetX() => X;
        public int GetY() => Y;
    }

    public class Edge : ICreature
    {
        public string GetImageFileName() => "Edge.png";
        public int GetDrawPriority() => 3;
        public (int dx, int dy) GetMoveDirection() => (0, 0);
        public ICreature OnCollision(ICreature other) => this;

        public int GetX() => 0;
        public int GetY() => 0;
    }

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
        public int GetDrawPriority() => 2;
        public (int dx, int dy) GetMoveDirection() => (0, 0);

        public ICreature OnCollision(ICreature other)
        {
            if (other is Player)
            {
                return null;
            }

            if (other is Gold)
            {
                return null;
            }

            if (other is Sack)
            {
                return this;
            }

            if (other is Monster)
            {
                return null;
            }

            return this;
        }

        public void MoveTowardsPlayer(Player player)
        {
            if (player != null && !IsDead)
            {
                int dx = player.X - X;
                int dy = player.Y - Y;

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

        public int GetX() => X;
        public int GetY() => Y;
    }

    public class Game
    {
        private static Player player;
        private static List<ICreature> creatures = new List<ICreature>();
        public static int Scores { get; set; } = 0;

        public static void CreateMap()
        {
            player = new Player { X = 1, Y = 1 };
            creatures.Add(player);

            var monster = new Monster(5, 5);
            creatures.Add(monster);

            var sack = new Sack(3, 3);
            creatures.Add(sack);
            var gold = new Gold(4, 4);
            creatures.Add(gold);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    creatures.Add(new Terrain { X = i, Y = j });
                }
            }
        }

        public static void KeyPressed(ConsoleKey key)
        {
            int dx = 0, dy = 0;

            switch (key)
            {
                case ConsoleKey.UpArrow: dy = -1; break;
                case ConsoleKey.DownArrow: dy = 1; break;
                case ConsoleKey.LeftArrow: dx = -1; break;
                case ConsoleKey.RightArrow: dx = 1; break;
            }

            player.Move(dx, dy);
        }

        public static void Update()
        {
            foreach (var creature in creatures)
            {
                if (creature is Monster monster && !monster.IsDead)
                {
                    monster.MoveTowardsPlayer(player);
                }

                if (creature is Sack sack)
                {
                    sack.Fall();
                }
            }
        }

        public static void PrintMap()
        {
            var map = new char[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    map[i, j] = '.';
                }
            }

            foreach (var creature in creatures)
            {
                int x = creature.GetX();
                int y = creature.GetY();

                if (x >= 0 && x < 10 && y >= 0 && y < 10)
                {
                    map[x, y] = creature.GetImageFileName()[0];
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

            Console.WriteLine($"Scores: {Scores}");
        }
    }

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
