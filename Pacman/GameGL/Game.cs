using Pacman.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameGL;

namespace Pacman.GameGL
{
    internal class Game
    {
        public static Image GetGameObjectImage(char displayCharacter)
        {
            Image img = Resources.simplebox;
            if(displayCharacter == '|' || displayCharacter == '%')
            {
                img = Resources.my_vertical;
                return img;
            }
            if (displayCharacter == '#')
            {
                img = Resources.my_horizontal;
                return img;
            }
            if (displayCharacter == 'p')
            {
                img = Resources.pacman_open;
                return img;
            }
            if (displayCharacter == '.')
            {
                img = Resources.pellet;
                return img;
            }
            return null;
        }
        public static GameObject GetBlankObject()
        {
            GameObject blank = new GameObject(GameObjectType.NONE, Resources.simplebox);
            return blank;
        }
        public static GameObject GetRewardObject()
        {
            GameObject blank = new GameObject(GameObjectType.REWARD, Resources.pellet);
            return blank;
        }
    }
}
