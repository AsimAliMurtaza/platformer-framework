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
    internal class SGhost:Ghost
    {
        private GamePacManPlayer pacman;
        public SGhost(Image displayCharacter, GameCell g, GamePacManPlayer p) : base(displayCharacter, g)
        {

            this.CurrentCell = g;
            this.DisplayCharacter = displayCharacter;
            this.pacman = p;
        }
        public override GameCell move()
        {
            List<double> distance = new List<double>();
            distance.Add(CalculateDistance(this.CurrentCell.nextCell(GameDirection.Left), pacman.CurrentCell));
            distance.Add(CalculateDistance(this.CurrentCell.nextCell(GameDirection.Right), pacman.CurrentCell));
            distance.Add(CalculateDistance(this.CurrentCell.nextCell(GameDirection.Down), pacman.CurrentCell));
            distance.Add(CalculateDistance(this.CurrentCell.nextCell(GameDirection.Up), pacman.CurrentCell));

            if (distance[0] <= distance[1] && distance[0] <= distance[2] && distance[0] <= distance[3])
            {
                Direction = GameDirection.Left;
            }
            else if (distance[1] <= distance[0] && distance[1] <= distance[2] && distance[1] <= distance[3])
            {
                Direction = GameDirection.Right;
            }
            else if (distance[2] <= distance[0] && distance[2] <= distance[1] && distance[2] <= distance[3])
            {
                Direction = GameDirection.Down;
            }
            else
            {
                Direction = GameDirection.Up;
            }

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
            return nextCell.nextCell(Direction);
            /*GameCell cell;
                cell = CurrentCell;
                double shortestDistance = CalculateDistance(CurrentCell, pacman.CurrentCell);

              List<GameCell> neighborCell = new List<GameCell>();
              neighborCells.Add(this.CurrentCell.nextCell(GameDirection.Right));
              neighborCells.Add(this.CurrentCell.nextCell(GameDirection.Left));
              neighborCells.Add(this.CurrentCell.nextCell(GameDirection.Up));
              neighborCells.Add(this.CurrentCell.nextCell(GameDirection.Down));

              foreach (GameCell neighborCell in neighborCells)
              {
                  if (neighborCell.CurrentGameObject.GameObjectType == GameObjectType.NONE || neighborCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD)
                  {
                  double distance = CalculateDistance(neighborCell, pacman.CurrentCell);
                  if (distance < shortestDistance)
                  {
                      shortestDistance = distance;
                      cell = neighborCell;
                  }
                  }
            }
            CurrentCell = cell;
            if (CurrentCell != cell)
            {
                CurrentCell.setGameCbject(Game.GetBlankObject());
            }

            return CurrentCell;*/
        }
        private double CalculateDistance(GameCell cell1, GameCell cell2)
        {
            int x1 = cell1.X;
            int y1 = cell1.Y;
            int x2 = cell2.X;
            int y2 = cell2.Y;
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}
