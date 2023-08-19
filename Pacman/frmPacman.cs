using Pacman.Properties;
using PacMan.GameGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;
using Pacman.GL;
using Pacman.GameDL;
using Pacman.GameGL;
using System.Threading;

namespace Pacman
{
    public partial class frmPacman : Form
    {
        GamePacManPlayer pacman;
        int Health = 100;
        Label lbl = new Label();
        //GameCell returnCell = new GameCell();
        public frmPacman()
        {
            InitializeComponent();
            
        }

        private void frmPacman_Load(object sender, EventArgs e)
        {
            createLabel();
            GameGrid grid = new GameGrid("maze.txt", 24, 71);
            GameCell startPacmanCell = new GameCell(12, 23, grid);
            GameCell startVGHost = new GameCell(1, 3, grid);
            pacman = new GamePacManPlayer(Resources.pacman_open, startPacmanCell);
            Ghost VGhost = new VGhost(Resources.ghost_pink, startVGHost, GameDirection.Up);
            Ghost HGhost = new HGhost(Resources.ghost_blue, startVGHost, GameDirection.Left);
            Ghost RGhost = new RGhost(Resources.ghost_fright, startVGHost);
            Ghost SGhost = new SGhost(Resources.ghost_red, startVGHost, pacman);
            GhostsDL.AddGhost(SGhost);
            GhostsDL.AddGhost(RGhost);
            GhostsDL.AddGhost(HGhost);
            GhostsDL.AddGhost(VGhost);

            startPacmanCell.setGameCbject(pacman);

            foreach (Ghost ghost in GhostsDL.ghosts)
            {
                startVGHost.setGameCbject(ghost);
            }
            foreach (Ghost ghost in GhostsDL.ghosts)
            {
                printGhost(ghost);
            }
            printPacman(pacman);
            printMaze(grid);
            
        }
        private void createLabel()
        {
            lbl.Top = 500;
            lbl.Left = 10;
            lbl.ForeColor = Color.White;
            this.Controls.Add(lbl);
        }
        private void showLabel()
        {
            lbl.Text = "Score: " + pacman.Score.ToString();
        }
        private void printMaze(GameGrid grid)
        {
            for(int row = 0; row<grid.Rows; row++)
            {
                for(int col = 0; col<grid.Cols; col++)
                {
                    GameCell cell = grid.getCell(row, col);
                    setPictureLocation(cell);
                    this.Controls.Add(cell.pictureBox);
                }
            }
        }
        private void printPacman(GamePacManPlayer pacman)
        {
            //setPictureLocation(pacman.CurrentCell);
            this.Controls.Add(pacman.CurrentCell.pictureBox);

        }
        private void printGhost(Ghost g)
        {
            //setPictureLocation(g.CurrentCell);
            this.Controls.Add(g.CurrentCell.pictureBox);

        }
        private void setPictureLocation(GameCell cell)
        {
            cell.pictureBox.Left = cell.Y * cell.pictureBox.Width;
            cell.pictureBox.Top = cell.X * cell.pictureBox.Height;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                pacman.move(GameDirection.Left);
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                pacman.move(GameDirection.Right);
            }
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                pacman.move(GameDirection.Up);
                pacman.isJumping = true;
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                pacman.move(GameDirection.Down);
            }
            if(!Keyboard.IsKeyPressed(Key.UpArrow))
            {
                pacman.isJumping = false;
            }
            if(!pacman.isJumping)
                gravity();
            for (int i = 0; i<GhostsDL.ghosts.Count; i++)
            {
                GhostsDL.ghosts[i].move();
                if(pacman.Score < 0)/*Collisions.playerCollisionWithEnemy(pacman, GhostsDL.ghosts[i])*/
                {
                    timer.Enabled = false;
                    this.Hide();
                    EndGame(Resources.gameover);
                }
            }
            showLabel();
        }
        
        private void EndGame(Image img )
        {
            timer.Enabled = false;
            frmGameOver form = new frmGameOver(img);
            DialogResult result = form.ShowDialog();
            if(result == DialogResult.Yes)
            {
                this.Close();
            }
            if (result == DialogResult.No)
            {
                restart();
            }
        }
        private void restart()
        {
            timer.Enabled = true;
            this.Show();
            this.Controls.Clear();
            Label lbl = new Label();
            this.Controls.Add(lbl);
            GameGrid grid = new GameGrid("maze.txt", 24, 71);
            GameCell startPacmanCell = new GameCell(12, 23, grid);
            GameCell startVGHost = new GameCell(1, 3, grid);
            pacman = new GamePacManPlayer(Resources.pacman_open, startPacmanCell);
            Ghost VGhost = new VGhost(Resources.ghost_pink, startVGHost, GameDirection.Up);
            Ghost HGhost = new HGhost(Resources.ghost_blue, startVGHost, GameDirection.Left);
            Ghost RGhost = new RGhost(Resources.ghost_fright, startVGHost);
            Ghost SGhost = new SGhost(Resources.ghost_red, startVGHost, pacman);
            GhostsDL.AddGhost(SGhost);
            GhostsDL.AddGhost(RGhost);
            GhostsDL.AddGhost(HGhost);
            GhostsDL.AddGhost(VGhost);

            startPacmanCell.setGameCbject(pacman);

            foreach (Ghost ghost in GhostsDL.ghosts)
            {
                startVGHost.setGameCbject(ghost);
            }
            printPacman(pacman);
            printMaze(grid);

        }
        void gravity()
        {
            pacman.move(GameDirection.Down);
        }
    }
}
