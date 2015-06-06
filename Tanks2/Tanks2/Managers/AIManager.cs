using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEntity;
using Core;
using PathFinder;

namespace Managers
{
    class AIManager
    {
        public const string UP = "UP#";
        public const string DOWN = "DOWN#";
        public const string LEFT = "LEFT#";
        public const string RIGHT = "RIGHT#";
        public const string SHOOT = "SHOOT#";
        public void Move(Player me, Cell current, Grid grid)
        {
            int health = me.health;
            NetworkListener listener = NetworkListener.GetInstance();
            PathFind finder = new PathFind();
            Cell firstCell = null;
            Cell end = new EmptyCell();            
            List<Cell> path;
            int[] endCoordinates;

            if (health < 50)
            {
                endCoordinates = PathFinder.TreasureFinder.FindNextTreasure(current, grid.GetGrid(), 4);                    
            }
            else
            {
                endCoordinates = PathFinder.TreasureFinder.FindNextTreasure(current, grid.GetGrid(), 5);                
            }

            if (endCoordinates.Length != 0)
            {
                end.x = endCoordinates[1];
                end.y = endCoordinates[0];
                path = finder.FindPath(current, end);
                firstCell = path.ElementAt(1);
            }

            if (firstCell != null)
            {
                if (firstCell.priority == 1)
                {
                    listener.sendMessage(SHOOT);
                }
                else if (current.x == firstCell.x && current.y > firstCell.y)
                {
                    listener.sendMessage(UP);
                }
                else if (current.x == firstCell.x && current.y < firstCell.y)
                {
                    listener.sendMessage(DOWN);
                }
                else if (current.y == firstCell.y && current.x > firstCell.x)
                {
                    listener.sendMessage(LEFT);
                }
                else if (current.y == firstCell.y && current.x < firstCell.x)
                {
                    listener.sendMessage(RIGHT);
                }
            }
        }
    }
}
