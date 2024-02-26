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
        private void makeCells()
        {
            int gridSizeX = 5;
            int gridSizeY = 5;

            Panel[,] cellCntr = new Panel[gridSizeX, gridSizeY];

            PictureBox[,] wallN = new PictureBox[gridSizeX, gridSizeY]; //top wall
            PictureBox[,] wallE = new PictureBox[gridSizeX, gridSizeY]; //right wall
            PictureBox[,] wallS = new PictureBox[gridSizeX, gridSizeY]; //bottom wall
            PictureBox[,] wallW = new PictureBox[gridSizeX, gridSizeY]; //left wall

            for (int i = 0; i < gridSizeY; i++)
            {
                for (int j = 0; j < gridSizeX; j++)
                {
                    var newPanel = new Panel();
                    {
                        newPanel.Location = new Point(100 * j, 100 * i);
                        newPanel.Size = new Size(100, 100);
                        newPanel.BackColor = Color.Transparent;
                        newPanel.BorderStyle = BorderStyle.FixedSingle;
                    }

                    Controls.Add(newPanel);
                    cellCntr[i, j] = newPanel;


                }
            }
            for (int i = 0; i < gridSizeY; i++)
            {
                for (int j = 0; j < gridSizeX; j++)
                {
                    var pictureBox = new PictureBox();
                    {
                        // pictureBox.Location = new Point(cellCntr[i, j].Location.X, cellCntr[i, j].Location.Y);
                        pictureBox.Location = new Point(600,600);
                        pictureBox.Size = new Size(100, 20);
                        pictureBox.BackColor = Color.Black;
                    }
                    Controls.Add(pictureBox);
                    wallN[i, j] = pictureBox;
                    cellCntr[i, j].Controls.Add(wallN);


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
