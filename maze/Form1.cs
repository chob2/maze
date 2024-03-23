using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace maze
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int gridSize = 9;
        public static int gridCount = gridSize * gridSize;
        class cell
        {
            public bool colony = false; //if the square has been selected
            public bool frontier = false;
            public int tag = -1;
            bool nWall = true; //walls, true = wall exists
            bool eWall = true;
            bool sWall = true;
            bool wWall = true;
        }

        public PictureBox[,] wallN = new PictureBox[gridSize, gridSize]; //top wall
        public PictureBox[,] wallE = new PictureBox[gridSize, gridSize]; //right wall
        public PictureBox[,] wallS = new PictureBox[gridSize, gridSize]; //bottom wall
        public PictureBox[,] wallW = new PictureBox[gridSize, gridSize]; //left wall

        private void makeCells()
        {

            Panel[,] cellCntr = new Panel[gridSize, gridSize]; //panel


             //i = row and j = column
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    var newPanel = new Panel();//making panel
                    {
                        newPanel.Location = new Point(50 * j, 50 * i);
                        newPanel.Size = new Size(50, 50);
                        newPanel.BackColor = Color.Transparent;

                    }
                    cellCntr[i, j] = newPanel;//adding panel to cellCntr array
                    Controls.Add(cellCntr[i, j]);//add panel controls


                }
            }
            //draw north
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    var pictureBox = new PictureBox();
                    {
                        pictureBox.Location = new Point(0, 0);
                        pictureBox.Size = new Size(50, 2);
                        pictureBox.BackColor = Color.Black;
                    }
                    wallN[i, j] = pictureBox;
                    cellCntr[i, j].Controls.Add(wallN[i, j]);


                }
            }
            //draw east
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    var pictureBox = new PictureBox();
                    {
                        pictureBox.Location = new Point(48, 0);
                        pictureBox.Size = new Size(2, 50);
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
                        pictureBox.Location = new Point(0, 48);
                        pictureBox.Size = new Size(50, 2);
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
                        pictureBox.Size = new Size(2, 50);
                        pictureBox.BackColor = Color.Black;
                    }
                    wallW[i, j] = pictureBox;
                    cellCntr[i, j].Controls.Add(wallW[i, j]);


                }
            }
        }


        private void drawMaze()
        {           
            Random rand = new Random();

            int i = rand.Next(0, gridSize);//randomly choosing a cell 
            int j = rand.Next(0, gridSize); //i = rows and j = columns
                                            //i = Y value of point, j = x value of point

            List<Point> chosenCells = new List<Point>();//adding starting cell to chosen cells list
            Point chosenPoint = new Point(j, i);
            chosenCells.Add(chosenPoint);

            List<Point> potentialNext = new List<Point>();//this will be the list of cells adjacent to chosen cells that may be chosen next iteration

            int[] neighbourRowOffsets = { -1, 0, 1, 0 }; 
            int[] neighbourColOffsets = { 0, 1, 0, -1 };

            for (int direction = 0; direction < 4; direction++) //this checks for the cells adjacent to the chosen cell
            {                                                   //allows me to add to potentialNext without creating runtime error
                int newRow = i + neighbourRowOffsets[direction];
                int newCol = j + neighbourColOffsets[direction];
                Point nextPoint = new Point(newCol,newRow);

                if (newRow >= 0 && newRow < gridSize && newCol >= 0 && newCol < gridSize)
                {
                    potentialNext.Add(nextPoint); //adds cell to list if it is inside the grid
                }
            }

            int count = 0;
            while (count < (gridCount-1))
            {
                int r = rand.Next(0, potentialNext.Count);
                i = potentialNext[r].Y; //indexing a random potential cell's coordinates
                j = potentialNext[r].X;

                int index = 0;
                Point[] neighbours = new Point[4];//potential neighbouring chosen points

                for (int direction = 0; direction < 4; direction++) //checking neighbouring cells for a chosen cell
                {
                    int newRow = i + neighbourRowOffsets[direction];
                    int newCol = j + neighbourColOffsets[direction];

                    Point nextPoint = new Point(newCol, newRow);//selected point from potentialNext

                    if (newRow >= 0 && newRow < gridSize && newCol >= 0 && newCol < gridSize)
                    {
                        if (chosenCells.Contains(nextPoint))
                        {
                            neighbours[index] = nextPoint;
                            index++;
                        }
                    }
                }
                



                int targ = rand.Next(0, index);
                //if neighbours[targ].X > potentialNext[r].X -> target cell is to the right
                if(neighbours[targ].X > potentialNext[r].X)
                {
                    wallE[potentialNext[r].Y, potentialNext[r].X].Visible = false;
                    wallW[neighbours[targ].Y, neighbours[targ].X].Visible = false;
                }
                //if neighbours[targ].X < potentialNext[r].X -> target cell is to the left
                else if (neighbours[targ].X < potentialNext[r].X)
                {
                    wallW[potentialNext[r].Y, potentialNext[r].X].Visible = false;
                    wallE[neighbours[targ].Y, neighbours[targ].X].Visible = false;
                }
                //if neighbours[targ].Y < potentialNext[r].Y -> target cell is above
                else if (neighbours[targ].Y < potentialNext[r].Y)
                {
                    wallN[potentialNext[r].Y, potentialNext[r].X].Visible = false;
                    wallS[neighbours[targ].Y, neighbours[targ].X].Visible = false;
                }
                //if neighbours[targ].Y > potentialNext[r].Y -> target cell is below
                else if(neighbours[targ].Y > potentialNext[r].Y)
                {
                    wallS[potentialNext[r].Y, potentialNext[r].X].Visible = false;
                    wallN[neighbours[targ].Y, neighbours[targ].X].Visible = false;
                }
                //if target cell is above, remove potentialNext[targ] north wall and remove target cell south wall
                






                //find neighbours of potentialNext[r]
                //if neighbours arent chosen or in potentialNext, add to potentialNext
                for (int direction = 0; direction < 4; direction++) //this checks for the cells adjacent to the chosen cell
                {                                                   //allows me to add to potentialNext without creating runtime error
                    int newRow = i + neighbourRowOffsets[direction];
                    int newCol = j + neighbourColOffsets[direction];
                    Point nextPoint = new Point(newCol, newRow);

                    if (newRow >= 0 && newRow < gridSize && newCol >= 0 && newCol < gridSize)
                    {
                        if (!chosenCells.Contains(nextPoint) && !potentialNext.Contains(nextPoint))
                        {
                            potentialNext.Add(nextPoint); //adds cell to list if it is inside the grid and not previously interacted with

                        }
                    }
                }

                chosenCells.Add(potentialNext[r]);//these two lines are what causes runtime error in line 234
                potentialNext.RemoveAt(r); //figured it out, im not adding to potentialNext each iteration, explains why it never gets past 4th iteration



                count++;

                //fixed indexing error, maze generation is still fucked, must do a desk check
            }





        }



        private void button1_Click(object sender, EventArgs e)
        {
            makeCells();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            drawMaze();
        }
    }
}
