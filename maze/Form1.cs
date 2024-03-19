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
        


        private void makeCells()
        {

            Panel[,] cellCntr = new Panel[gridSize, gridSize]; //panel

            PictureBox[,] wallN = new PictureBox[gridSize, gridSize]; //top wall
            PictureBox[,] wallE = new PictureBox[gridSize, gridSize]; //right wall
            PictureBox[,] wallS = new PictureBox[gridSize, gridSize]; //bottom wall
            PictureBox[,] wallW = new PictureBox[gridSize, gridSize]; //left wall

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

            for (int i = 0; i < (gridSize); i++) //adding grids to a class so i can interact with them
            {                                       //i = row, j = column
                for (int j = 0; j < gridSize; j++)
                {
                    cell newCell = new cell();
                    cells[i, j] = newCell;
                }
            }




            Random rand = new Random();

            int x = rand.Next(0, gridSize);//randomly choosing a cell 
            int y = rand.Next(0, gridSize);

            List<Point> chosenCells = new List<Point>();//adding starting cell to chosen cells list
            Point chosenPoint = new Point(x, y);
            chosenCells.Add(chosenPoint);

            List<Point> potentialNext = new List<Point>();//this will be the list of cells adjacent to chosen cells that may be chosen next iteration

            int[] neighbourRowOffsets = { -1, 0, 1, 0 }; 
            int[] neighbourColOffsets = { 0, 1, 0, -1 };

            for (int direction = 0; direction < 4; direction++) //this checks for the cells adjacent to the chosen cell
            {                                                   //allows me to add to potentialNext without creating runtime error
                int newRow = x + neighbourRowOffsets[direction];
                int newCol = y + neighbourColOffsets[direction];
                Point nextPoint = new Point(newRow,newCol);

                if (newRow >= 0 && newRow < gridSize && newCol >= 0 && newCol < gridSize)
                {
                    potentialNext.Add(nextPoint); //adds cell to list if it is inside the grid
                }
            }

            while(chosenCells.Count < gridCount)
            {
                int i = rand.Next(0, potentialNext.Count);
                x = potentialNext[i].X; //indexing a random potential cell's coordinates
                y = potentialNext[i].Y;

                int index = 0;
                Point[] neighbours = new Point[4];//potential neighbouring chosen points

                for (int direction = 0; direction < 4; direction++) //checking neighbouring cells for a chosen cell
                {                                                   
                    int newRow = x + neighbourRowOffsets[direction];
                    int newCol = y + neighbourColOffsets[direction];

                    Point nextPoint = new Point(newRow, newCol);//selected point from potentialNext

                    if (newRow >= 0 && newRow < gridSize && newCol >= 0 && newCol < gridSize)
                    {
                        if (chosenCells.Contains(nextPoint))
                        {
                            neighbours[index] = nextPoint;
                            index++;
                        }
                    }
                }
                




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
