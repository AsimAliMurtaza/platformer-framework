using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GameGL
{
    internal class Collisions
    {
        public static bool playerCollisionWithPallet(GameCell gamecell)
        {
            if(gamecell.CurrentGameObject.GameObjectType==GameObjectType.REWARD)
            {
                return true;
            }
            return false;
        }
        public static bool playerCollisionWithEnemy(GameCell gamecell)
        {
            if (gamecell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
            {
                return true;
            }
            return false;
        }
        public static bool playerCollisionWithEnemy(GameObject p, GameObject g)
        {
            if (p.CurrentCell.X == g.CurrentCell.X && p.CurrentCell.Y == g.CurrentCell.Y)
            {
                return true;
            }
            return false;
        }
        public static bool checkReward(GameCell gameCell)
        {
            if(gameCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD) { return true; }
            return false;
        }

    }
}
