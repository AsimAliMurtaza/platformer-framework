using Pacman.GL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GameDL
{
    internal class GhostsDL
    {
        public static List<Ghost> ghosts = new List<Ghost>();

        public static void AddGhost(Ghost ghost)
        { ghosts.Add(ghost); }
    }
}
