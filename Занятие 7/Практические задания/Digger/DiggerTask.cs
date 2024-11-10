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
