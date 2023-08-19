using Pacman.GameGL;
using System.Drawing;
using System.Windows.Forms;

namespace PacMan.GameGL
{
    class GameCell
    {
        int x;
        int y;
        public GameGrid grid;
        //GameDirection direction;
        public PictureBox pictureBox;
        GameObject currentGameObject;
        const int width = 20;
        const int height = 20;
        public GameCell()
        {
            this.currentGameObject = new GameObject(GameObjectType.NONE, Game.GetGameObjectImage(' '));
        }
        public GameCell(int x, int y,GameGrid grid) 
        {
            this.x = x;
            this.y = y;
            pictureBox = new PictureBox();
            pictureBox.Left = x * width;
            pictureBox.Top = y * height;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Size = new Size(width, height);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.grid = grid;
        }
        public GameCell nextCell(GameDirection direction)
        {
          
            if (direction == GameDirection.Left) {
                if (this.y > 0) {
                    GameCell ncell = grid.getCell(x, y-1);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL) {
                        return ncell;
                    }
                }    
            }

            if (direction == GameDirection.Right)
            {
                if (this.y < grid.Cols-1)
                {
                    GameCell ncell = grid.getCell(this.x, this.y+1);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return ncell;
                    }
                }
            }

            if (direction == GameDirection.Up)
            {
                if (this.x > 0)
                {
                    GameCell ncell = grid.getCell(this.x-1, this.y);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return ncell;
                    }
                }
            }

            if (direction == GameDirection.Down)
            {
                if (this.x < grid.Rows - 1)
                {
                    GameCell ncell = grid.getCell(this.x+1, this.y);
                    if (ncell.CurrentGameObject.GameObjectType != GameObjectType.WALL)
                    {
                        return ncell;
                    }
                }
            }
            return this; // if can not return next cell return its own reference
        }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public void setGameCbject(GameObject gameObject)
        {
            currentGameObject = gameObject;
            pictureBox.Image = gameObject.DisplayCharacter;
        }
        public GameObject CurrentGameObject { get => currentGameObject; }
        public PictureBox PictureBox { get => pictureBox; set => pictureBox = value; }
       // public GameObject CurrentGameObject { get => currentGameObject; set => currentGameObject = value; }
    }
}
