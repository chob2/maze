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
        public static int gridSize = 5;
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
                        newPanel.Location = new Point(100 * j, 100 * i);
                        newPanel.Size = new Size(100, 100);
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
                        pictureBox.Size = new Size(100, 2);
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
            /* cell[,] cells = new cell[gridSize, gridSize]; //cell class


             Random rand = new Random();








             for (int i = 0; i < (gridSize); i++) //adding cells class to grid
             {
                 for (int j = 0; j < gridSize; j++)
                 {
                     cell newCell = new cell();
                     cells[i, j] = newCell;
                 }
             }

            // cells[x, y].colony = true;
             int tag = 0; //assigns colony cell to an index

             cell[,] poolCells = new cell[gridSize, gridSize];
             cell newPoolCell = new cell();

             int x = rand.Next(0, gridSize); //x = rows
             int y = rand.Next(0, gridSize);//y = columns

             cells[x, y].tag = tag; //first cell index at 0
             tag++;

             int[] neighbourRowOffsets = { -1, 0, 1, 0 };
             int[] neighbourColOffsets = { 0, 1, 0, -1 };
             for (int direction = 0; direction < 4; direction++)
             {
                 int newRow = x + neighbourRowOffsets[direction];
                 int newCol = y + neighbourColOffsets[direction];

                 if(newRow >=0 && newRow < gridSize && newCol >= 0 && newCol < gridSize)
                 {
                     poolCells[newRow, newCol] = newPoolCell;
                 }
             }

             for (int i = 0; i < gridSize * gridSize; i++)
             {   






                 for (int direction = 0; direction < 4; direction++)
                 {

                 }
             }*/



            cell[,] cells = new cell[gridSize, gridSize]; //cell class

            for (int I = 0; I < (gridSize); I++) //adding grids to a class so i can interact with them
            {                                       //i = row, j = column
                for (int J = 0; J < gridSize; J++)
                {
                    cell newCell = new cell();
                    cells[I, J] = newCell;
                }
            }




            Random rand = new Random();

            int i = rand.Next(0, gridSize);//randomly choosing a cell 
            int j = rand.Next(0, gridSize); //i = rows and j = columns

            List<Point> chosenCells = new List<Point>();//adding starting cell to chosen cells list
            Point chosenPoint = new Point(i, j);
            chosenCells.Add(chosenPoint);

            List<Point> potentialNext = new List<Point>();//this will be the list of cells adjacent to chosen cells that may be chosen next iteration

            int[] neighbourRowOffsets = { -1, 0, 1, 0 }; 
            int[] neighbourColOffsets = { 0, 1, 0, -1 };

            for (int direction = 0; direction < 4; direction++) //this checks for the cells adjacent to the chosen cell
            {                                                   //allows me to add to potentialNext without creating runtime error
                int newRow = i + neighbourRowOffsets[direction];
                int newCol = j + neighbourColOffsets[direction];
                Point nextPoint = new Point(newRow,newCol);

                if (newRow >= 0 && newRow < gridSize && newCol >= 0 && newCol < gridSize)
                {
                    potentialNext.Add(nextPoint); //adds cell to list if it is inside the grid
                }
            }
            int count = 0;
            while (count < gridCount - 1)
            {
                int r = rand.Next(0, potentialNext.Count);
                i = potentialNext[r].X; //indexing a random potential cell's coordinates
                j = potentialNext[r].Y;

                int index = 0;
                Point[] neighbours = new Point[4];//potential neighbouring chosen points
                int[] dirI = new int[4];
                int[] dirJ = new int[4];
                for (int direction = 0; direction < 4; direction++) //checking neighbouring cells for a chosen cell
                {
                    int newRow = i + neighbourRowOffsets[direction];
                    int newCol = j + neighbourColOffsets[direction];

                    Point nextPoint = new Point(newRow, newCol);//selected point from potentialNext

                    if (newRow >= 0 && newRow < gridSize && newCol >= 0 && newCol < gridSize)
                    {
                        if (chosenCells.Contains(nextPoint))
                        {
                            neighbours[index] = nextPoint;
                            dirI[index] = neighbourRowOffsets[direction];
                            dirJ[index] = neighbourColOffsets[direction];
                            index++;
                        }
                    }
                }
                
                //find neighbours of potentialNext[r]
                //if neighbours arent chosen or in potentialNext, add to potentialNext
                for (int direction = 0; direction < 4; direction++) //this checks for the cells adjacent to the chosen cell
                {                                                   //allows me to add to potentialNext without creating runtime error
                    int newRow = i + neighbourRowOffsets[direction];
                    int newCol = j + neighbourColOffsets[direction];
                    Point nextPoint = new Point(newRow, newCol);

                    if (newRow >= 0 && newRow < gridSize && newCol >= 0 && newCol < gridSize)
                    {
                        if (!chosenCells.Contains(nextPoint) && !potentialNext.Contains(nextPoint))
                        {
                            potentialNext.Add(nextPoint); //adds cell to list if it is inside the grid and not previously interacted with

                        }
                    }
                }
                int targ = rand.Next(0, index);
                //if target cell is above, remove potentialNext[targ] north wall and remove target cell south wall
                if (dirI[targ] == 1 && dirJ[targ] == 0)
                {
                    wallN[i, j].Visible = false;
                    wallS[i + dirI[targ], j + dirJ[targ]].Visible = false;
                }
                //if target cell is below, remove potentialNext[targ] south wall and remove target cell north wall
                else if (dirI[targ] == 1 && dirJ[targ] == 0)
                {
                    wallS[i, j].Visible = false;
                    wallN[i + dirI[targ], j + dirJ[targ]].Visible = false;
                }
                //if target cell is to the right, remove potentialNext[targ] east wall and remove target cell west wall
                else if (dirI[targ] == 1 && dirJ[targ] == 0)
                {
                    wallE[i, j].Visible = false;
                    wallW[i + dirI[targ], j + dirJ[targ]].Visible = false;
                }
                //if target cell is to the left, remove potentialNext[targ] west wall and remove target cell east wall
                else if (dirI[targ] == 1 && dirJ[targ] == 0)
                {
                    wallW[i, j].Visible = false;
                    wallE[i + dirI[targ], j + dirJ[targ]].Visible = false;
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
