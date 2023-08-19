using Pacman.GameGL;
using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GL
{
    internal class RGhost:Ghost
    {
        public RGhost(Image displayCharacter, GameCell g) : base(displayCharacter, g)
        {

            this.CurrentCell = g;
            this.DisplayCharacter = displayCharacter;
        }
        public override GameCell move()
        {
            if (prevObject == GameObjectType.REWARD)
            {
                CurrentCell.setGameCbject(Game.GetRewardObject());
            }
            else if (prevObject == GameObjectType.NONE)
            {
                CurrentCell.setGameCbject(Game.GetBlankObject());
            }
            int value = ghostDirection();
            Direction = (GameDirection)value;
            //if (value == 0)
            //{
            //    Direction = GameDirection.Right;
            //}
            //if (value == 1)
            //{
            //    Direction = GameDirection.Left;
            //}
            //if (value == 2)
            //{
            //    Direction = GameDirection.Down;
            //}
            //if (value == 3)
            //{
            //    Direction = GameDirection.Up;
            //}
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(Direction);
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD)
            {
                prevObject = GameObjectType.REWARD;
            }
            else if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.NONE)
            {
                prevObject = GameObjectType.NONE;
            }
            CurrentCell = nextCell;
            /*if (currentCell != nextCell)
            {
                currentCell.setGameCbject(Game.GetBlankObject());

            }*/
            return CurrentCell.nextCell(Direction);
        }

        public int ghostDirection()
        {
            Random r = new Random();
            int value = r.Next(4);
            return value;
        }
    }
}
