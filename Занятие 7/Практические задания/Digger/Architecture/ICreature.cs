using System.Windows.Forms;
using static Digger.Game;

namespace Digger
{
    public class Terrain : ICreature
    {
        public CreatureCommand Act(int x, int y) => new CreatureCommand { DeltaX = 0, DeltaY = 0 };

        public bool DeadInConflict(ICreature conflictedObject) => conflictedObject is Player;

        public int GetDrawingPriority() => 4;

        public string GetImageFileName() => "Terrain.png";
    }

    public class Player : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            int delX = 0;
            int delY = 0;
            switch (KeyPressed)
            {
                case Keys.Left:
                    if (x - 1 >= 0 && (Map[x - 1, y] == null || Map[x - 1, y] is Sack))
                        delX = -1;
                    break;
                case Keys.Up:
                    if (y - 1 >= 0 && (Map[x, y - 1] == null || Map[x, y - 1] is Sack))
                        delY = -1;
                    break;
                case Keys.Right:
                    if (x + 1 < MapWidth && (Map[x + 1, y] == null || Map[x + 1, y] is Sack))
                        delX = 1;
                    break;
                case Keys.Down:
                    if (y + 1 < MapHeight && (Map[x, y + 1] == null || Map[x, y + 1] is Sack))
                        delY = 1;
                    break;
            }
            return new CreatureCommand { DeltaX = delX, DeltaY = delY };
        }

        public bool DeadInConflict(ICreature conflictedObject) =>
            conflictedObject is Sack || conflictedObject is Monster;

        public int GetDrawingPriority() => 0;

        public string GetImageFileName() => "Digger.png";
    }

    public class Sack : ICreature
    {
        public int FreeFall;
        public bool IsFalling;

        public CreatureCommand Act(int x, int y)
        {
            int delY = 0;
            if (y + 1 < MapHeight &&
                (Map[x, y + 1] == null || ((Map[x, y + 1] is Player
                                            || Map[x, y + 1] is Monster) && IsFalling)))
            {
                delY++;
                FreeFall++;
                IsFalling = true;
                return new CreatureCommand { DeltaY = delY };
            }
            if (FreeFall > 1)
                return new CreatureCommand { DeltaY = delY, TransformTo = new Gold() };
            FreeFall = 0;
            IsFalling = false;
            return new CreatureCommand { DeltaY = delY };
        }

        public bool DeadInConflict(ICreature conflictedObject) => false;

        public int GetDrawingPriority() => 3;

        public string GetImageFileName() => "Sack.png";
    }

    public class Gold : ICreature
    {
        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Player)
                Scores += 10;
            return true;
        }

        public int GetDrawingPriority() => 1;

        public string GetImageFileName() => "Gold.png";
    }

    public class Monster : ICreature
    {
        public CreatureCommand Act(int x, int y)
        {
            for (var width = 0; width < MapWidth; width++)
                for (var height = 0; height < MapHeight; height++)
                    if (Map[width, height] is Player)
                    {
                        if (x.CompareTo(width) > 0)
                            if ((x - 1 >= 0) && !(Map[x - 1, y] is Terrain)
                                && !(Map[x - 1, y] is Sack))
                                return new CreatureCommand { DeltaX = -1 };
                        if (x.CompareTo(width) < 0)
                            if ((x + 1 < MapWidth) && !(Map[x + 1, y] is Terrain)
                                && !(Map[x + 1, y] is Sack))
                                return new CreatureCommand { DeltaX = 1 };
                        if (y.CompareTo(height) < 0)
                            if ((y + 1 < MapHeight) && !(Map[x, y + 1] is Terrain)
                                && !(Map[x, y + 1] is Sack))
                                return new CreatureCommand { DeltaY = 1 };
                        if (y.CompareTo(height) > 0)
                            if ((y - 1 >= 0) && !(Map[x, y - 1] is Terrain)
                                && !(Map[x, y - 1] is Sack))
                                return new CreatureCommand { DeltaY = -1 };
                    }
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject) => conflictedObject is Sack;

        public int GetDrawingPriority() => 2;

        public string GetImageFileName() => "Monster.png";
    }
}