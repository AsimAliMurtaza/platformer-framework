using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan.GameGL
{
    class GameObject
    {
        Image displayImage;
        //public PictureBox pictureBox = new PictureBox();
        GameObjectType gameObjectType;
        protected GameCell currentCell;
        public GameObject(GameObjectType type, Image displayImage)
        {
            this.displayImage = displayImage;
            this.gameObjectType = type;
            
        }

        public static GameObjectType getGameObjectType(char displayCharacter) { 

            if (displayCharacter == '|' || displayCharacter == '%' || displayCharacter == '#') {
                return GameObjectType.WALL;
            }

            if (displayCharacter == '.') {
                return GameObjectType.REWARD;
            }

            return GameObjectType.NONE;
        }
        public Image DisplayCharacter { get => displayImage; set => displayImage = value; }
        public GameObjectType GameObjectType { get => gameObjectType; set => gameObjectType = value; }
        public GameCell CurrentCell { 
            get => currentCell; 
            set  { 
                currentCell = value;
                currentCell.setGameCbject(this);
            }
        }


    }
}
