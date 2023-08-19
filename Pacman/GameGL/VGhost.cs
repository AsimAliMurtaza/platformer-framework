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
    internal class VGhost:Ghost
    {
       // private bool isMoving;
        public VGhost(Image displayCharacter, GameCell g, GameDirection direction):base(displayCharacter, g) {

            this.CurrentCell = g;
            this.DisplayCharacter = displayCharacter;
            //this.isMoving = true;
            this.Direction = direction;
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
            nextCell.setGameCbject(this);
            this.CurrentCell = nextCell;
            /*if (currentCell != nextCell)
            {
                currentCell.setGameCbject(Game.GetBlankObject());

            }*/
            if (nextCell == currentCell)
                if (Direction == GameDirection.Up)
                {
                    Direction = GameDirection.Down;
                }
                else
                {
                    Direction = GameDirection.Up;
                }
            return nextCell.nextCell(Direction);
            /*GameCell cell;
            if(isMoving)
            {
                cell = this.CurrentCell.nextCell(GameDirection.Up);
                if(cell != null && cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                { 
                    CurrentCell = cell;
                    if (CurrentCell != cell)
                    {
                        currentCell.setGameCbject(Game.GetBlankObject());
                    }
                }
                else
                {
                    isMoving = false;
                    cell = this.CurrentCell.nextCell(GameDirection.Down);
                    if (cell != null && cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        CurrentCell = cell;
                        if (CurrentCell != cell)
                        {
                            currentCell.setGameCbject(Game.GetBlankObject());
                        }
                    }
                }
            }
            else
            {
                cell = this.CurrentCell.nextCell(GameDirection.Down);
                if (cell != null && cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                {
                    CurrentCell = cell;
                    if (CurrentCell != cell)
                    {
                        currentCell.setGameCbject(Game.GetBlankObject());
                    }
                }
                else
                {
                    isMoving = true;
                    cell = this.CurrentCell.nextCell(GameDirection.Up);
                    if (cell != null && cell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        CurrentCell = cell;
                        if (CurrentCell != cell)
                        {
                            currentCell.setGameCbject(Game.GetBlankObject());
                        }
                    }
                }
            }
            return cell;*/
        }
    }
}
