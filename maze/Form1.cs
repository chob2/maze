using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private static int gridSize; //number of cells in each row and column

        public PictureBox[,] wallN; //top wall
        public PictureBox[,] wallE; //right wall
        public PictureBox[,] wallS; //bottom wall
        public PictureBox[,] wallW; //left wall
        public Panel[,] cellCntr = new Panel[gridSize, gridSize]; //cell

        private void makeCells() //surprisingly, this segment is the most performance intensive
        { //makes each cell and walls
            try
            {
                gridSize = Convert.ToInt32(gridSizeInput.Text);
                if (gridSize < 1)
                {
                    gridSize = 15;
                    MessageBox.Show("Invalid input, grid size set to default (15).");
                }
                if (gridSize > 44)
                {
                    gridSize = 44;
                    MessageBox.Show("Input above max. Grid size set to max (44).");
                }

            }
            catch
            {
                gridSize = 15;
                MessageBox.Show("Invalid input, grid size set to default (15).");
            }

            progressBar1.Maximum = 6 * gridSize * gridSize;
            int progress = 0;

            wallN = new PictureBox[gridSize, gridSize]; //top wall
            wallE = new PictureBox[gridSize, gridSize]; //right wall
            wallS = new PictureBox[gridSize, gridSize]; //bottom wall
            wallW = new PictureBox[gridSize, gridSize]; //left wall

            cellCntr = new Panel[gridSize, gridSize]; //panel

            int size = mazeContainer.Width / gridSize;


            //i = row and j = column
            //making panel grid
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    var newPanel = new Panel();
                    {
                        newPanel.Location = new Point(size * j, size * i);
                        newPanel.Size = new Size(size, size);
                        newPanel.BackColor = Color.Transparent;

                    }
                    cellCntr[i, j] = newPanel;//adding panel to cellCntr array
                    Controls.Add(cellCntr[i, j]);//add panel controls
                    mazeContainer.Controls.Add(newPanel);//adds cell to container to be displayed at a constant size

                    progressBar1.Value = progress;
                    progress++;
                }
            }

            //making walls and adding them to panel grid
            //draw north
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    var pictureBox = new PictureBox();
                    {
                        pictureBox.Location = new Point(0, 0);
                        pictureBox.Size = new Size(size, 2);
                        pictureBox.BackColor = Color.Black;
                    }
                    wallN[i, j] = pictureBox;
                    cellCntr[i, j].Controls.Add(wallN[i, j]);

                    progressBar1.Value = progress;
                    progress++;

                }
            }
            //draw east
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    var pictureBox = new PictureBox();
                    {
                        pictureBox.Location = new Point(size - 2, 0);
                        pictureBox.Size = new Size(2, size);
                        pictureBox.BackColor = Color.Black;
                    }
                    wallE[i, j] = pictureBox;
                    cellCntr[i, j].Controls.Add(wallE[i, j]);

                    progressBar1.Value = progress;
                    progress++;
                }
            }
            //draw south
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    var pictureBox = new PictureBox();
                    {
                        pictureBox.Location = new Point(0, size - 2);
                        pictureBox.Size = new Size(size, 2);
                        pictureBox.BackColor = Color.Black;
                    }
                    wallS[i, j] = pictureBox;
                    cellCntr[i, j].Controls.Add(wallS[i, j]);

                    progressBar1.Value = progress;
                    progress++;
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
                        pictureBox.Size = new Size(2, size);
                        pictureBox.BackColor = Color.Black;
                    }
                    wallW[i, j] = pictureBox;
                    cellCntr[i, j].Controls.Add(wallW[i, j]);

                    progressBar1.Value = progress;
                    progress++;
                }
            }
            


        }


        private void drawMaze() //uses a randomised prim's algorithm to generate the maze
        {
            try
            {
                gridSize = Convert.ToInt32(gridSizeInput.Text);
                if (gridSize < 1)
                {
                    gridSize = 15;
                }
                if (gridSize > 44)
                {
                    gridSize = 44;
                }
            }
            catch
            {
                gridSize = 15;
            }

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
                Point nextPoint = new Point(newCol, newRow);

                if (newRow >= 0 && newRow < gridSize && newCol >= 0 && newCol < gridSize)
                {
                    potentialNext.Add(nextPoint); //adds cell to list if it is inside the grid
                }
            }

            int count = 0;
            int progress = 5 * gridSize * gridSize;
            while (count < (gridSize * gridSize - 1))
            {
                progressBar1.Value = progress;
                int r = rand.Next(0, potentialNext.Count);//index to choose a random potential cell
                i = potentialNext[r].Y; //indexing a random potential cell's coordinates
                j = potentialNext[r].X;

                int index = 0;//index to choose a valid cell
                Point[] neighbours = new Point[4];//potential neighbouring chosen cells

                for (int direction = 0; direction < 4; direction++) //checking neighbouring cells for a chosen cell
                {
                    int newRow = i + neighbourRowOffsets[direction];
                    int newCol = j + neighbourColOffsets[direction];

                    Point nextPoint = new Point(newCol, newRow);//selected point from potentialNext

                    if (newRow >= 0 && newRow < gridSize && newCol >= 0 && newCol < gridSize)
                    {
                        if (chosenCells.Contains(nextPoint))
                        {
                            neighbours[index] = nextPoint; //adds cell to potential choices if it has already been chosen
                            index++;
                        }
                    }
                }



                int targ = rand.Next(0, index);//choosing valid cell
                //deleting connecting walls between the chosen cells
                //if neighbours[targ].X > potentialNext[r].X -> target cell is to the right
                if (neighbours[targ].X > potentialNext[r].X)
                {
                    wallE[potentialNext[r].Y, potentialNext[r].X].Dispose();
                    wallW[neighbours[targ].Y, neighbours[targ].X].Dispose();
                }
                //if neighbours[targ].X < potentialNext[r].X -> target cell is to the left
                else if (neighbours[targ].X < potentialNext[r].X)
                {
                    wallW[potentialNext[r].Y, potentialNext[r].X].Dispose();
                    wallE[neighbours[targ].Y, neighbours[targ].X].Dispose();
                }
                //if neighbours[targ].Y < potentialNext[r].Y -> target cell is above
                else if (neighbours[targ].Y < potentialNext[r].Y)
                {
                    wallN[potentialNext[r].Y, potentialNext[r].X].Dispose();
                    wallS[neighbours[targ].Y, neighbours[targ].X].Dispose();
                }
                //if neighbours[targ].Y > potentialNext[r].Y -> target cell is below
                else if (neighbours[targ].Y > potentialNext[r].Y)
                {
                    wallS[potentialNext[r].Y, potentialNext[r].X].Dispose();
                    wallN[neighbours[targ].Y, neighbours[targ].X].Dispose();
                }

                
                //find neighbours of potentialNext[r] for next iteration
                //if neighbours arent already chosen or in potentialNext, add to potentialNext
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

                chosenCells.Add(potentialNext[r]); //add chosen cell to chosen cells
                potentialNext.RemoveAt(r); //remove chosen cell from potential choices

                count++;
                progress++;

                this.Update();
            }
            wallN[0, 0].Dispose();
            wallS[gridSize - 1, gridSize - 1].Dispose();
        }


        private void generate()
        {
            time.Visible = false;
            progressBar1.Visible = true;

            var watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    cellCntr[i, j].Dispose(); //disposing of the maze to clear memory, allows for multiple generations without memory leak
                }
            }

            makeCells();
            drawMaze();

            watch.Stop();
            var elapsedTime = watch.ElapsedMilliseconds;

            progressBar1.Visible = false;
            time.Visible = true;

            time.Text = "Generated in " + elapsedTime.ToString() + "ms";
        }


        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            generate();
        }


        private void gridSizeInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                generate();
            }
        }
    }
}
