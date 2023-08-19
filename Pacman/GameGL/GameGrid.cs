using Pacman.GameGL;
using System;
using System.Drawing;
using System.IO;

namespace PacMan.GameGL
{
    class GameGrid
    {
        GameCell[,] cells;
        int rows;
        int cols;
        
        public GameGrid(String fileName, int rows, int cols ) {
            //Numbers of rows and cols should load from the text file
            //this.rows = rows;
            //this.cols = cols;
            ReadRowsAndColumns(fileName);
            cells = new GameCell[this.rows, this.cols];
            this.loadGrid(fileName);
        }
        void ReadRowsAndColumns(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            string record;
            while((record = streamReader.ReadLine())!=null)
            {
                rows++;
                cols = record.Length;
            }
        }
        public GameCell getCell(int x, int y) {
            return cells[x, y];
        } 
        public int Rows { get => rows; set => rows = value; }
        public int Cols { get => cols; set => cols = value; }

        void loadGrid(string fileName)
        {

            StreamReader fp = new StreamReader(fileName);
            string record;
            for (int row = 0; row < this.rows; row++)
            {
                record = fp.ReadLine();
                for (int col = 0; col < this.cols; col++)
                {
                    GameCell cell = new GameCell(row, col, this);
                    Char displayCharacter = record[col];
                    GameObjectType type = GameObject.getGameObjectType(displayCharacter);
                    Image image = Game.GetGameObjectImage(displayCharacter);
                    GameObject gameObject = new GameObject(type, image);
                    cell.setGameCbject(gameObject);
                    cells[row, col] = cell;
                }
            }

            fp.Close();
        }
    }
}
