using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Maze
{
    public class Maze : PictureBox
    {
        private int[,] cells;
        public int Width { get { return cells.GetLength(0); } }
        public int Height { get { return cells.GetLength(1); } }

        const int NORD = 1; // en haut 1000
        const int EST = 2; // à droite 0100
        const int SUD = 4; // en bas 0010
        const int OUEST = 8; // à gauche 0001

        public Maze()
        {
           
        }

        public bool HasWall(int x, int y, int direction)
        {
            // Vérifier si la cellule (x,y) a un mur dans la direction donnée
            return (cells[x, y] & direction) != 0;
        }
        public Bitmap MazeToImage(int cellSize)
        {
            // Desiner le labyrinthe
            Bitmap img = new Bitmap(Width * cellSize, Height * cellSize);
            using (Graphics g = Graphics.FromImage(img))
            {
                g.Clear(Color.White);
                Pen pen = new Pen(Color.Black, 2);
                for (int x = 0; x < Width; x++) 
                {
                    for(int y = 0; y < Height; y++)
                    {
                        int px = x * cellSize;
                        int py = y * cellSize;

                        if (HasWall(x, y, NORD))
                            g.DrawLine(pen, px, py, px + cellSize, py);
                        if (HasWall(x, y, SUD))
                            g.DrawLine(pen, px, py + cellSize, px + cellSize, py + cellSize);
                        if (HasWall(x, y, OUEST))
                            g.DrawLine(pen, px, py, px, py + cellSize);
                        if (HasWall(x, y, EST))
                            g.DrawLine(pen, px + cellSize, py, px + cellSize, py + cellSize);
                    }
                }
            }
            
            return new Bitmap(1, 1);
        }
        

        public void MazeToTxtFile(string fileName)
        {
            // Sauvegarder le labyrinthe dans un fichier texte
            string[] lines = File.ReadAllLines(fileName);
            int height = lines.Count() / 2;
            int width = (lines[0].Length) / 4;
            cells = new int[width, height];
        }
    }
}
