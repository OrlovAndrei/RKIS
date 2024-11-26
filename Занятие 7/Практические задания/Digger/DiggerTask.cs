using System;
using Avalonia.Input;
using Digger.Architecture;

namespace Digger
{
    public class Terrain : ICreature
    {
        public CreatureCommand Act(int positionX, int positionY)
        {
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };
        }

        public bool DeadInConflict(ICreature conflictingObject)
        {
            return true;
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public string GetImageFileName()
        {
            return "Terrain.png";
        }
    }

    public class Player : ICreature
    {
        public static int playerX, playerY = 0;
        public static int playerDeltaX, playerDeltaY = 0;

        public CreatureCommand Act(int positionX, int positionY)
        {
            playerX = positionX;
            playerY = positionY;

            switch (Game.KeyPressed)
            {
                case Avalonia.Input.Key.Left:
                    playerDeltaY = 0;
                    playerDeltaX = -1;
                    break;

                case Avalonia.Input.Key.Up:
                    playerDeltaY = -1;
                    playerDeltaX = 0;
                    break;

                case Avalonia.Input.Key.Right:
                    playerDeltaY = 0;
                    playerDeltaX = 1;
                    break;

                case Avalonia.Input.Key.Down:
                    playerDeltaY = 1;
                    playerDeltaX = 0;
                    break;

                default:
                    Stay();
                    break;
            }

            if (!(positionX + playerDeltaX >= 0 && positionX + playerDeltaX < Game.MapWidth &&
                positionY + playerDeltaY >= 0 && positionY + playerDeltaY < Game.MapHeight))
                Stay();

            if (Game.Map[positionX + playerDeltaX, positionY + playerDeltaY] != null)
            {
                if (Game.Map[positionX + playerDeltaX, positionY + playerDeltaY].ToString() == "Digger.Sack")
                    Stay();
            }

            return new CreatureCommand() { DeltaX = playerDeltaX, DeltaY = playerDeltaY };
        }

        public bool DeadInConflict(ICreature conflictingObject)
        {
            var adjacentObject = conflictingObject.ToString();
            if (adjacentObject == "Digger.Gold")
                Game.Scores += 10;
            if (adjacentObject == "Digger.Sack" ||
                adjacentObject == "Digger.Monster")
            {
                return true;
            }
            return false;
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public string GetImageFileName()
        {
            return "Digger.png";
        }

        private static void Stay()
        {
            playerDeltaX = 0;
            playerDeltaY = 0;
        }
    }

    public class Sack : ICreature
    {
        private int fallCounter = 0;
        public static bool isDeadlyForPlayer = false;

        public CreatureCommand Act(int positionX, int positionY)
        {
            if (positionY < Game.MapHeight - 1)
            {
                var nextMapCell = Game.Map[positionX, positionY + 1];
                if (nextMapCell == null ||
                    (fallCounter > 0 && (nextMapCell.ToString() == "Digger.Player" ||
                    nextMapCell.ToString() == "Digger.Monster")))
                {
                    fallCounter++;
                    return Fall();
                }
            }

            if (fallCounter > 1)
            {
                fallCounter = 0;
                return new CreatureCommand() { DeltaX = 0, DeltaY = 0, TransformTo = new Gold() };
            }
            fallCounter = 0;
            return DoNothing();
        }

        public bool DeadInConflict(ICreature conflictingObject)
        {
            return false;
        }

        public int GetDrawingPriority()
        {
            return 5;
        }

        public string GetImageFileName()
        {
            return "Sack.png";
        }

        private CreatureCommand Fall()
        {
            return new CreatureCommand() { DeltaX = 0, DeltaY = 1 };
        }

        private CreatureCommand DoNothing()
        {
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };
        }
    }

    public class Gold : ICreature
    {
        public CreatureCommand Act(int positionX, int positionY)
        {
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };
        }

        public bool DeadInConflict(ICreature conflictingObject)
        {
            var adjacentObject = conflictingObject.ToString();
            return (adjacentObject == "Digger.Player" ||
               adjacentObject == "Digger.Monster");
        }

        public int GetDrawingPriority()
        {
            return 3;
        }

        public string GetImageFileName()
        {
            return "Gold.png";
        }
    }

    public class Monster : ICreature
    {
        public CreatureCommand Act(int positionX, int positionY)
        {
            int monsterDeltaX = 0;
            int monsterDeltaY = 0;

            if (IsPlayerAlive())
            {
                if (Player.playerX == positionX)
                {
                    if (Player.playerY < positionY) monsterDeltaY = -1;
                    else if (Player.playerY > positionY) monsterDeltaY = 1;
                }
                else if (Player.playerY == positionY)
                {
                    if (Player.playerX < positionX) monsterDeltaX = -1;
                    else if (Player.playerX > positionX) monsterDeltaX = 1;
                }
                else
                {
                    if (Player.playerX < positionX) monsterDeltaX = -1;
                    else if (Player.playerX > positionX) monsterDeltaX = 1;
                }
            }
            else return Stay();

            if (!(positionX + monsterDeltaX >= 0 && positionX + monsterDeltaX < Game.MapWidth &&
                positionY + monsterDeltaY >= 0 && positionY + monsterDeltaY < Game.MapHeight))
                return Stay();

            var nextMapCell = Game.Map[positionX + monsterDeltaX, positionY + monsterDeltaY];
            if (nextMapCell != null)
                if (nextMapCell.ToString() == "Digger.Terrain" ||
                    nextMapCell.ToString() == "Digger.Sack" ||
                    nextMapCell.ToString() == "Digger.Monster")
                    return Stay();
            return new CreatureCommand() { DeltaX = monsterDeltaX, DeltaY = monsterDeltaY };
        }

        public bool DeadInConflict(ICreature conflictingObject)
        {
            var adjacentObject = conflictingObject.ToString();
            return (adjacentObject == "Digger.Sack" ||
            adjacentObject == "Digger.Monster");
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public string GetImageFileName()
        {
            return "Monster.png";
        }

        static private CreatureCommand Stay()
        {
            return new CreatureCommand() { DeltaX = 0, DeltaY = 0 };
        }

        static private bool IsPlayerAlive()
        {
            for (int i = 0; i < Game.MapWidth; i++)
                for (int j = 0; j < Game.MapHeight; j++)
                {
                    var nextMapCell = Game.Map[i, j];
                    if (nextMapCell != null)
                    {
                        if (nextMapCell.ToString() == "Digger.Player")
                        {
                            Player.playerX = i;
                            Player.playerY = j;
                            return true;
                        }
                    }
                }
            return false;
        }
    }
}