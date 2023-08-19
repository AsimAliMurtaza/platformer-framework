using Pacman.GameGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameGL
{
    class GamePacManPlayer : GameObject
    {
        public int Score = 0;
        public bool isJumping;
        public GamePacManPlayer(Image displayCharacter,GameCell startCell):base (GameObjectType.PLAYER,displayCharacter) {
            this.CurrentCell = startCell;
            //this.DisplayCharacter = displayCharacter;
        }
        public GameCell move(GameDirection direction) {

            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            if (Collisions.playerCollisionWithPallet(nextCell))
            {
                Score++;
            }
            else if (Collisions.playerCollisionWithEnemy(nextCell))
            {
                Score--;
            }
            //nextCell.setGameCbject(this);
            CurrentCell = nextCell;
            if (currentCell != nextCell)
            {
                currentCell.setGameCbject(Game.GetBlankObject());
            }
            return nextCell.nextCell(direction);
        }
    }

    
}
