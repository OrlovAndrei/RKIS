using System;
using Avalonia.Input;

namespace Digger;

//Напишите здесь классы Player, Terrain и другие.
public class Player : ICreature
    {
        public CreatureCommand CrCmd = new CreatureCommand
        {
            DeltaX = 0,
            DeltaY = 0,
            TransformTo = null
        };

        public string GetImageFileName()
        {
            return "Digger.png";
        }

        public int GetDrawingPriority()
        {
            return 3;
        }

        public CreatureCommand Act(int x, int y)
        {
            CrCmd.DeltaX = 0;
            CrCmd.DeltaY = 0;
            switch (Game.KeyPressed)
            {
                case System.Windows.Forms.Keys.Up:
                    if (y - 1 >= 0 && IsNotSack(Game.Map[x, y - 1])) //&& IsNotMonster(Game.Map[x, y - 1]))
                        CrCmd.DeltaY = -1;
                    /*
                    if (y - 1 >= 0 && !IsNotMonster(Game.Map[x, y - 1]))
                    {
                        //CrCmd.DeltaY = -1;
                        CrCmd.TransformTo = null;
                    }*/
                    break;
                case System.Windows.Forms.Keys.Down:
                    if (y + 1 < Game.MapHeight && IsNotSack(Game.Map[x, y + 1])) // && IsNotMonster(Game.Map[x, y + 1]))
                        CrCmd.DeltaY = 1;
                    /*if (y + 1 >= 0 && !IsNotMonster(Game.Map[x, y + 1]))
                    {
                        //CrCmd.DeltaY = 1;
                        CrCmd.TransformTo = null;
                    }
                    */
                    break;
                case System.Windows.Forms.Keys.Left:
                    if (x - 1 >= 0 && IsNotSack(Game.Map[x - 1, y]))// && IsNotMonster(Game.Map[x - 1, y]))
                        CrCmd.DeltaX = -1;
                    /*if (x - 1 >= 0 && !IsNotMonster(Game.Map[x - 1, y]))
                    {
                        //CrCmd.DeltaX = -1;
                        CrCmd.TransformTo = null;
                    }
                    */
                    break;
                case System.Windows.Forms.Keys.Right:
                    if (x + 1 < Game.MapWidth && IsNotSack(Game.Map[x + 1, y]))// && IsNotMonster(Game.Map[x + 1, y]))
                        CrCmd.DeltaX = 1;
                    /*if (x + 1 >= 0 && !IsNotMonster(Game.Map[x + 1, y]))
                    {
                        //CrCmd.DeltaX = 1;
                        CrCmd.TransformTo = null;
                   }
                   */
                    break;
            }
            return CrCmd;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            var a = conflictedObject.GetDrawingPriority();
            return a > 0 ? true : false;
        }

        public bool IsNotMonster(ICreature conflictedObject)
        {
            if (conflictedObject == null) return true;
            var a = conflictedObject.GetImageFileName();
            //var b = conflictedObject;
            return !(a == "Monster.png");
        }

        public bool IsNotSack(ICreature conflictedObject)
        {
            if (conflictedObject == null) return true;
            var a = conflictedObject.GetImageFileName();
            //var b = conflictedObject;
            return !(a == "Sack.png");
        }
    }

    public class Terrain : ICreature
    {
        public CreatureCommand CrCmd = new CreatureCommand
        {
            DeltaX = 0,
            DeltaY = 0,
            TransformTo = null
        };

        public string GetImageFileName()
        {
            return "Terrain.png";
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public CreatureCommand Act(int x, int y)
        {
            CrCmd.DeltaX = 0;
            CrCmd.DeltaY = 0;
            Game.Map[x, y] = null;
            return CrCmd;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            var a = conflictedObject.GetDrawingPriority();
            return a > 0 ? true : false;
        }
    }

    public class Sack : ICreature
    {
        public int NumberOfSteps = 0;
public CreatureCommand CrCmd = new CreatureCommand
        {
            DeltaX = 0,
            DeltaY = 0,
            TransformTo = null
        };

        public string GetImageFileName()
        {
            return "Sack.png";
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public CreatureCommand Act(int x, int y)
        {
            CrCmd.DeltaX = 0;
            CrCmd.DeltaY = 0;
            //var k = 0;
            //обнуление счетчика падения, если под мешком ничего нет
            if (y + 1 < Game.MapHeight)
                if (Game.Map[x, y + 1] != null &&
                !DeadInConflict2(Game.Map[x, y + 1]))
                    NumberOfSteps = 0;

            //движение вниз и превращение в новый мешок или золото
            if (y + 1 < Game.MapHeight &&
                (Game.Map[x, y + 1] == null || DeadInConflict2(Game.Map[x, y + 1])
                && NumberOfSteps > 0))
            {
                NumberOfSteps++;
                if (NumberOfSteps == 1 || DeadInConflict2(Game.Map[x, y + 1]))
                    CrCmd.TransformTo = new Sack() { NumberOfSteps = NumberOfSteps + 1 };
                else
                    if (NumberOfSteps > 1 && y + 2 < Game.MapHeight &&
                        Game.Map[x, y + 2] != null && !DeadInConflict2(Game.Map[x, y + 2])
                        || NumberOfSteps > 1 && y + 2 == Game.MapHeight)
                    CrCmd.TransformTo = new Gold() { Flag = true };
                CrCmd.DeltaY = 1;
            }

            return CrCmd;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public bool DeadInConflict2(ICreature conflictedObject)
        {
            if (conflictedObject == null) return false;
            var a = conflictedObject.GetImageFileName();
            if (a == "Digger.png" || a == "Monster.png")
                return true;
            return false;
        }
    }

    public class Gold : ICreature
    {
        public bool Flag = false;
        public CreatureCommand CrCmd = new CreatureCommand
        {
            DeltaX = 0,
            DeltaY = 0,
            TransformTo = null
        };

        public string GetImageFileName()
        {
            return "Gold.png";
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public CreatureCommand Act(int x, int y)
        {
            CrCmd.DeltaX = 0;
            CrCmd.DeltaY = 0;

            if (y + 1 < Game.MapHeight)
                if (Game.Map[x, y + 1] != null) Flag = false;

            if (Flag)
            {
                if (y + 1 < Game.MapHeight)
                    if (!Conflict(Game.Map[x, y + 1], "Digger.png"))
                    {
                        Game.Map[x, y + 1] = null;
                        CrCmd.TransformTo = new Sack();
                        CrCmd.DeltaY += 1;
                        return CrCmd;
                    }
                if (y + 1 < Game.MapHeight && Game.Map[x, y + 1] == null)
                {
                    if (y + 2 < Game.MapHeight && Game.Map[x, y + 2] != null
                        || y + 2 == Game.MapHeight)
                        CrCmd.TransformTo = new Gold() { Flag = true };
                    CrCmd.DeltaY = 1;
                }
            }
            return CrCmd;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            var a = conflictedObject.GetDrawingPriority();
            Game.Scores += 10;
            return a > 0 ? true : false;
        }

        public bool Conflict(ICreature conflictedObject, string name)
        {
            if (conflictedObject == null) return true;
            var a = conflictedObject.GetImageFileName();
            return a == name;
        }
    }
    
    public class Monster : ICreature
    {
        public CreatureCommand CrCmd = new CreatureCommand
        {
            DeltaX = 0,
            DeltaY = 0,
            TransformTo = null
        };
public string GetImageFileName()
        {
            return "Monster.png";
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public CreatureCommand Act(int x, int y)
        {
            var flagDiggerOn = false;
            int i = 0;
            int j = 0;
            for (i = 0; i < Game.MapWidth; i++)
            {
                for (j = 0; j < Game.MapHeight; j++)
                
                    if (IsDigger(Game.Map[i, j]))
                    {
                        flagDiggerOn = true;
                        break;
                    }
                if (flagDiggerOn)
                    break;
            }

            CrCmd.DeltaX = 0;
            CrCmd.DeltaY = 0;
            
            if (!flagDiggerOn)
                return CrCmd;
            else
            {
                var distanceFromXtoI = Math.Abs(x - i);
                var distanceFromYtoJ = Math.Abs(y - j);
                var sign1 = 0;        var sign2 = 0;
                if (x - i >= 0) sign1 = 1; else sign1 = -1;
                if (y - j >= 0) sign2 = 1; else sign2 = -1;
                /*
                if (distanceFromXtoI > 0 && distanceFromYtoJ >0)
                    if (x + sign1 < Game.MapWidth && x + sign1>=0 &&    CanMove(Game.Map[x+sign1, y]))
                        CrCmd.DeltaX = x + sign1;
                else if (y + sign2 < Game.MapHeight && y + sign2 >= 0 &&    CanMove(Game.Map[x , y + sign2]))
                        CrCmd.DeltaY = y + sign2;
                */

                //if (Conflict(Game.Map[x, y], "Digger.png"))
                //    CrCmd.TransformTo = null;
                
                if (y + 1 < Game.MapHeight &&
                    (Game.Map[x, y + 1] == null || Conflict2(Game.Map[x, y + 1])))  //CanMove(Game.Map[x, y + 1]))
                {
                    CrCmd.TransformTo = new Monster();
                    CrCmd.DeltaY = 1;
                    return CrCmd;
                }/*
                else
                    if (y + 1 < Game.MapHeight && !Conflict2(Game.Map[x, y + 1]) && CanMove(Game.Map[x, y + 1]))
                {
                    CrCmd.TransformTo = new Monster();
                    CrCmd.DeltaY = 1;
                }*/
                
                else
                if (y - 1 >= 0 &&
                    (Game.Map[x, y - 1] == null || Conflict2(Game.Map[x, y - 1])))
                {
                    CrCmd.TransformTo = new Monster();
                    CrCmd.DeltaY = -1;
                    return CrCmd;
                }
                else
                if (x - 1 >= 0  &&
                    (Game.Map[x - 1, y] == null || !Conflict2(Game.Map[x - 1, y])))
                {
                    CrCmd.TransformTo = new Monster();
                    CrCmd.DeltaX = -1;
                    return CrCmd;
                }
                else
                if (x + 1 < Game.MapWidth &&
                    (Game.Map[x + 1, y] == null || !Conflict2(Game.Map[x + 1, y])))
                {
                    CrCmd.TransformTo = new Monster();
                    CrCmd.DeltaX = 1;
                    return CrCmd;
                }
            }
            return CrCmd;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            var a = conflictedObject.GetDrawingPriority();            
            return a > 0 ? true : false;
        }
        public bool IsDigger(ICreature conflictedObject)
        {
            if (conflictedObject == null) return true;
            var a = conflictedObject.GetImageFileName();
            return a == "Digger.png";
        }

        public bool Conflict(ICreature conflictedObject, string name)
        {
            if (conflictedObject == null) return false;
            var a = conflictedObject.GetImageFileName();
            return a == name;
        }
public bool Conflict2(ICreature conflictedObject)
        {
            if (conflictedObject == null) return false;
            var a = conflictedObject.GetImageFileName();
            if (a == "Digger.png")
            //if (a == "Sack.png"  a == "Monster.png")
                return true;
            return false;
        }


        public bool CanMove(ICreature conflictedObject)
        {
            if (conflictedObject == null) return true;
            var a = conflictedObject.GetImageFileName();
            if (a == "Sack.png") return false;
            if (a == "Gold.png") return true;
            if (a == "Terrain.png") return false;
            if (a == "Monster.png") return false;
            return true;
        }

    }
}
