using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GL
{
    internal abstract class Ghost:GameObject
    {
        protected GameDirection Direction;
        public GameObjectType prevObject = GameObjectType.REWARD;
        public Ghost(Image displayCharacter, GameCell g):base(GameObjectType.ENEMY, displayCharacter)
        { }

        public abstract GameCell move();
    }
}
