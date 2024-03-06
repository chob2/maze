using System;
using System.Drawing;
using System.Windows.Forms;

namespace maze
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int gridSize = 5;
        public class cell
        {

            bool visited = false; //if the square has been selected

            bool nWall = true; //walls, true = wall exists
            bool eWall = true;
            bool sWall = true;
            bool wWall = true;
        }

        private void makeCells()
        {


            Panel[,] cellCntr = new Panel[gridSize, gridSize];

            PictureBox[,] wallN = new PictureBox[gridSize, gridSize]; //top wall
            PictureBox[,] wallE = new PictureBox[gridSize, gridSize]; //right wall
            PictureBox[,] wallS = new PictureBox[gridSize, gridSize]; //bottom wall
            PictureBox[,] wallW = new PictureBox[gridSize, gridSize]; //left wall

            cell[,] newCell = new cell[gridSize,gridSize]; //cell class

            int index = 0; //for adding stuff to newCell

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    var newPanel = new Panel();
                    {
                        newPanel.Location = new Point(100 * j, 100 * i);
                        newPanel.Size = new Size(100, 100);
                        newPanel.BackColor = Color.Transparent;
                     
                    }
                    cellCntr[i, j] = newPanel;
                    Controls.Add(cellCntr[i, j]);


                    
                    index++;
                }
            }
            //draw north
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    var pictureBox = new PictureBox();
                    {
                        pictureBox.Location = new Point(0,0);
                        pictureBox.Size = new Size(100, 2);
                        pictureBox.BackColor = Color.Black;
                    }
                    wallN[i, j] = pictureBox;
                    cellCntr[i, j].Controls.Add(wallN[i,j]);


                }
            }
            //draw east
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    var pictureBox = new PictureBox();
                    {
                        pictureBox.Location = new Point(98, 0);
                        pictureBox.Size = new Size(2, 100);
                        pictureBox.BackColor = Color.Black;
                    }
                    wallE[i, j] = pictureBox;
                    cellCntr[i, j].Controls.Add(wallE[i, j]);


                }
            }
            //draw south
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    var pictureBox = new PictureBox();
                    {
                        pictureBox.Location = new Point(0, 98);
                        pictureBox.Size = new Size(100, 2);
                        pictureBox.BackColor = Color.Black;
                    }
                    wallS[i, j] = pictureBox;
                    cellCntr[i, j].Controls.Add(wallS[i, j]);


                }
            }
            //draw west
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    var pictureBox = new PictureBox();
                    {
                        pictureBox.Location = new Point(0, 0);
                        pictureBox.Size = new Size(2, 100);
                        pictureBox.BackColor = Color.Black;
                    }
                    wallW[i, j] = pictureBox;
                    cellCntr[i, j].Controls.Add(wallW[i, j]);


                }
            }
        }


        private void drawMaze()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            makeCells();
        }
    }
}
